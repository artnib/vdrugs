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
      this.button1 = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.lstDrugs = new System.Windows.Forms.ListBox();
      this.button2 = new System.Windows.Forms.Button();
      this.lstOptions = new System.Windows.Forms.ListBox();
      this.btnCheck = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
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
      this.tbDrug.TextChanged += new System.EventHandler(this.tbDrug_TextChanged);
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
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(324, 116);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 2;
      this.button1.Text = "Добавить";
      this.button1.UseVisualStyleBackColor = true;
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
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(327, 245);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 23);
      this.button2.TabIndex = 5;
      this.button2.Text = "Удалить";
      this.button2.UseVisualStyleBackColor = true;
      // 
      // lstOptions
      // 
      this.lstOptions.FormattingEnabled = true;
      this.lstOptions.Location = new System.Drawing.Point(12, 84);
      this.lstOptions.Name = "lstOptions";
      this.lstOptions.Size = new System.Drawing.Size(297, 82);
      this.lstOptions.TabIndex = 6;
      // 
      // btnCheck
      // 
      this.btnCheck.Enabled = false;
      this.btnCheck.Location = new System.Drawing.Point(324, 30);
      this.btnCheck.Name = "btnCheck";
      this.btnCheck.Size = new System.Drawing.Size(75, 23);
      this.btnCheck.TabIndex = 7;
      this.btnCheck.Text = "Уточнить";
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
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(413, 412);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.btnCheck);
      this.Controls.Add(this.lstOptions);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.lstDrugs);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.tbDrug);
      this.Name = "Form1";
      this.Text = "Поиск лекарств";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox tbDrug;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ListBox lstDrugs;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.ListBox lstOptions;
    private System.Windows.Forms.Button btnCheck;
    private System.Windows.Forms.Label label3;
  }
}

