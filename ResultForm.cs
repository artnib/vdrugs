using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
  }
}