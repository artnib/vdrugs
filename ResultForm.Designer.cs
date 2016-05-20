namespace vdrugs
{
  partial class ResultForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.dgvResults = new System.Windows.Forms.DataGridView();
      this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dgvDrugs = new System.Windows.Forms.DataGridView();
      this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.colAddress2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colPharmacy2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgvDrugs)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.SuspendLayout();
      // 
      // dgvResults
      // 
      this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTotal,
            this.colAddress});
      this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvResults.Location = new System.Drawing.Point(0, 0);
      this.dgvResults.MultiSelect = false;
      this.dgvResults.Name = "dgvResults";
      this.dgvResults.ReadOnly = true;
      this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvResults.Size = new System.Drawing.Size(524, 223);
      this.dgvResults.TabIndex = 0;
      this.dgvResults.SelectionChanged += new System.EventHandler(this.dgvResults_SelectionChanged);
      // 
      // colTotal
      // 
      this.colTotal.HeaderText = "Стоимость";
      this.colTotal.Name = "colTotal";
      this.colTotal.ReadOnly = true;
      this.colTotal.Width = 87;
      // 
      // colAddress
      // 
      this.colAddress.HeaderText = "Адрес аптеки";
      this.colAddress.Name = "colAddress";
      this.colAddress.ReadOnly = true;
      this.colAddress.Width = 101;
      // 
      // dgvDrugs
      // 
      this.dgvDrugs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      this.dgvDrugs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvDrugs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPrice,
            this.colName,
            this.colAddress2,
            this.colPharmacy2});
      this.dgvDrugs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvDrugs.Location = new System.Drawing.Point(0, 0);
      this.dgvDrugs.MultiSelect = false;
      this.dgvDrugs.Name = "dgvDrugs";
      this.dgvDrugs.ReadOnly = true;
      this.dgvDrugs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvDrugs.Size = new System.Drawing.Size(524, 220);
      this.dgvDrugs.TabIndex = 1;
      // 
      // colPrice
      // 
      this.colPrice.HeaderText = "Цена";
      this.colPrice.Name = "colPrice";
      this.colPrice.ReadOnly = true;
      this.colPrice.Width = 58;
      // 
      // colName
      // 
      this.colName.HeaderText = "Лекарство";
      this.colName.Name = "colName";
      this.colName.ReadOnly = true;
      this.colName.Width = 87;
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.dgvResults);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.dgvDrugs);
      this.splitContainer1.Size = new System.Drawing.Size(524, 447);
      this.splitContainer1.SplitterDistance = 223;
      this.splitContainer1.TabIndex = 2;
      // 
      // colAddress2
      // 
      this.colAddress2.HeaderText = "Адрес";
      this.colAddress2.Name = "colAddress2";
      this.colAddress2.ReadOnly = true;
      this.colAddress2.Width = 63;
      // 
      // colPharmacy2
      // 
      this.colPharmacy2.HeaderText = "Аптека";
      this.colPharmacy2.Name = "colPharmacy2";
      this.colPharmacy2.ReadOnly = true;
      this.colPharmacy2.Width = 68;
      // 
      // ResultForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(524, 447);
      this.Controls.Add(this.splitContainer1);
      this.Name = "ResultForm";
      this.Text = "Результаты поиска";
      ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgvDrugs)).EndInit();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView dgvResults;
    private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
    private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
    private System.Windows.Forms.DataGridView dgvDrugs;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
    private System.Windows.Forms.DataGridViewTextBoxColumn colName;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.DataGridViewTextBoxColumn colAddress2;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPharmacy2;
  }
}