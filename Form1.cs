using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.IO;
using vdrugs.Properties;

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
      //прячем форму, чтобы не "прыгала" при восстановлении положения
      Visible = false;
      RestoreSettings();
      Visible = true;
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
      SaveSettings();
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
      btnCancel.Enabled = true;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      bg.CancelAsync();
      btnCancel.Enabled = false;
    }

    private void bg_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      Stream priceStream;
      var pharm = new Dictionary<string, List<DrugPrice>>();
      string pharmacy;
      string priceUrl;

      foreach (DrugInfo drug in drugs)
      {
        priceUrl = String.Format("{0}{1}", baseUrl, drug.FindLink);
        priceStream = wc.OpenRead(priceUrl);
        prices = new List<DrugPrice>();
        dups = new List<DrugPrice>();
        pageLinks = new List<string>();
        GetPrices(priceStream);
        foreach (DrugPrice dp in prices)
        {
          pharmacy = dp.Pharmacy;
          if (!pharm.ContainsKey(pharmacy))
            pharm.Add(pharmacy, new List<DrugPrice>());
          if (pharm[pharmacy].Find(p => p.Drug == dp.Drug) == null)
            pharm[pharmacy].Add(dp);
          else //в этой аптеке это лекарство есть по другой цене
            dups.Add(dp);
        }
      }
      DrugSet ds;
      var drugSets = new List<DrugSet>();
      foreach(string addr in pharm.Keys)
        if (pharm[addr].Count == drugs.Count) //есть все нужные лекарства
      {
        ds = new DrugSet
        {
          Drugs = pharm[addr]
        };
        drugSets.Add(ds);
      }
      
      foreach (DrugPrice dup in dups)
      {
        var twins = drugSets.FindAll(d => d.Pharmacy == dup.Pharmacy);
        foreach (DrugSet twin in twins)
        {
          ds = new DrugSet { Drugs = new List<DrugPrice>(twin.Drugs.Count) };
          foreach (DrugPrice dprice in twin.Drugs)
          {
            if (dprice.Drug == dup.Drug) //дубликат с другой ценой
            {
              //делаем копию
              ds.Drugs.Add(new DrugPrice
                           {
                             Drug = dprice.Drug,
                             Address = dprice.Address,
                             Pharmacy = dprice.Pharmacy,
                             Phone = dprice.Phone,
                             Price = dup.Price
                           });
            }
            else //остальные лекарства
              ds.Drugs.Add(dprice); //используем ссылку
          }
          drugSets.Add(ds);
        }
      }
      
      e.Result = drugSets;
    }
    
    private void bg_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
    {
      if (e.Error != null)
      {
        ShowErrorMsg(e.Error);
      }
      else
        if (e.Cancelled)
          MessageBox.Show("Поиск отменён");
        else
        {
          var results = (List<DrugSet>)e.Result;
          if (results.Count == 0)
            MessageBox.Show("Ни в одной аптеке нет заданного сочетания лекарств");
          else
          {
            if (resultForm == null)
              resultForm = new ResultForm();
            resultForm.SetResults(results);
            resultForm.ShowDialog(this);
          }
        }
        btnProcess.Enabled = true;
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
      try
      {
        var drugStream = wc.OpenRead(url);
        var options = GetOptions(drugStream);
        if (options.Count == 0) //ничего не найдено
        {
          lbNotFound.Visible = true;
          return;
        }
        lbNotFound.Visible = false;
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
      catch (Exception we)
      {
        ShowErrorMsg(we);
      }
    }

    /// <summary>
    /// Возвращает сообщение об ошибке
    /// </summary>
    /// <param name="we">Исключение</param>
    /// <returns>Сообщение об ошибке</returns>
    static string GetErrorMsg(Exception e)
    {
      var msg = e.Message;
      const string INET = " Проверьте исправность подключения к Интернету.";
      const string REPEAT = " Попробуйте повторить поиск.";
      if (e is WebException)
      {
        var we = (WebException)e;
        switch (we.Status)
        {
          case WebExceptionStatus.NameResolutionFailure:
            msg = String.Format("Не удалось разрешить имя '{0}'.", baseUrl) + INET;
            break;
          case WebExceptionStatus.ConnectFailure:
            msg = "Не удалось подключиться к серверу." + REPEAT;
            break;
        }
      }
      else
        if (e is IOException)
        {
          msg = "Ошибка чтения веб-страницы сайта." + INET + REPEAT;
        }
        else
          msg = e.Message;
      return msg;
    }
    
    /// <summary>
    /// Показывает сообщение об ошибке
    /// </summary>
    /// <param name="e">Исключение</param>
    void ShowErrorMsg(Exception e)
    {
      MessageBox.Show(GetErrorMsg(e), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    /// <summary>
    /// Возвращает список вариантов выпуска лекарства
    /// </summary>
    /// <param name="ostream">Поток веб-страницы с формами выпуска лекарства</param>
    /// <returns>Список вариантов выпуска лекарства</returns>
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
        var cells = Html.GetCells(rows[i]);
        di = new DrugInfo {
          Name = tbDrug.Text,
          FindLink = GetFindLink(cells[1]),
          Option = cells[2]
        };
        options.Add(di);
      }
      return options;
    }
    
    /// <summary>
    /// Возвращает ссылку на поиск лекарства
    /// </summary>
    /// <param name="cell">Ячейка со ссылкой</param>
    /// <returns>Относительная ссылка</returns>
    static string GetFindLink(string cell)
    {
      var link = String.Empty;
      var hrefPos = cell.IndexOf(Html.HrefStart);
      if (hrefPos != -1)
      {
        var linkStart = hrefPos + Html.HrefStart.Length;
        var linkEnd = cell.IndexOf(Html.Quote, linkStart);
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
    static string GetTableCode(Stream stream, string tableTag)
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
    void GetPrices(Stream pstream)
    {
      var tableCode = GetTableCode(pstream, "<table class=\"drug_result\"");
      var rows = Html.GetRows(tableCode);
      DrugPrice dp;
      for (int i = 0; i < rows.Length - 2; i++)
      {
        var cells = Html.GetCells(rows[i]);
        dp = new DrugPrice {
          Pharmacy = Html.RemoveTags(cells[0]),
          Drug = cells[2],
          Price = Decimal.Parse(cells[4]),
          Address = cells[5],
          Phone = cells[6]
        };
        prices.Add(dp);
      }
      if (pageLinks.Count > 0) return;
      //последняя строка таблицы со ссылками на страницы с ценами
      var lastRow = rows[rows.Length - 2];
      int hrefPos = 0;
      int quotePos = 0;
      int linkStart;
      string nextLink;
      while ((hrefPos = lastRow.IndexOf(Html.HrefStart, quotePos)) != -1)
      {
        linkStart = hrefPos + Html.HrefStart.Length;
        quotePos = lastRow.IndexOf(Html.Quote, linkStart);
        if (quotePos != -1)
        {
          nextLink = lastRow.Substring(linkStart, quotePos - linkStart);
          if (!pageLinks.Contains(nextLink))
          {
            pageLinks.Add(nextLink);
            GetPrices(wc.OpenRead(baseUrl + nextLink));
          }
          else
            break;
        }
      }
    }

    /// <summary>
    /// Все цены на лекарство
    /// </summary>
    List<DrugPrice> prices;

    /// <summary>
    /// Альтернативные цены на одно и то же лекарство в одной аптеке
    /// </summary>
    List<DrugPrice> dups;

    /// <summary>
    /// Ссылки на страницы с ценами
    /// </summary>
    List<string> pageLinks;

    ResultForm resultForm;

    void SaveSettings()
    {
      Settings.Default.MainLeft = Left;
      Settings.Default.MainTop = Top;
      Settings.Default.Save();
    }

    void RestoreSettings()
    {
      Left = Settings.Default.MainLeft;
      Top = Settings.Default.MainTop;
    }

  }
}