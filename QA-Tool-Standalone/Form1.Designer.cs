namespace QA_Tool_Standalone
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_HideUnhide = new System.Windows.Forms.Button();
            this.chkLB_TargetColumns = new System.Windows.Forms.CheckedListBox();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.treeView_WBWS = new System.Windows.Forms.TreeView();
            this.lbl_OpenWorkbooks = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_DeleteColumnData = new System.Windows.Forms.Button();
            this.lbl_NoChanges = new System.Windows.Forms.Label();
            this.lbl_UnsavedChanges = new System.Windows.Forms.Label();
            this.lbl_ChangesSaved = new System.Windows.Forms.Label();
            this.lbl_SelectColumns = new System.Windows.Forms.Label();
            this.LB_EditColumns = new System.Windows.Forms.ListBox();
            this.btn_SaveAsNew = new System.Windows.Forms.Button();
            this.textBox_Description = new System.Windows.Forms.TextBox();
            this.lbl_ColumnCodes = new System.Windows.Forms.Label();
            this.textBox_ColumnCodes = new System.Windows.Forms.TextBox();
            this.btn_SaveChanges = new System.Windows.Forms.Button();
            this.lbl_TargetSheet = new System.Windows.Forms.Label();
            this.lbl_Description = new System.Windows.Forms.Label();
            this.lbl_ColumnMacros = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(23, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(751, 414);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.lbl_ColumnMacros);
            this.tabPage1.Controls.Add(this.btn_HideUnhide);
            this.tabPage1.Controls.Add(this.chkLB_TargetColumns);
            this.tabPage1.Controls.Add(this.btn_Refresh);
            this.tabPage1.Controls.Add(this.treeView_WBWS);
            this.tabPage1.Controls.Add(this.lbl_OpenWorkbooks);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(743, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hide Columns";
            // 
            // btn_HideUnhide
            // 
            this.btn_HideUnhide.Location = new System.Drawing.Point(565, 337);
            this.btn_HideUnhide.Name = "btn_HideUnhide";
            this.btn_HideUnhide.Size = new System.Drawing.Size(133, 23);
            this.btn_HideUnhide.TabIndex = 11;
            this.btn_HideUnhide.Text = "Hide/Unhide Columns";
            this.btn_HideUnhide.UseVisualStyleBackColor = true;
            this.btn_HideUnhide.Click += new System.EventHandler(this.Button4_Click_1);
            // 
            // chkLB_TargetColumns
            // 
            this.chkLB_TargetColumns.FormattingEnabled = true;
            this.chkLB_TargetColumns.Location = new System.Drawing.Point(352, 42);
            this.chkLB_TargetColumns.Name = "chkLB_TargetColumns";
            this.chkLB_TargetColumns.Size = new System.Drawing.Size(346, 289);
            this.chkLB_TargetColumns.TabIndex = 10;
            this.chkLB_TargetColumns.SelectedIndexChanged += new System.EventHandler(this.ChkLB_TargetColumns_SelectedIndexChanged);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(22, 337);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(75, 23);
            this.btn_Refresh.TabIndex = 9;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.Button2_Click);
            // 
            // treeView_WBWS
            // 
            this.treeView_WBWS.Location = new System.Drawing.Point(22, 42);
            this.treeView_WBWS.Name = "treeView_WBWS";
            this.treeView_WBWS.Size = new System.Drawing.Size(288, 289);
            this.treeView_WBWS.TabIndex = 8;
            this.treeView_WBWS.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_WBWS_AfterSelect);
            // 
            // lbl_OpenWorkbooks
            // 
            this.lbl_OpenWorkbooks.AutoSize = true;
            this.lbl_OpenWorkbooks.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OpenWorkbooks.Location = new System.Drawing.Point(18, 17);
            this.lbl_OpenWorkbooks.Name = "lbl_OpenWorkbooks";
            this.lbl_OpenWorkbooks.Size = new System.Drawing.Size(180, 22);
            this.lbl_OpenWorkbooks.TabIndex = 7;
            this.lbl_OpenWorkbooks.Text = "Open Workbooks: ";
            this.lbl_OpenWorkbooks.Click += new System.EventHandler(this.Label1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.PapayaWhip;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Controls.Add(this.lbl_Description);
            this.tabPage2.Controls.Add(this.btn_DeleteColumnData);
            this.tabPage2.Controls.Add(this.lbl_NoChanges);
            this.tabPage2.Controls.Add(this.lbl_UnsavedChanges);
            this.tabPage2.Controls.Add(this.lbl_ChangesSaved);
            this.tabPage2.Controls.Add(this.lbl_SelectColumns);
            this.tabPage2.Controls.Add(this.LB_EditColumns);
            this.tabPage2.Controls.Add(this.btn_SaveAsNew);
            this.tabPage2.Controls.Add(this.textBox_Description);
            this.tabPage2.Controls.Add(this.lbl_ColumnCodes);
            this.tabPage2.Controls.Add(this.textBox_ColumnCodes);
            this.tabPage2.Controls.Add(this.btn_SaveChanges);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(743, 388);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Edit Column Macros";
            // 
            // btn_DeleteColumnData
            // 
            this.btn_DeleteColumnData.Location = new System.Drawing.Point(651, 153);
            this.btn_DeleteColumnData.Name = "btn_DeleteColumnData";
            this.btn_DeleteColumnData.Size = new System.Drawing.Size(75, 23);
            this.btn_DeleteColumnData.TabIndex = 12;
            this.btn_DeleteColumnData.Text = "Delete";
            this.btn_DeleteColumnData.UseVisualStyleBackColor = true;
            this.btn_DeleteColumnData.Click += new System.EventHandler(this.Btn_DeleteColumnData_Click);
            // 
            // lbl_NoChanges
            // 
            this.lbl_NoChanges.AutoSize = true;
            this.lbl_NoChanges.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbl_NoChanges.Location = new System.Drawing.Point(478, 158);
            this.lbl_NoChanges.Name = "lbl_NoChanges";
            this.lbl_NoChanges.Size = new System.Drawing.Size(66, 13);
            this.lbl_NoChanges.TabIndex = 11;
            this.lbl_NoChanges.Text = "No Changes";
            // 
            // lbl_UnsavedChanges
            // 
            this.lbl_UnsavedChanges.AutoSize = true;
            this.lbl_UnsavedChanges.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_UnsavedChanges.Location = new System.Drawing.Point(478, 158);
            this.lbl_UnsavedChanges.Name = "lbl_UnsavedChanges";
            this.lbl_UnsavedChanges.Size = new System.Drawing.Size(95, 13);
            this.lbl_UnsavedChanges.TabIndex = 10;
            this.lbl_UnsavedChanges.Text = "Unsaved Changes";
            // 
            // lbl_ChangesSaved
            // 
            this.lbl_ChangesSaved.AutoSize = true;
            this.lbl_ChangesSaved.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_ChangesSaved.Location = new System.Drawing.Point(478, 158);
            this.lbl_ChangesSaved.Name = "lbl_ChangesSaved";
            this.lbl_ChangesSaved.Size = new System.Drawing.Size(83, 13);
            this.lbl_ChangesSaved.TabIndex = 9;
            this.lbl_ChangesSaved.Text = "Changes Saved";
            // 
            // lbl_SelectColumns
            // 
            this.lbl_SelectColumns.AutoSize = true;
            this.lbl_SelectColumns.Location = new System.Drawing.Point(17, 7);
            this.lbl_SelectColumns.Name = "lbl_SelectColumns";
            this.lbl_SelectColumns.Size = new System.Drawing.Size(63, 13);
            this.lbl_SelectColumns.TabIndex = 8;
            this.lbl_SelectColumns.Text = "Select Item:";
            // 
            // LB_EditColumns
            // 
            this.LB_EditColumns.FormattingEnabled = true;
            this.LB_EditColumns.Location = new System.Drawing.Point(17, 25);
            this.LB_EditColumns.Name = "LB_EditColumns";
            this.LB_EditColumns.Size = new System.Drawing.Size(255, 329);
            this.LB_EditColumns.TabIndex = 7;
            this.LB_EditColumns.SelectedIndexChanged += new System.EventHandler(this.LB_EditColumns_SelectedIndexChanged);
            // 
            // btn_SaveAsNew
            // 
            this.btn_SaveAsNew.Location = new System.Drawing.Point(278, 153);
            this.btn_SaveAsNew.Name = "btn_SaveAsNew";
            this.btn_SaveAsNew.Size = new System.Drawing.Size(92, 23);
            this.btn_SaveAsNew.TabIndex = 6;
            this.btn_SaveAsNew.Text = "Save as new";
            this.btn_SaveAsNew.UseVisualStyleBackColor = true;
            this.btn_SaveAsNew.Click += new System.EventHandler(this.Button6_Click);
            // 
            // textBox_Description
            // 
            this.textBox_Description.Location = new System.Drawing.Point(278, 79);
            this.textBox_Description.Name = "textBox_Description";
            this.textBox_Description.Size = new System.Drawing.Size(448, 20);
            this.textBox_Description.TabIndex = 4;
            this.textBox_Description.TextChanged += new System.EventHandler(this.TextBox_Description_TextChanged);
            // 
            // lbl_ColumnCodes
            // 
            this.lbl_ColumnCodes.AutoSize = true;
            this.lbl_ColumnCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ColumnCodes.Location = new System.Drawing.Point(278, 108);
            this.lbl_ColumnCodes.Name = "lbl_ColumnCodes";
            this.lbl_ColumnCodes.Size = new System.Drawing.Size(99, 16);
            this.lbl_ColumnCodes.TabIndex = 3;
            this.lbl_ColumnCodes.Text = "Column Codes:";
            // 
            // textBox_ColumnCodes
            // 
            this.textBox_ColumnCodes.Location = new System.Drawing.Point(278, 127);
            this.textBox_ColumnCodes.Name = "textBox_ColumnCodes";
            this.textBox_ColumnCodes.Size = new System.Drawing.Size(448, 20);
            this.textBox_ColumnCodes.TabIndex = 2;
            this.textBox_ColumnCodes.TextChanged += new System.EventHandler(this.TextBox_ColumnCodes_TextChanged);
            // 
            // btn_SaveChanges
            // 
            this.btn_SaveChanges.Location = new System.Drawing.Point(376, 153);
            this.btn_SaveChanges.Name = "btn_SaveChanges";
            this.btn_SaveChanges.Size = new System.Drawing.Size(96, 23);
            this.btn_SaveChanges.TabIndex = 1;
            this.btn_SaveChanges.Text = "Save Changes";
            this.btn_SaveChanges.UseVisualStyleBackColor = true;
            this.btn_SaveChanges.Click += new System.EventHandler(this.Button5_Click);
            // 
            // lbl_TargetSheet
            // 
            this.lbl_TargetSheet.AutoSize = true;
            this.lbl_TargetSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TargetSheet.Location = new System.Drawing.Point(518, 24);
            this.lbl_TargetSheet.Name = "lbl_TargetSheet";
            this.lbl_TargetSheet.Size = new System.Drawing.Size(132, 20);
            this.lbl_TargetSheet.TabIndex = 11;
            this.lbl_TargetSheet.Text = "Target Sheet: n/a";
            this.lbl_TargetSheet.Click += new System.EventHandler(this.Label1_Click_1);
            // 
            // lbl_Description
            // 
            this.lbl_Description.AutoSize = true;
            this.lbl_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Description.Location = new System.Drawing.Point(275, 60);
            this.lbl_Description.Name = "lbl_Description";
            this.lbl_Description.Size = new System.Drawing.Size(79, 16);
            this.lbl_Description.TabIndex = 13;
            this.lbl_Description.Text = "Description:";
            // 
            // lbl_ColumnMacros
            // 
            this.lbl_ColumnMacros.AutoSize = true;
            this.lbl_ColumnMacros.Location = new System.Drawing.Point(352, 25);
            this.lbl_ColumnMacros.Name = "lbl_ColumnMacros";
            this.lbl_ColumnMacros.Size = new System.Drawing.Size(83, 13);
            this.lbl_ColumnMacros.TabIndex = 12;
            this.lbl_ColumnMacros.Text = "Column Macros:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_TargetSheet);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "QA Tool v3.0.1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

  
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lbl_OpenWorkbooks;
        private System.Windows.Forms.TreeView treeView_WBWS;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Label lbl_TargetSheet;
        private System.Windows.Forms.CheckedListBox chkLB_TargetColumns;
        private System.Windows.Forms.Button btn_HideUnhide;
        private System.Windows.Forms.Button btn_SaveChanges;
        private System.Windows.Forms.Label lbl_ColumnCodes;
        private System.Windows.Forms.TextBox textBox_ColumnCodes;
        private System.Windows.Forms.Button btn_SaveAsNew;
        private System.Windows.Forms.TextBox textBox_Description;
        private System.Windows.Forms.ListBox LB_EditColumns;
        private System.Windows.Forms.Label lbl_SelectColumns;
        private System.Windows.Forms.Label lbl_UnsavedChanges;
        private System.Windows.Forms.Label lbl_ChangesSaved;
        private System.Windows.Forms.Label lbl_NoChanges;
        private System.Windows.Forms.Button btn_DeleteColumnData;
        private System.Windows.Forms.Label lbl_ColumnMacros;
        private System.Windows.Forms.Label lbl_Description;
    }
}

