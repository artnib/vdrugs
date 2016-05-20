using System;
using System.Collections.Generic;
using System.Windows.Forms;
using vdrugs.Properties;

namespace vdrugs
{
  public partial class ResultForm : Form
  {
    public ResultForm()
    {
      InitializeComponent();
    }

    public void SetResults(List<DrugSet> drugSets)
    {
      this.drugSets = drugSets;
      dgvResults.Rows.Clear();
      int index;
      foreach (DrugSet ds in drugSets)
      {
        index = dgvResults.Rows.Add(new object[] {
          ds.Total, ds.Address,ds.Pharmacy });
        dgvResults.Rows[index].Tag = ds;
      }
    }

    List<DrugSet> drugSets;

    private void dgvResults_SelectionChanged(object sender, EventArgs e)
    {
      if (dgvResults.SelectedRows.Count > 0)
      {
        var ds = (DrugSet)dgvResults.SelectedRows[0].Tag;
        dgvDrugs.Rows.Clear();
        foreach (DrugPrice dp in ds.Drugs)
          dgvDrugs.Rows.Add(new object[] {
            dp.Price, dp.Drug, dp.Address, dp.Pharmacy });
      }
    }

    private void ResultForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      var maximized = WindowState == FormWindowState.Maximized;
      Settings.Default.ResultSplitter = splitContainer1.SplitterDistance;
      Settings.Default.ResultMaximized = maximized;
      if (!maximized)
      {
        Settings.Default.ResultHeight = Height;
        Settings.Default.ResultLeft = Left;
        Settings.Default.ResultTop = Top;
        Settings.Default.ResultWidth = Width;
      }
    }

    private void ResultForm_Load(object sender, EventArgs e)
    {
      Visible = false;
      var maximized = Settings.Default.ResultMaximized;
      if (maximized)
        WindowState = FormWindowState.Maximized;
      else
      {
        Left = Settings.Default.ResultLeft;
        Top = Settings.Default.ResultTop;
        Width = Settings.Default.ResultWidth;
        Height = Settings.Default.ResultHeight;
      }
      var distance = Settings.Default.ResultSplitter;
      splitContainer1.SplitterDistance = distance == 0 ? splitContainer1.SplitterDistance: distance;
      Visible = true;
    }
  }
}