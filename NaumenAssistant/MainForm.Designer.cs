namespace NaumenAssistant
{
    partial class MainForm
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
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiScripts = new System.Windows.Forms.ToolStripMenuItem();
            this.tscbAPIMode = new System.Windows.Forms.ToolStripComboBox();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.runnerPanel = new EnhancedNaumenControls.RunnerPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbSingleRowResults = new System.Windows.Forms.CheckBox();
            this.lbScriptPreview = new System.Windows.Forms.ListBox();
            this.stringTableView = new EnhancedNaumenControls.StringTableView();
            this.cbInsertEmptyRow = new System.Windows.Forms.CheckBox();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUser,
            this.tsmiScripts,
            this.tscbAPIMode});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // tsmiUser
            // 
            this.tsmiUser.Name = "tsmiUser";
            this.tsmiUser.Size = new System.Drawing.Size(181, 22);
            this.tsmiUser.Text = "Пользователь";
            this.tsmiUser.Click += new System.EventHandler(this.tsmiUser_Click);
            // 
            // tsmiScripts
            // 
            this.tsmiScripts.Name = "tsmiScripts";
            this.tsmiScripts.Size = new System.Drawing.Size(181, 22);
            this.tsmiScripts.Text = "Скрипты";
            this.tsmiScripts.Click += new System.EventHandler(this.tsmiScripts_Click);
            // 
            // tscbAPIMode
            // 
            this.tscbAPIMode.Name = "tscbAPIMode";
            this.tscbAPIMode.Size = new System.Drawing.Size(121, 23);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(800, 24);
            this.mainMenu.TabIndex = 2;
            this.mainMenu.Text = "menuStrip1";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.runnerPanel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panel1);
            this.splitContainer.Panel2.Controls.Add(this.lbScriptPreview);
            this.splitContainer.Size = new System.Drawing.Size(800, 72);
            this.splitContainer.SplitterDistance = 266;
            this.splitContainer.TabIndex = 5;
            // 
            // runnerPanel
            // 
            this.runnerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.runnerPanel.Location = new System.Drawing.Point(0, 0);
            this.runnerPanel.Name = "runnerPanel";
            this.runnerPanel.Paths = new string[0];
            this.runnerPanel.Size = new System.Drawing.Size(266, 69);
            this.runnerPanel.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbInsertEmptyRow);
            this.panel1.Controls.Add(this.cbSingleRowResults);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(290, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 72);
            this.panel1.TabIndex = 6;
            // 
            // cbSingleRowResults
            // 
            this.cbSingleRowResults.AutoSize = true;
            this.cbSingleRowResults.Location = new System.Drawing.Point(14, 3);
            this.cbSingleRowResults.Name = "cbSingleRowResults";
            this.cbSingleRowResults.Size = new System.Drawing.Size(106, 17);
            this.cbSingleRowResults.TabIndex = 0;
            this.cbSingleRowResults.Text = "1 ЛС = 1 строка";
            this.cbSingleRowResults.UseVisualStyleBackColor = true;
            // 
            // lbScriptPreview
            // 
            this.lbScriptPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbScriptPreview.FormattingEnabled = true;
            this.lbScriptPreview.Location = new System.Drawing.Point(0, 0);
            this.lbScriptPreview.Name = "lbScriptPreview";
            this.lbScriptPreview.Size = new System.Drawing.Size(530, 72);
            this.lbScriptPreview.TabIndex = 5;
            // 
            // stringTableView
            // 
            this.stringTableView.ColumnCaptions = new string[0];
            this.stringTableView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stringTableView.Location = new System.Drawing.Point(0, 96);
            this.stringTableView.Name = "stringTableView";
            this.stringTableView.Size = new System.Drawing.Size(800, 354);
            this.stringTableView.TabIndex = 1;
            // 
            // cbInsertEmptyRow
            // 
            this.cbInsertEmptyRow.AutoSize = true;
            this.cbInsertEmptyRow.Location = new System.Drawing.Point(14, 26);
            this.cbInsertEmptyRow.Name = "cbInsertEmptyRow";
            this.cbInsertEmptyRow.Size = new System.Drawing.Size(92, 17);
            this.cbInsertEmptyRow.TabIndex = 1;
            this.cbInsertEmptyRow.Text = "Разделитель";
            this.cbInsertEmptyRow.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.stringTableView);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private EnhancedNaumenControls.StringTableView stringTableView;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiScripts;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.SplitContainer splitContainer;
        private EnhancedNaumenControls.RunnerPanel runnerPanel;
        private System.Windows.Forms.ListBox lbScriptPreview;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbSingleRowResults;
        private System.Windows.Forms.ToolStripComboBox tscbAPIMode;
        private System.Windows.Forms.CheckBox cbInsertEmptyRow;
    }
}

