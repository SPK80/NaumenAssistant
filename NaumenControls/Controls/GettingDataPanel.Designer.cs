namespace NaumenControls.Controls
{
    partial class GettingDataPanel
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GettingDataPanel));
            this.dataPanel = new CustomDataPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbReceiveComments = new System.Windows.Forms.ToolStripButton();
            this.tsbReceiveConnections = new System.Windows.Forms.ToolStripButton();
            this.tsbReceiveFiles = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataPanel
            // 
            this.dataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPanel.Location = new System.Drawing.Point(0, 25);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(687, 331);
            this.dataPanel.StructType = StructType.LSNum;
            this.dataPanel.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbReceiveComments,
            this.tsbReceiveConnections,
            this.tsbReceiveFiles});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(687, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbReceiveComments
            // 
            this.tsbReceiveComments.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbReceiveComments.Image = ((System.Drawing.Image)(resources.GetObject("tsbReceiveComments.Image")));
            this.tsbReceiveComments.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReceiveComments.Name = "tsbReceiveComments";
            this.tsbReceiveComments.Size = new System.Drawing.Size(145, 22);
            this.tsbReceiveComments.Text = "Получить Комментарии";
            this.tsbReceiveComments.Click += new System.EventHandler(this.tsbReceiveComments_Click);
            // 
            // tsbReceiveConnections
            // 
            this.tsbReceiveConnections.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbReceiveConnections.Image = ((System.Drawing.Image)(resources.GetObject("tsbReceiveConnections.Image")));
            this.tsbReceiveConnections.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReceiveConnections.Name = "tsbReceiveConnections";
            this.tsbReceiveConnections.Size = new System.Drawing.Size(121, 22);
            this.tsbReceiveConnections.Text = "Получить Привязки";
            this.tsbReceiveConnections.Click += new System.EventHandler(this.tsbReceiveConnections_Click);
            // 
            // tsbReceiveFiles
            // 
            this.tsbReceiveFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbReceiveFiles.Image = ((System.Drawing.Image)(resources.GetObject("tsbReceiveFiles.Image")));
            this.tsbReceiveFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReceiveFiles.Name = "tsbReceiveFiles";
            this.tsbReceiveFiles.Size = new System.Drawing.Size(106, 22);
            this.tsbReceiveFiles.Text = "Получить Файлы";
            this.tsbReceiveFiles.Click += new System.EventHandler(this.tsbReceiveFiles_Click);
            // 
            // GettingDataPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataPanel);
            this.Controls.Add(this.toolStrip1);
            this.Name = "GettingDataPanel";
            this.Size = new System.Drawing.Size(687, 356);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomDataPanel dataPanel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbReceiveComments;
        private System.Windows.Forms.ToolStripButton tsbReceiveConnections;
        private System.Windows.Forms.ToolStripButton tsbReceiveFiles;
    }
}
