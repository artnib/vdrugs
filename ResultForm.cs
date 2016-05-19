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
      foreach (DrugSet ds in drugSets)
        dgvResults.Rows.Add(new object[] { ds.Total, ds.Address });
    }

    List<DrugSet> drugSets;
  }
}