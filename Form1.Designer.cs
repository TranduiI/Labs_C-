namespace laba6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemBySymbols = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemByWord = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonConverter = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelSymbols = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelLines = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelStatus = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(39, 60);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(465, 238);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(550, 70);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(202, 118);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripButtonConverter});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(764, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItemSaveAs});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ShowDropDownArrow = false;
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(40, 22);
            this.toolStripDropDownButton1.Text = "Файл";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItem1.Text = "Открыть";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItemOpen_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItem2.Text = "Сохранить";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItemSave_Click);
            // 
            // toolStripMenuItemSaveAs
            // 
            this.toolStripMenuItemSaveAs.Name = "toolStripMenuItemSaveAs";
            this.toolStripMenuItemSaveAs.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItemSaveAs.Text = "Сохранить как...";
            this.toolStripMenuItemSaveAs.Click += new System.EventHandler(this.ToolStripMenuItemSaveAs_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemBySymbols,
            this.toolStripMenuItemByWord});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.ShowDropDownArrow = false;
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(46, 22);
            this.toolStripDropDownButton2.Text = "Поиск";
            this.toolStripDropDownButton2.ToolTipText = "Поиск";
            // 
            // toolStripMenuItemBySymbols
            // 
            this.toolStripMenuItemBySymbols.Name = "toolStripMenuItemBySymbols";
            this.toolStripMenuItemBySymbols.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItemBySymbols.Text = "По сочетанию букв";
            this.toolStripMenuItemBySymbols.Click += new System.EventHandler(this.ToolStripMenuItemBySymbols_Click);
            // 
            // toolStripMenuItemByWord
            // 
            this.toolStripMenuItemByWord.Name = "toolStripMenuItemByWord";
            this.toolStripMenuItemByWord.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItemByWord.Text = "По слову";
            this.toolStripMenuItemByWord.Click += new System.EventHandler(this.ToolStripMenuItemByWord_Click);
            // 
            // toolStripButtonConverter
            // 
            this.toolStripButtonConverter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonConverter.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonConverter.Image")));
            this.toolStripButtonConverter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonConverter.Name = "toolStripButtonConverter";
            this.toolStripButtonConverter.Size = new System.Drawing.Size(109, 22);
            this.toolStripButtonConverter.Text = "Обработка файла";
            this.toolStripButtonConverter.Click += new System.EventHandler(this.toolStripButtonConverter_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelSymbols,
            this.toolStripLabelLines,
            this.toolStripLabelStatus});
            this.toolStrip2.Location = new System.Drawing.Point(0, 346);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(764, 25);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabelSymbols
            // 
            this.toolStripLabelSymbols.Name = "toolStripLabelSymbols";
            this.toolStripLabelSymbols.Size = new System.Drawing.Size(82, 22);
            this.toolStripLabelSymbols.Text = "Число знаков";
            // 
            // toolStripLabelLines
            // 
            this.toolStripLabelLines.Name = "toolStripLabelLines";
            this.toolStripLabelLines.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabelLines.Text = "Строк";
            // 
            // toolStripLabelStatus
            // 
            this.toolStripLabelStatus.Name = "toolStripLabelStatus";
            this.toolStripLabelStatus.Size = new System.Drawing.Size(43, 22);
            this.toolStripLabelStatus.Text = "Статус";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 371);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripLabel toolStripLabelSymbols;
        private System.Windows.Forms.ToolStripLabel toolStripLabelLines;
        private System.Windows.Forms.ToolStripLabel toolStripLabelStatus;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveAs;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBySymbols;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemByWord;
        private System.Windows.Forms.ToolStripButton toolStripButtonConverter;
    }
}

