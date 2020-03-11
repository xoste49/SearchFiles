namespace SearchFiles
{
   partial class Form1
   {
      /// <summary>
      /// Обязательная переменная конструктора.
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
      /// Требуемый метод для поддержки конструктора — не изменяйте 
      /// содержимое этого метода с помощью редактора кода.
      /// </summary>
      private void InitializeComponent()
      {
         this.tSearchMask = new System.Windows.Forms.TextBox();
         this.bSearch = new System.Windows.Forms.Button();
         this.fBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
         this.tPath = new System.Windows.Forms.TextBox();
         this.bPathSearch = new System.Windows.Forms.Button();
         this.tvResultSearch = new System.Windows.Forms.TreeView();
         this.tSearchContent = new System.Windows.Forms.TextBox();
         this.lPath = new System.Windows.Forms.Label();
         this.lMask = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.statusStrip1 = new System.Windows.Forms.StatusStrip();
         this.tsslCountFiles = new System.Windows.Forms.ToolStripStatusLabel();
         this.statusStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // tSearchMask
         // 
         this.tSearchMask.Location = new System.Drawing.Point(11, 70);
         this.tSearchMask.Name = "tSearchMask";
         this.tSearchMask.Size = new System.Drawing.Size(695, 20);
         this.tSearchMask.TabIndex = 0;
         this.tSearchMask.TextChanged += new System.EventHandler(this.tSearchMask_TextChanged);
         // 
         // bSearch
         // 
         this.bSearch.Location = new System.Drawing.Point(713, 116);
         this.bSearch.Name = "bSearch";
         this.bSearch.Size = new System.Drawing.Size(75, 23);
         this.bSearch.TabIndex = 1;
         this.bSearch.Text = "Поиск";
         this.bSearch.UseVisualStyleBackColor = true;
         this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
         // 
         // fBrowserDialog
         // 
         this.fBrowserDialog.ShowNewFolderButton = false;
         // 
         // tPath
         // 
         this.tPath.Cursor = System.Windows.Forms.Cursors.IBeam;
         this.tPath.Location = new System.Drawing.Point(11, 27);
         this.tPath.Name = "tPath";
         this.tPath.ReadOnly = true;
         this.tPath.Size = new System.Drawing.Size(695, 20);
         this.tPath.TabIndex = 2;
         this.tPath.TextChanged += new System.EventHandler(this.tPath_TextChanged);
         // 
         // bPathSearch
         // 
         this.bPathSearch.Location = new System.Drawing.Point(713, 25);
         this.bPathSearch.Name = "bPathSearch";
         this.bPathSearch.Size = new System.Drawing.Size(75, 23);
         this.bPathSearch.TabIndex = 3;
         this.bPathSearch.Text = "Обзор";
         this.bPathSearch.UseVisualStyleBackColor = true;
         this.bPathSearch.Click += new System.EventHandler(this.bPathSearch_Click);
         // 
         // tvResultSearch
         // 
         this.tvResultSearch.Location = new System.Drawing.Point(11, 145);
         this.tvResultSearch.Name = "tvResultSearch";
         this.tvResultSearch.Size = new System.Drawing.Size(777, 437);
         this.tvResultSearch.TabIndex = 4;
         // 
         // tSearchContent
         // 
         this.tSearchContent.Location = new System.Drawing.Point(11, 118);
         this.tSearchContent.Name = "tSearchContent";
         this.tSearchContent.Size = new System.Drawing.Size(695, 20);
         this.tSearchContent.TabIndex = 5;
         this.tSearchContent.TextChanged += new System.EventHandler(this.tSearchContent_TextChanged);
         // 
         // lPath
         // 
         this.lPath.AutoSize = true;
         this.lPath.Location = new System.Drawing.Point(12, 9);
         this.lPath.Name = "lPath";
         this.lPath.Size = new System.Drawing.Size(108, 13);
         this.lPath.TabIndex = 6;
         this.lPath.Text = "Каталог для поиска";
         // 
         // lMask
         // 
         this.lMask.AutoSize = true;
         this.lMask.Location = new System.Drawing.Point(12, 54);
         this.lMask.Name = "lMask";
         this.lMask.Size = new System.Drawing.Size(188, 13);
         this.lMask.TabIndex = 7;
         this.lMask.Text = "Шаблон файлов для поиска (маска)";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 102);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(97, 13);
         this.label1.TabIndex = 8;
         this.label1.Text = "Текст для поиска";
         // 
         // statusStrip1
         // 
         this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslCountFiles});
         this.statusStrip1.Location = new System.Drawing.Point(0, 585);
         this.statusStrip1.Name = "statusStrip1";
         this.statusStrip1.Size = new System.Drawing.Size(800, 22);
         this.statusStrip1.TabIndex = 9;
         this.statusStrip1.Text = "statusStrip1";
         // 
         // tsslCountFiles
         // 
         this.tsslCountFiles.Name = "tsslCountFiles";
         this.tsslCountFiles.Size = new System.Drawing.Size(0, 17);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 607);
         this.Controls.Add(this.statusStrip1);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.lMask);
         this.Controls.Add(this.lPath);
         this.Controls.Add(this.tSearchContent);
         this.Controls.Add(this.tvResultSearch);
         this.Controls.Add(this.bPathSearch);
         this.Controls.Add(this.tPath);
         this.Controls.Add(this.bSearch);
         this.Controls.Add(this.tSearchMask);
         this.Name = "Form1";
         this.Text = "Поиск по файлам";
         this.statusStrip1.ResumeLayout(false);
         this.statusStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

        #endregion

        private System.Windows.Forms.TextBox tSearchMask;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.FolderBrowserDialog fBrowserDialog;
        private System.Windows.Forms.TextBox tPath;
        private System.Windows.Forms.Button bPathSearch;
        private System.Windows.Forms.TreeView tvResultSearch;
        private System.Windows.Forms.TextBox tSearchContent;
        private System.Windows.Forms.Label lPath;
        private System.Windows.Forms.Label lMask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslCountFiles;
    }
}

