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
      ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
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
      this.dgvResults.Name = "dgvResults";
      this.dgvResults.ReadOnly = true;
      this.dgvResults.Size = new System.Drawing.Size(524, 447);
      this.dgvResults.TabIndex = 0;
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
      // Results
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(524, 447);
      this.Controls.Add(this.dgvResults);
      this.Name = "Results";
      this.Text = "Результаты поиска";
      ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView dgvResults;
    private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
    private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
  }
}