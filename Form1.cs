﻿using System;
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
        btnClear.Enabled = true;
      }
      else
        foreach (DrugInfo di in options)
          lstOptions.Items.Add(di);
    }

    List<DrugInfo> GetOptions(Stream ostream)
    {
      var options = new List<DrugInfo>();
      var sr = new StreamReader(ostream);
      var html = sr.ReadToEnd();
      sr.Close();
      const string searchTable = "<table id=\"searchTable\" class=\"drug_result\"";
      var tableStart = html.IndexOf(searchTable);
      if (tableStart != -1)
      {
        var tbodyPos = html.IndexOf("<tbody>", tableStart);
        var tableEnd = html.IndexOf("</table>", tbodyPos);
        var tableCode = html.Substring(tbodyPos, tableEnd - tbodyPos);
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
      }
      return options;
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
          return cell.Substring(linkStart, linkEnd - linkStart);
      }
      return link;
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

    private void btnAdd_Click(object sender, EventArgs e)
    {
      lstDrugs.Items.Add(lstOptions.SelectedItem);
      lstOptions.Items.RemoveAt(lstOptions.SelectedIndex);
      btnClear.Enabled = true;
    }

    private void lstOptions_SelectedIndexChanged(object sender, EventArgs e)
    {
      CheckListButton(lstOptions, btnAdd);
    }

    private void lstDrugs_SelectedIndexChanged(object sender, EventArgs e)
    {
      CheckListButton(lstDrugs, btnDel);
    }

    void CheckListButton(ListBox lst, Button button)
    {
      button.Enabled = lst.SelectedIndex != -1;
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      lstDrugs.Items.Clear();
    }

    private void btnDel_Click(object sender, EventArgs e)
    {
      lstDrugs.Items.RemoveAt(lstDrugs.SelectedIndex);
      btnClear.Enabled = lstDrugs.Items.Count > 0;
    }

    private void tbDrug_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
        CheckDrug();
    }
  }
}