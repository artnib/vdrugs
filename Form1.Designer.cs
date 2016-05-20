namespace vdrugs
{
  partial class Form1
  {
    /// <summary>
    /// Требуется переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Обязательный метод для поддержки конструктора - не изменяйте
    /// содержимое данного метода при помощи редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.tbDrug = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btnAdd = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.lstDrugs = new System.Windows.Forms.ListBox();
      this.btnDel = new System.Windows.Forms.Button();
      this.lstOptions = new System.Windows.Forms.ListBox();
      this.btnCheck = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.lbNotFound = new System.Windows.Forms.Label();
      this.btnClear = new System.Windows.Forms.Button();
      this.btnProcess = new System.Windows.Forms.Button();
      this.bg = new System.ComponentModel.BackgroundWorker();
      this.btnCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // tbDrug
      // 
      this.tbDrug.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.tbDrug.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
      this.tbDrug.Location = new System.Drawing.Point(12, 32);
      this.tbDrug.Name = "tbDrug";
      this.tbDrug.Size = new System.Drawing.Size(300, 20);
      this.tbDrug.TabIndex = 0;
      this.tbDrug.WordWrap = false;
      this.tbDrug.TextChanged += new System.EventHandler(this.tbDrug_TextChanged);
      this.tbDrug.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbDrug_KeyUp);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(62, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Лекарство";
      // 
      // btnAdd
      // 
      this.btnAdd.Enabled = false;
      this.btnAdd.Location = new System.Drawing.Point(324, 111);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(75, 23);
      this.btnAdd.TabIndex = 2;
      this.btnAdd.Text = "Добавить";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 194);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(89, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Набор лекарств";
      // 
      // lstDrugs
      // 
      this.lstDrugs.FormattingEnabled = true;
      this.lstDrugs.Location = new System.Drawing.Point(15, 210);
      this.lstDrugs.Name = "lstDrugs";
      this.lstDrugs.Size = new System.Drawing.Size(297, 108);
      this.lstDrugs.TabIndex = 4;
      this.lstDrugs.SelectedIndexChanged += new System.EventHandler(this.lstDrugs_SelectedIndexChanged);
      // 
      // btnDel
      // 
      this.btnDel.Enabled = false;
      this.btnDel.Location = new System.Drawing.Point(324, 237);
      this.btnDel.Name = "btnDel";
      this.btnDel.Size = new System.Drawing.Size(75, 23);
      this.btnDel.TabIndex = 5;
      this.btnDel.Text = "Удалить";
      this.btnDel.UseVisualStyleBackColor = true;
      this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
      // 
      // lstOptions
      // 
      this.lstOptions.FormattingEnabled = true;
      this.lstOptions.Location = new System.Drawing.Point(12, 84);
      this.lstOptions.Name = "lstOptions";
      this.lstOptions.Size = new System.Drawing.Size(297, 82);
      this.lstOptions.TabIndex = 6;
      this.lstOptions.SelectedIndexChanged += new System.EventHandler(this.lstOptions_SelectedIndexChanged);
      // 
      // btnCheck
      // 
      this.btnCheck.Enabled = false;
      this.btnCheck.Location = new System.Drawing.Point(324, 30);
      this.btnCheck.Name = "btnCheck";
      this.btnCheck.Size = new System.Drawing.Size(75, 23);
      this.btnCheck.TabIndex = 7;
      this.btnCheck.Text = "Найти";
      this.btnCheck.UseVisualStyleBackColor = true;
      this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 68);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(103, 13);
      this.label3.TabIndex = 8;
      this.label3.Text = "Варианты выпуска";
      // 
      // lbNotFound
      // 
      this.lbNotFound.AutoSize = true;
      this.lbNotFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lbNotFound.Location = new System.Drawing.Point(74, 16);
      this.lbNotFound.Name = "lbNotFound";
      this.lbNotFound.Size = new System.Drawing.Size(78, 13);
      this.lbNotFound.TabIndex = 9;
      this.lbNotFound.Text = "не найдено!";
      this.lbNotFound.Visible = false;
      // 
      // btnClear
      // 
      this.btnClear.Enabled = false;
      this.btnClear.Location = new System.Drawing.Point(324, 266);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(75, 23);
      this.btnClear.TabIndex = 10;
      this.btnClear.Text = "Очистить";
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // btnProcess
      // 
      this.btnProcess.AutoSize = true;
      this.btnProcess.Enabled = false;
      this.btnProcess.Location = new System.Drawing.Point(208, 340);
      this.btnProcess.Name = "btnProcess";
      this.btnProcess.Size = new System.Drawing.Size(104, 23);
      this.btnProcess.TabIndex = 11;
      this.btnProcess.Text = "Где всё купить?";
      this.btnProcess.UseVisualStyleBackColor = true;
      this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
      // 
      // bg
      // 
      this.bg.WorkerSupportsCancellation = true;
      this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
      this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
      // 
      // btnCancel
      // 
      this.btnCancel.Enabled = false;
      this.btnCancel.Location = new System.Drawing.Point(324, 340);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 12;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(413, 375);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnProcess);
      this.Controls.Add(this.btnClear);
      this.Controls.Add(this.lbNotFound);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.btnCheck);
      this.Controls.Add(this.lstOptions);
      this.Controls.Add(this.btnDel);
      this.Controls.Add(this.lstDrugs);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnAdd);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.tbDrug);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.Text = "Поиск лекарств в Воронеже";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox tbDrug;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ListBox lstDrugs;
    private System.Windows.Forms.Button btnDel;
    private System.Windows.Forms.ListBox lstOptions;
    private System.Windows.Forms.Button btnCheck;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label lbNotFound;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.Button btnProcess;
    private System.ComponentModel.BackgroundWorker bg;
    private System.Windows.Forms.Button btnCancel;
  }
}

