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
    //http://analit.net/apteka/Main/SearchResult?filter.query=%D0%BB%D0%B8%D0%B7%D0%BE%D0%B1%D0%B0%D0%BA%D1%82&filter.region=1099511627776

    private void btnCheck_Click(object sender, EventArgs e)
    {
      CheckDrug();
    }

    private void tbDrug_TextChanged(object sender, EventArgs e)
    {
      btnCheck.Enabled = tbDrug.Text.Length > 0;
    }

    string appDir;
    string drugFile;
    string autoFile;
    int hintCount;

    private void Form1_Load(object sender, EventArgs e)
    {
      appDir = Path.GetDirectoryName(Application.ExecutablePath);
      drugFile = Path.Combine(appDir, "drug.htm");
      autoFile = Path.Combine(appDir, "hints.txt");
      if (File.Exists(autoFile))
        autoDrugs.AddRange(File.ReadAllLines(autoFile));
      hintCount = autoDrugs.Count;
    }

    private void CheckDrug()
    {
      const String drugFmt = "http://analit.net/apteka/Main/SearchResult?filter.query={0}&filter.region=1099511627776";
      var url = String.Format(drugFmt, tbDrug.Text);
      var drugStream = wc.OpenRead(url);
      var options = GetOptions(drugStream);
      if (options.Count > 0 && !autoDrugs.Contains(tbDrug.Text))
        autoDrugs.Add(tbDrug.Text);
      foreach (DrugInfo di in options)
        lstOptions.Items.Add(di.Option);
    }

    List<DrugInfo> GetOptions(Stream ostream)
    {
      var options = new List<DrugInfo>();
      var sr = new StreamReader(ostream);
      var html = sr.ReadToEnd();
      sr.Close();
      var tableStart = html.IndexOf("<table id=\"searchTable\" class=\"drug_result\"");
      var tbodyPos = html.IndexOf("<tbody>", tableStart);
      if (tableStart != -1 && tbodyPos != -1)
      {
        var tableEnd = html.IndexOf("</table>", tbodyPos);
        var tableCode = html.Substring(tbodyPos, tableEnd - tbodyPos);
        var tr = new string[] { "</tr>" };
        var td=new string[] { "</td>" };
        var rows = tableCode.Split(tr, StringSplitOptions.None);
        DrugInfo di;
        for (int i = 0; i < rows.Length - 2; i++)
        {
          var cells = rows[i].Split(td, StringSplitOptions.None);
          di = new DrugInfo {
            Option = cells[2].Trim().Replace("<td>", String.Empty) };
          options.Add(di);
        }
      }
      return options;
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (autoDrugs.Count > hintCount)
        UpdateHints();
    }

    private void UpdateHints()
    {
      var sw = new StreamWriter(File.OpenWrite(autoFile));
      foreach (string hint in autoDrugs)
        sw.WriteLine(hint);
      sw.Close();
    }
  }
}