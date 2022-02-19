namespace EnhancedNaumenControls
{
    partial class RunnerPanel
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
            this.bCancel = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.cbScripts = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // bCancel
            // 
            this.bCancel.Dock = System.Windows.Forms.DockStyle.Top;
            this.bCancel.Location = new System.Drawing.Point(0, 44);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(161, 23);
            this.bCancel.TabIndex = 4;
            this.bCancel.Text = "Отмена";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bStart
            // 
            this.bStart.Dock = System.Windows.Forms.DockStyle.Top;
            this.bStart.Location = new System.Drawing.Point(0, 21);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(161, 23);
            this.bStart.TabIndex = 3;
            this.bStart.Text = "Старт";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // cbScripts
            // 
            this.cbScripts.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbScripts.FormattingEnabled = true;
            this.cbScripts.Location = new System.Drawing.Point(0, 0);
            this.cbScripts.Name = "cbScripts";
            this.cbScripts.Size = new System.Drawing.Size(161, 21);
            this.cbScripts.TabIndex = 2;
            this.cbScripts.SelectionChangeCommitted += new System.EventHandler(this.cbScripts_SelectionChangeCommitted);
            // 
            // RunnerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.cbScripts);
            this.Name = "RunnerPanel";
            this.Size = new System.Drawing.Size(161, 69);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.ComboBox cbScripts;
    }
}
