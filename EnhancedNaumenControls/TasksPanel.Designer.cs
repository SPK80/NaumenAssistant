namespace EnhancedNaumenControls
{
    partial class TasksPanel
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bCancel = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.cbTasks = new System.Windows.Forms.ComboBox();
            this.clbTasks = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.bCancel);
            this.splitContainer1.Panel1.Controls.Add(this.bStart);
            this.splitContainer1.Panel1.Controls.Add(this.cbTasks);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.clbTasks);
            this.splitContainer1.Size = new System.Drawing.Size(680, 70);
            this.splitContainer1.SplitterDistance = 168;
            this.splitContainer1.TabIndex = 15;
            // 
            // bCancel
            // 
            this.bCancel.Dock = System.Windows.Forms.DockStyle.Top;
            this.bCancel.Location = new System.Drawing.Point(0, 44);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(168, 23);
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
            this.bStart.Size = new System.Drawing.Size(168, 23);
            this.bStart.TabIndex = 3;
            this.bStart.Text = "Старт";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // cbTaskTypes
            // 
            this.cbTasks.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbTasks.FormattingEnabled = true;
            this.cbTasks.Location = new System.Drawing.Point(0, 0);
            this.cbTasks.Name = "cbTaskTypes";
            this.cbTasks.Size = new System.Drawing.Size(168, 21);
            this.cbTasks.TabIndex = 2;
            // 
            // clbTasks
            // 
            this.clbTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbTasks.FormattingEnabled = true;
            this.clbTasks.Location = new System.Drawing.Point(0, 0);
            this.clbTasks.MultiColumn = true;
            this.clbTasks.Name = "clbTasks";
            this.clbTasks.Size = new System.Drawing.Size(508, 70);
            this.clbTasks.TabIndex = 0;
            // 
            // TasksPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "TasksPanel";
            this.Size = new System.Drawing.Size(680, 70);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cbTasks;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.CheckedListBox clbTasks;
        private System.Windows.Forms.Button bCancel;
    }
}
