namespace NaumenControls.Controls
{
    partial class XchangeDataPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XchangeDataPanel));
            this.dataPanel = new NaumenControls.Controls.CustomDataPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbExec = new System.Windows.Forms.ToolStripButton();
            this.tscbTaskSelector = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataPanel
            // 
            this.dataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPanel.Location = new System.Drawing.Point(0, 25);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Prepared = false;
            this.dataPanel.PreparingStructType = NaumenControls.Controls.StructType.LSNum;
            this.dataPanel.Size = new System.Drawing.Size(834, 481);
            this.dataPanel.StructType = NaumenControls.Controls.StructType.LSNum;
            this.dataPanel.TabIndex = 12;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExec,
            this.tscbTaskSelector});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(834, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbExec
            // 
            this.tsbExec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbExec.Image = ((System.Drawing.Image)(resources.GetObject("tsbExec.Image")));
            this.tsbExec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExec.Name = "tsbExec";
            this.tsbExec.Size = new System.Drawing.Size(73, 22);
            this.tsbExec.Text = "Выполнить";
            this.tsbExec.Click += new System.EventHandler(this.tsbExec_Click);
            // 
            // tscbTaskSelector
            // 
            this.tscbTaskSelector.Name = "tscbTaskSelector";
            this.tscbTaskSelector.Size = new System.Drawing.Size(200, 25);
            this.tscbTaskSelector.SelectedIndexChanged += new System.EventHandler(this.TscbTaskSelector_SelectedIndexChanged);
            // 
            // XchangeDataPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataPanel);
            this.Controls.Add(this.toolStrip1);
            this.Name = "XchangeDataPanel";
            this.Size = new System.Drawing.Size(834, 506);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomDataPanel dataPanel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbExec;
        private System.Windows.Forms.ToolStripComboBox tscbTaskSelector;
    }
}
