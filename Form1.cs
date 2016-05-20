using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace vdrugs
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      autoDrugs = new AutoCompleteStringCollection();
      tbDrug.AutoCompleteCustomSource = autoDrugs;
      wc = new WebClient();
    }

    AutoCompleteStringCollection autoDrugs;
    WebClient wc;

    #region Обработчики событий

    private void btnCheck_Click(object sender, EventArgs e)
    {
      CheckDrug();
    }

    private void tbDrug_TextChanged(object sender, EventArgs e)
    {
      btnCheck.Enabled = tbDrug.Text.Length > 0;
      if (tbDrug.Text.Length == 0)
        lbNotFound.Visible = false;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      appDir = Path.GetDirectoryName(Application.ExecutablePath);
      drugFile = Path.Combine(appDir, "drug.htm");
      autoFile = Path.Combine(appDir, "hints.txt");
      if (File.Exists(autoFile))
        autoDrugs.AddRange(File.ReadAllLines(autoFile));
      hintCount = autoDrugs.Count;
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (autoDrugs.Count > hintCount)
        UpdateHints();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      lstDrugs.Items.Add(lstOptions.SelectedItem);
      lstOptions.Items.RemoveAt(lstOptions.SelectedIndex);
      EnableSetButtons(true);
    }

    private void lstOptions_SelectedIndexChanged(object sender, EventArgs e)
    {
      CheckListButton(lstOptions, btnAdd);
    }

    private void lstDrugs_SelectedIndexChanged(object sender, EventArgs e)
    {
      CheckListButton(lstDrugs, btnDel);
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      lstDrugs.Items.Clear();
      EnableSetButtons(false);
    }

    private void btnDel_Click(object sender, EventArgs e)
    {
      lstDrugs.Items.RemoveAt(lstDrugs.SelectedIndex);
      EnableSetButtons(lstDrugs.Items.Count > 0);
    }

    private void tbDrug_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
        CheckDrug();
    }

    private void btnProcess_Click(object sender, EventArgs e)
    {
      drugs = new List<DrugInfo>();
      DrugInfo di;
      foreach (object drug in lstDrugs.Items)
      {
        di = drug as DrugInfo;
        drugs.Add(di);
      }
      bg.RunWorkerAsync();
      btnProcess.Enabled = false;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      bg.CancelAsync();
      btnCancel.Enabled = false;
    }

    private void bg_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      Stream priceStream;
      List<DrugPrice> prices;
      var pharmacy = new Dictionary<string, List<DrugPrice>>();
      string address;
      string priceUrl;
      foreach (DrugInfo drug in drugs)
      {
        priceUrl = String.Format("{0}{1}", baseUrl, drug.FindLink);
        priceStream = wc.OpenRead(priceUrl);
        prices = GetPrices(priceStream);
        foreach (DrugPrice dp in prices)
        {
          address = dp.Address;
          if (!pharmacy.ContainsKey(address))
            pharmacy.Add(address, new List<DrugPrice>());
          pharmacy[address].Add(dp);
        }
      }
      DrugSet ds;
      var drugSets = new List<DrugSet>();
      foreach(string addr in pharmacy.Keys)
        if (pharmacy[addr].Count == drugs.Count) //есть все нужные лекарства
        {
          ds = new DrugSet
          {
            Address = addr,
            Drugs = pharmacy[addr]
          };
          drugSets.Add(ds);
        }
      e.Result = drugSets;
    }

    #endregion

    string appDir;
    string drugFile;
    string autoFile;
    int hintCount;
    const string baseUrl = "http://analit.net";

    private void CheckDrug()
    {
      lstOptions.Items.Clear();
      const String drugFmt = "{1}/apteka/Main/SearchResult?filter.query={0}&filter.region=1099511627776";
      var url = String.Format(drugFmt, tbDrug.Text, baseUrl);
      var drugStream = wc.OpenRead(url);
      var options = GetOptions(drugStream);
      if (options.Count == 0) //ничего не найдено
      {
        lbNotFound.Visible = true;
        return;
      }
      if (!autoDrugs.Contains(tbDrug.Text))
        autoDrugs.Add(tbDrug.Text);
      if (options.Count == 1)
      {
        lstDrugs.Items.Add(options[0]);
        EnableSetButtons(true);
      }
      else
        foreach (DrugInfo di in options)
          lstOptions.Items.Add(di);
    }

    List<DrugInfo> GetOptions(Stream ostream)
    {
      var options = new List<DrugInfo>();
        var tableCode = GetTableCode(ostream, "<table id=\"searchTable\" class=\"drug_result\"");
        var tr = new string[] { "</tr>" }; //разделитель строк таблицы
        var td = new string[] { "</td>" }; //разделитель ячеек таблицы
        var rows = tableCode.Split(tr, StringSplitOptions.None); //строки
        DrugInfo di;
        for (int i = 0; i < rows.Length - 2; i++)
        {
          var cells = rows[i].Split(td, StringSplitOptions.None); //ячейки
          di = new DrugInfo {
            Name = tbDrug.Text,
            FindLink = GetFindLink(ClearCell(cells[1])),
            Option = ClearCell(cells[2]) };
          options.Add(di);
        }
      return options;
    }

    static string[] GetRows(string table)
    {
      return table.Split(new string[] { "</tr>" }, StringSplitOptions.None);
    }

    static List<string> GetCells(string row)
    {
      var cells = row.Split(new string[] { "</td>" }, StringSplitOptions.None);
      var clearCells = new List<string>(cells.Length);
      for (int i = 0; i < cells.Length; i++)
        clearCells.Add(ClearCell(cells[i]));
      return clearCells;
    }

    /// <summary>
    /// Возвращает содержимое ячейки таблицы
    /// </summary>
    /// <param name="cell">Код ячейки</param>
    /// <returns>Содержимое ячейки</returns>
    static string ClearCell(string cell)
    {
      return cell.Replace("<td>", String.Empty).Trim();
    }

    static string GetFindLink(string cell)
    {
      var link = String.Empty;
      const string href = "href=\"";
      var hrefPos = cell.IndexOf(href);
      if (hrefPos != -1)
      {
        var linkStart = hrefPos + href.Length;
        var linkEnd = cell.IndexOf("\">");
        if (linkEnd != -1)
          link = cell.Substring(linkStart, linkEnd - linkStart).Replace("&amp;", "&");
      }
      return link;
    }

    private void UpdateHints()
    {
      var sw = new StreamWriter(File.OpenWrite(autoFile));
      foreach (string hint in autoDrugs)
        sw.WriteLine(hint);
      sw.Close();
    }

    void CheckListButton(ListBox lst, Button button)
    {
      button.Enabled = lst.SelectedIndex != -1;
    }

    void EnableSetButtons(bool enable)
    {
      btnClear.Enabled = enable;
      btnProcess.Enabled = enable;
    }

    List<DrugInfo> drugs;

    /// <summary>
    /// Возвращет код тела таблицы
    /// </summary>
    /// <param name="stream">Поток с кодом HTML</param>
    /// <param name="tableTag">Открывающий тег таблицы</param>
    /// <returns>Код тела таблицы</returns>
    string GetTableCode(Stream stream, string tableTag)
    {
      var code = String.Empty;
      var sr = new StreamReader(stream);
      var html = sr.ReadToEnd();
      sr.Close();
      var tableStart = html.IndexOf(tableTag);
      if (tableStart != -1)
      {
        var tbodyPos = html.IndexOf("<tbody>", tableStart);
        var tableEnd = html.IndexOf("</table>", tbodyPos);
        code = html.Substring(tbodyPos, tableEnd - tbodyPos);
      }
      return code;
    }

    /// <summary>
    /// Получает цены на лекарство
    /// </summary>
    /// <param name="pstream">Поток с ценами</param>
    /// <returns>Список цен</returns>
    List<DrugPrice> GetPrices(Stream pstream)
    {
      var prices = new List<DrugPrice>();
      var tableCode = GetTableCode(pstream, "<table class=\"drug_result\"");
      var rows = GetRows(tableCode);
      DrugPrice dp;
      for (int i = 0; i < rows.Length - 2; i++)
      {
        var cells = GetCells(rows[i]); //ячейки
        dp = new DrugPrice {
          Drug = cells[2],
          Price = Decimal.Parse(cells[4]),
          Address = cells[5]
        };
        prices.Add(dp);
      }
      return prices;
    }

    ResultForm resultForm;

    private void bg_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
    {
      if (e.Error != null)
        MessageBox.Show(e.Error.Message);
      else
        if (e.Cancelled)
          MessageBox.Show("Поиск отменён");
        else
        {
          var results = (List<DrugSet>)e.Result;
          if (results.Count == 0)
            MessageBox.Show("Ни в одной аптеке нет заданного сочетания лекарств"); 
          else
            if (resultForm == null)
              resultForm = new ResultForm();
            resultForm.SetResults(results);
            resultForm.ShowDialog(this);
        }
    }
    
  }
}