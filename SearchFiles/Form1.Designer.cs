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
         this.SuspendLayout();
         // 
         // tSearchMask
         // 
         this.tSearchMask.Location = new System.Drawing.Point(12, 40);
         this.tSearchMask.Name = "tSearchMask";
         this.tSearchMask.Size = new System.Drawing.Size(694, 20);
         this.tSearchMask.TabIndex = 0;
         // 
         // bSearch
         // 
         this.bSearch.Location = new System.Drawing.Point(713, 63);
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
         this.tPath.Location = new System.Drawing.Point(12, 13);
         this.tPath.Name = "tPath";
         this.tPath.ReadOnly = true;
         this.tPath.Size = new System.Drawing.Size(306, 20);
         this.tPath.TabIndex = 2;
         // 
         // bPathSearch
         // 
         this.bPathSearch.Location = new System.Drawing.Point(324, 11);
         this.bPathSearch.Name = "bPathSearch";
         this.bPathSearch.Size = new System.Drawing.Size(75, 23);
         this.bPathSearch.TabIndex = 3;
         this.bPathSearch.Text = "Обзор";
         this.bPathSearch.UseVisualStyleBackColor = true;
         this.bPathSearch.Click += new System.EventHandler(this.bPathSearch_Click);
         // 
         // tvResultSearch
         // 
         this.tvResultSearch.Location = new System.Drawing.Point(12, 100);
         this.tvResultSearch.Name = "tvResultSearch";
         this.tvResultSearch.Size = new System.Drawing.Size(351, 319);
         this.tvResultSearch.TabIndex = 4;
         // 
         // tSearchContent
         // 
         this.tSearchContent.Location = new System.Drawing.Point(12, 66);
         this.tSearchContent.Name = "tSearchContent";
         this.tSearchContent.Size = new System.Drawing.Size(694, 20);
         this.tSearchContent.TabIndex = 5;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.tSearchContent);
         this.Controls.Add(this.tvResultSearch);
         this.Controls.Add(this.bPathSearch);
         this.Controls.Add(this.tPath);
         this.Controls.Add(this.bSearch);
         this.Controls.Add(this.tSearchMask);
         this.Name = "Form1";
         this.Text = "Поиск по файлам";
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
    }
}

