namespace NaumenAssistant
{
    partial class ScriptsMenager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbScripts = new System.Windows.Forms.ListBox();
            this.scriptsListMenu_1 = new NaumenAssistant.Menus.ScriptsListMenu_(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lbScriptOperations = new System.Windows.Forms.ListBox();
            this.lbmScriptsOperations = new NaumenAssistant.Menus.ListBoxMenu(this.components);
            this.cbAllOperations = new System.Windows.Forms.ComboBox();
            this.lbScriptInputFields = new System.Windows.Forms.ListBox();
            this.cbAllInputFields = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.lbScripts);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(761, 450);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.TabIndex = 2;
            // 
            // lbScripts
            // 
            this.lbScripts.ContextMenuStrip = this.scriptsListMenu_1;
            this.lbScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbScripts.FormattingEnabled = true;
            this.lbScripts.Location = new System.Drawing.Point(0, 0);
            this.lbScripts.Name = "lbScripts";
            this.lbScripts.Size = new System.Drawing.Size(253, 450);
            this.lbScripts.TabIndex = 1;
            this.lbScripts.SelectedValueChanged += new System.EventHandler(this.lbScripts_SelectedValueChanged);
            // 
            // scriptsListMenu_1
            // 
            this.scriptsListMenu_1.MoveFileAtAdd = false;
            this.scriptsListMenu_1.Name = "scriptsListMenu_1";
            this.scriptsListMenu_1.SelectItemOnOpeningMenu = true;
            this.scriptsListMenu_1.Size = new System.Drawing.Size(162, 114);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lbScriptOperations);
            this.splitContainer2.Panel1.Controls.Add(this.cbAllOperations);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lbScriptInputFields);
            this.splitContainer2.Panel2.Controls.Add(this.cbAllInputFields);
            this.splitContainer2.Size = new System.Drawing.Size(504, 450);
            this.splitContainer2.SplitterDistance = 250;
            this.splitContainer2.TabIndex = 4;
            // 
            // lbScriptOperations
            // 
            this.lbScriptOperations.ContextMenuStrip = this.lbmScriptsOperations;
            this.lbScriptOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbScriptOperations.FormattingEnabled = true;
            this.lbScriptOperations.Location = new System.Drawing.Point(0, 21);
            this.lbScriptOperations.Name = "lbScriptOperations";
            this.lbScriptOperations.Size = new System.Drawing.Size(250, 429);
            this.lbScriptOperations.TabIndex = 2;
            this.lbScriptOperations.DataSourceChanged += new System.EventHandler(this.dataSourceChanged);
            this.lbScriptOperations.EnabledChanged += new System.EventHandler(this.enabledChanged);
            // 
            // lbmScriptsOperations
            // 
            this.lbmScriptsOperations.Name = "lbmScriptsOperations";
            this.lbmScriptsOperations.Size = new System.Drawing.Size(160, 48);
            // 
            // cbAllOperations
            // 
            this.cbAllOperations.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbAllOperations.FormattingEnabled = true;
            this.cbAllOperations.Location = new System.Drawing.Point(0, 0);
            this.cbAllOperations.Name = "cbAllOperations";
            this.cbAllOperations.Size = new System.Drawing.Size(250, 21);
            this.cbAllOperations.TabIndex = 3;
            this.cbAllOperations.SelectionChangeCommitted += new System.EventHandler(this.CbAllOperations_SelectionChangeCommitted);
            // 
            // lbScriptInputFields
            // 
            this.lbScriptInputFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbScriptInputFields.FormattingEnabled = true;
            this.lbScriptInputFields.Location = new System.Drawing.Point(0, 21);
            this.lbScriptInputFields.Name = "lbScriptInputFields";
            this.lbScriptInputFields.Size = new System.Drawing.Size(250, 429);
            this.lbScriptInputFields.TabIndex = 3;
            this.lbScriptInputFields.DataSourceChanged += new System.EventHandler(this.dataSourceChanged);
            this.lbScriptInputFields.EnabledChanged += new System.EventHandler(this.enabledChanged);
            // 
            // cbAllInputFields
            // 
            this.cbAllInputFields.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbAllInputFields.FormattingEnabled = true;
            this.cbAllInputFields.Location = new System.Drawing.Point(0, 0);
            this.cbAllInputFields.Name = "cbAllInputFields";
            this.cbAllInputFields.Size = new System.Drawing.Size(250, 21);
            this.cbAllInputFields.TabIndex = 4;
            // 
            // ScriptsMenager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ScriptsMenager";
            this.Text = "ScriptsMenager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScriptsMenager_FormClosing);
            this.Load += new System.EventHandler(this.ScriptsMenager_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lbScripts;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox lbScriptOperations;
        private System.Windows.Forms.ComboBox cbAllOperations;
        private System.Windows.Forms.ListBox lbScriptInputFields;
        private Menus.ListBoxMenu lbmScriptsOperations;
        private System.Windows.Forms.ComboBox cbAllInputFields;
        private Menus.ScriptsListMenu_ scriptsListMenu_1;
    }
}