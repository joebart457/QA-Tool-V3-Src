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
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btn_RunDateLabelMacros = new System.Windows.Forms.Button();
            this.txtBox_Fallback = new System.Windows.Forms.TextBox();
            this.lbl_Fallback = new System.Windows.Forms.Label();
            this.lbl_TargetColumn = new System.Windows.Forms.Label();
            this.lbl_DateColumn = new System.Windows.Forms.Label();
            this.txtBox_targetColumn = new System.Windows.Forms.TextBox();
            this.txtBox_dateColumn = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbl_ColumnMacros = new System.Windows.Forms.Label();
            this.btn_HideUnhide = new System.Windows.Forms.Button();
            this.chkLB_TargetColumns = new System.Windows.Forms.CheckedListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbl_Description = new System.Windows.Forms.Label();
            this.btn_DeleteColumnData = new System.Windows.Forms.Button();
            this.lbl_NoChanges = new System.Windows.Forms.Label();
            this.lbl_UnsavedChanges = new System.Windows.Forms.Label();
            this.lbl_ChangesSaved = new System.Windows.Forms.Label();
            this.LB_EditColumns = new System.Windows.Forms.ListBox();
            this.btn_SaveAsNew = new System.Windows.Forms.Button();
            this.textBox_Description = new System.Windows.Forms.TextBox();
            this.lbl_ColumnCodes = new System.Windows.Forms.Label();
            this.textBox_ColumnCodes = new System.Windows.Forms.TextBox();
            this.btn_SaveChanges = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.lb_DateRange = new System.Windows.Forms.ListBox();
            this.lbl_DateRangeChangesSaved = new System.Windows.Forms.Label();
            this.lbl_DateRangeUnsavedChanges = new System.Windows.Forms.Label();
            this.lbl_DateRangeNoChanges = new System.Windows.Forms.Label();
            this.btn_DeleteDateRange = new System.Windows.Forms.Button();
            this.btn_SaveDateRangeAsNew = new System.Windows.Forms.Button();
            this.btn_SaveDateRange = new System.Windows.Forms.Button();
            this.lbl_DateRangeLabel = new System.Windows.Forms.Label();
            this.txtBox_DateRangeLabel = new System.Windows.Forms.TextBox();
            this.lbl_EndDateTime = new System.Windows.Forms.Label();
            this.lbl_StartTime = new System.Windows.Forms.Label();
            this.dtPicker_EndTime = new System.Windows.Forms.DateTimePicker();
            this.dtPicker_EndDate = new System.Windows.Forms.DateTimePicker();
            this.dtPicker_StartTime = new System.Windows.Forms.DateTimePicker();
            this.dtPicker_StartDate = new System.Windows.Forms.DateTimePicker();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.treeView_WBWS = new System.Windows.Forms.TreeView();
            this.lbl_OpenWorkbooks = new System.Windows.Forms.Label();
            this.lbl_TargetSheet = new System.Windows.Forms.Label();
            this.dgView_AppSettings = new System.Windows.Forms.DataGridView();
            this.btn_ClearLogs = new System.Windows.Forms.Button();
            this.btn_SaveAppSettings = new System.Windows.Forms.Button();
            this.grpBox_Config = new System.Windows.Forms.GroupBox();
            this.btn_DeleteAppSetting = new System.Windows.Forms.Button();
            this.lb_DateRangesRunView = new System.Windows.Forms.ListBox();
            this.pb_RunDateTimeMacros = new System.Windows.Forms.ProgressBar();
            this.gb_RunDateTimeMacrosStatus = new System.Windows.Forms.GroupBox();
            this.lbl_RunDateTimeMacrosProgress = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView_AppSettings)).BeginInit();
            this.grpBox_Config.SuspendLayout();
            this.gb_RunDateTimeMacrosStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(293, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(539, 414);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage4.Controls.Add(this.gb_RunDateTimeMacrosStatus);
            this.tabPage4.Controls.Add(this.lb_DateRangesRunView);
            this.tabPage4.Controls.Add(this.btn_RunDateLabelMacros);
            this.tabPage4.Controls.Add(this.txtBox_Fallback);
            this.tabPage4.Controls.Add(this.lbl_Fallback);
            this.tabPage4.Controls.Add(this.lbl_TargetColumn);
            this.tabPage4.Controls.Add(this.lbl_DateColumn);
            this.tabPage4.Controls.Add(this.txtBox_targetColumn);
            this.tabPage4.Controls.Add(this.txtBox_dateColumn);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(531, 388);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Run DateTime Macros";
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // btn_RunDateLabelMacros
            // 
            this.btn_RunDateLabelMacros.Location = new System.Drawing.Point(24, 260);
            this.btn_RunDateLabelMacros.Name = "btn_RunDateLabelMacros";
            this.btn_RunDateLabelMacros.Size = new System.Drawing.Size(199, 23);
            this.btn_RunDateLabelMacros.TabIndex = 21;
            this.btn_RunDateLabelMacros.Text = "Run";
            this.btn_RunDateLabelMacros.UseVisualStyleBackColor = true;
            this.btn_RunDateLabelMacros.Click += new System.EventHandler(this.btn_RunDateLabelMacros_Click);
            // 
            // txtBox_Fallback
            // 
            this.txtBox_Fallback.Location = new System.Drawing.Point(24, 131);
            this.txtBox_Fallback.Name = "txtBox_Fallback";
            this.txtBox_Fallback.Size = new System.Drawing.Size(199, 20);
            this.txtBox_Fallback.TabIndex = 20;
            // 
            // lbl_Fallback
            // 
            this.lbl_Fallback.AutoSize = true;
            this.lbl_Fallback.Location = new System.Drawing.Point(21, 115);
            this.lbl_Fallback.Name = "lbl_Fallback";
            this.lbl_Fallback.Size = new System.Drawing.Size(202, 13);
            this.lbl_Fallback.TabIndex = 19;
            this.lbl_Fallback.Text = "Fallback Value when no date is matched:";
            // 
            // lbl_TargetColumn
            // 
            this.lbl_TargetColumn.AutoSize = true;
            this.lbl_TargetColumn.Location = new System.Drawing.Point(21, 67);
            this.lbl_TargetColumn.Name = "lbl_TargetColumn";
            this.lbl_TargetColumn.Size = new System.Drawing.Size(76, 13);
            this.lbl_TargetColumn.TabIndex = 18;
            this.lbl_TargetColumn.Text = "Target Column";
            // 
            // lbl_DateColumn
            // 
            this.lbl_DateColumn.AutoSize = true;
            this.lbl_DateColumn.Location = new System.Drawing.Point(21, 19);
            this.lbl_DateColumn.Name = "lbl_DateColumn";
            this.lbl_DateColumn.Size = new System.Drawing.Size(68, 13);
            this.lbl_DateColumn.TabIndex = 17;
            this.lbl_DateColumn.Text = "Date Column";
            // 
            // txtBox_targetColumn
            // 
            this.txtBox_targetColumn.Location = new System.Drawing.Point(24, 83);
            this.txtBox_targetColumn.Name = "txtBox_targetColumn";
            this.txtBox_targetColumn.Size = new System.Drawing.Size(100, 20);
            this.txtBox_targetColumn.TabIndex = 16;
            // 
            // txtBox_dateColumn
            // 
            this.txtBox_dateColumn.Location = new System.Drawing.Point(24, 35);
            this.txtBox_dateColumn.Name = "txtBox_dateColumn";
            this.txtBox_dateColumn.Size = new System.Drawing.Size(100, 20);
            this.txtBox_dateColumn.TabIndex = 15;
            this.txtBox_dateColumn.TextChanged += new System.EventHandler(this.txtBox_dateColumn_TextChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Azure;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.lbl_ColumnMacros);
            this.tabPage1.Controls.Add(this.btn_HideUnhide);
            this.tabPage1.Controls.Add(this.chkLB_TargetColumns);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(531, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hide Columns";
            // 
            // lbl_ColumnMacros
            // 
            this.lbl_ColumnMacros.AutoSize = true;
            this.lbl_ColumnMacros.Location = new System.Drawing.Point(19, 8);
            this.lbl_ColumnMacros.Name = "lbl_ColumnMacros";
            this.lbl_ColumnMacros.Size = new System.Drawing.Size(83, 13);
            this.lbl_ColumnMacros.TabIndex = 12;
            this.lbl_ColumnMacros.Text = "Column Macros:";
            // 
            // btn_HideUnhide
            // 
            this.btn_HideUnhide.Location = new System.Drawing.Point(371, 337);
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
            this.chkLB_TargetColumns.Location = new System.Drawing.Point(22, 27);
            this.chkLB_TargetColumns.Name = "chkLB_TargetColumns";
            this.chkLB_TargetColumns.Size = new System.Drawing.Size(482, 304);
            this.chkLB_TargetColumns.TabIndex = 10;
            this.chkLB_TargetColumns.SelectedIndexChanged += new System.EventHandler(this.ChkLB_TargetColumns_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Azure;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Controls.Add(this.lbl_Description);
            this.tabPage2.Controls.Add(this.btn_DeleteColumnData);
            this.tabPage2.Controls.Add(this.lbl_NoChanges);
            this.tabPage2.Controls.Add(this.lbl_UnsavedChanges);
            this.tabPage2.Controls.Add(this.lbl_ChangesSaved);
            this.tabPage2.Controls.Add(this.LB_EditColumns);
            this.tabPage2.Controls.Add(this.btn_SaveAsNew);
            this.tabPage2.Controls.Add(this.textBox_Description);
            this.tabPage2.Controls.Add(this.lbl_ColumnCodes);
            this.tabPage2.Controls.Add(this.textBox_ColumnCodes);
            this.tabPage2.Controls.Add(this.btn_SaveChanges);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(531, 388);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Edit Column Macros";
            // 
            // lbl_Description
            // 
            this.lbl_Description.AutoSize = true;
            this.lbl_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Description.Location = new System.Drawing.Point(14, 266);
            this.lbl_Description.Name = "lbl_Description";
            this.lbl_Description.Size = new System.Drawing.Size(79, 16);
            this.lbl_Description.TabIndex = 13;
            this.lbl_Description.Text = "Description:";
            // 
            // btn_DeleteColumnData
            // 
            this.btn_DeleteColumnData.Location = new System.Drawing.Point(411, 349);
            this.btn_DeleteColumnData.Name = "btn_DeleteColumnData";
            this.btn_DeleteColumnData.Size = new System.Drawing.Size(96, 23);
            this.btn_DeleteColumnData.TabIndex = 5;
            this.btn_DeleteColumnData.Text = "Delete";
            this.btn_DeleteColumnData.UseVisualStyleBackColor = true;
            this.btn_DeleteColumnData.Click += new System.EventHandler(this.Btn_DeleteColumnData_Click);
            // 
            // lbl_NoChanges
            // 
            this.lbl_NoChanges.AutoSize = true;
            this.lbl_NoChanges.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbl_NoChanges.Location = new System.Drawing.Point(426, 327);
            this.lbl_NoChanges.Name = "lbl_NoChanges";
            this.lbl_NoChanges.Size = new System.Drawing.Size(66, 13);
            this.lbl_NoChanges.TabIndex = 11;
            this.lbl_NoChanges.Text = "No Changes";
            // 
            // lbl_UnsavedChanges
            // 
            this.lbl_UnsavedChanges.AutoSize = true;
            this.lbl_UnsavedChanges.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_UnsavedChanges.Location = new System.Drawing.Point(413, 327);
            this.lbl_UnsavedChanges.Name = "lbl_UnsavedChanges";
            this.lbl_UnsavedChanges.Size = new System.Drawing.Size(95, 13);
            this.lbl_UnsavedChanges.TabIndex = 10;
            this.lbl_UnsavedChanges.Text = "Unsaved Changes";
            // 
            // lbl_ChangesSaved
            // 
            this.lbl_ChangesSaved.AutoSize = true;
            this.lbl_ChangesSaved.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_ChangesSaved.Location = new System.Drawing.Point(424, 327);
            this.lbl_ChangesSaved.Name = "lbl_ChangesSaved";
            this.lbl_ChangesSaved.Size = new System.Drawing.Size(83, 13);
            this.lbl_ChangesSaved.TabIndex = 9;
            this.lbl_ChangesSaved.Text = "Changes Saved";
            // 
            // LB_EditColumns
            // 
            this.LB_EditColumns.FormattingEnabled = true;
            this.LB_EditColumns.Location = new System.Drawing.Point(17, 25);
            this.LB_EditColumns.Name = "LB_EditColumns";
            this.LB_EditColumns.Size = new System.Drawing.Size(490, 238);
            this.LB_EditColumns.TabIndex = 7;
            this.LB_EditColumns.SelectedIndexChanged += new System.EventHandler(this.LB_EditColumns_SelectedIndexChanged);
            // 
            // btn_SaveAsNew
            // 
            this.btn_SaveAsNew.Location = new System.Drawing.Point(411, 272);
            this.btn_SaveAsNew.Name = "btn_SaveAsNew";
            this.btn_SaveAsNew.Size = new System.Drawing.Size(96, 23);
            this.btn_SaveAsNew.TabIndex = 3;
            this.btn_SaveAsNew.Text = "Save as new";
            this.btn_SaveAsNew.UseVisualStyleBackColor = true;
            this.btn_SaveAsNew.Click += new System.EventHandler(this.Button6_Click);
            // 
            // textBox_Description
            // 
            this.textBox_Description.Location = new System.Drawing.Point(17, 285);
            this.textBox_Description.Name = "textBox_Description";
            this.textBox_Description.Size = new System.Drawing.Size(371, 20);
            this.textBox_Description.TabIndex = 1;
            this.textBox_Description.TextChanged += new System.EventHandler(this.TextBox_Description_TextChanged);
            // 
            // lbl_ColumnCodes
            // 
            this.lbl_ColumnCodes.AutoSize = true;
            this.lbl_ColumnCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ColumnCodes.Location = new System.Drawing.Point(14, 317);
            this.lbl_ColumnCodes.Name = "lbl_ColumnCodes";
            this.lbl_ColumnCodes.Size = new System.Drawing.Size(99, 16);
            this.lbl_ColumnCodes.TabIndex = 3;
            this.lbl_ColumnCodes.Text = "Column Codes:";
            // 
            // textBox_ColumnCodes
            // 
            this.textBox_ColumnCodes.Location = new System.Drawing.Point(17, 336);
            this.textBox_ColumnCodes.Multiline = true;
            this.textBox_ColumnCodes.Name = "textBox_ColumnCodes";
            this.textBox_ColumnCodes.Size = new System.Drawing.Size(371, 36);
            this.textBox_ColumnCodes.TabIndex = 2;
            this.textBox_ColumnCodes.TextChanged += new System.EventHandler(this.TextBox_ColumnCodes_TextChanged);
            // 
            // btn_SaveChanges
            // 
            this.btn_SaveChanges.Enabled = false;
            this.btn_SaveChanges.Location = new System.Drawing.Point(412, 301);
            this.btn_SaveChanges.Name = "btn_SaveChanges";
            this.btn_SaveChanges.Size = new System.Drawing.Size(96, 23);
            this.btn_SaveChanges.TabIndex = 4;
            this.btn_SaveChanges.Text = "Save Changes";
            this.btn_SaveChanges.UseVisualStyleBackColor = true;
            this.btn_SaveChanges.Click += new System.EventHandler(this.Button5_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage5.Controls.Add(this.lb_DateRange);
            this.tabPage5.Controls.Add(this.lbl_DateRangeChangesSaved);
            this.tabPage5.Controls.Add(this.lbl_DateRangeUnsavedChanges);
            this.tabPage5.Controls.Add(this.lbl_DateRangeNoChanges);
            this.tabPage5.Controls.Add(this.btn_DeleteDateRange);
            this.tabPage5.Controls.Add(this.btn_SaveDateRangeAsNew);
            this.tabPage5.Controls.Add(this.btn_SaveDateRange);
            this.tabPage5.Controls.Add(this.lbl_DateRangeLabel);
            this.tabPage5.Controls.Add(this.txtBox_DateRangeLabel);
            this.tabPage5.Controls.Add(this.lbl_EndDateTime);
            this.tabPage5.Controls.Add(this.lbl_StartTime);
            this.tabPage5.Controls.Add(this.dtPicker_EndTime);
            this.tabPage5.Controls.Add(this.dtPicker_EndDate);
            this.tabPage5.Controls.Add(this.dtPicker_StartTime);
            this.tabPage5.Controls.Add(this.dtPicker_StartDate);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(531, 388);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Edit DateTime Macros";
            // 
            // lb_DateRange
            // 
            this.lb_DateRange.FormattingEnabled = true;
            this.lb_DateRange.Location = new System.Drawing.Point(40, 20);
            this.lb_DateRange.Name = "lb_DateRange";
            this.lb_DateRange.Size = new System.Drawing.Size(447, 212);
            this.lb_DateRange.TabIndex = 15;
            this.lb_DateRange.SelectedIndexChanged += new System.EventHandler(this.lb_DateRange_SelectedIndexChanged);
            // 
            // lbl_DateRangeChangesSaved
            // 
            this.lbl_DateRangeChangesSaved.AutoSize = true;
            this.lbl_DateRangeChangesSaved.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_DateRangeChangesSaved.Location = new System.Drawing.Point(388, 305);
            this.lbl_DateRangeChangesSaved.Name = "lbl_DateRangeChangesSaved";
            this.lbl_DateRangeChangesSaved.Size = new System.Drawing.Size(83, 13);
            this.lbl_DateRangeChangesSaved.TabIndex = 14;
            this.lbl_DateRangeChangesSaved.Text = "Changes Saved";
            // 
            // lbl_DateRangeUnsavedChanges
            // 
            this.lbl_DateRangeUnsavedChanges.AutoSize = true;
            this.lbl_DateRangeUnsavedChanges.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_DateRangeUnsavedChanges.Location = new System.Drawing.Point(388, 305);
            this.lbl_DateRangeUnsavedChanges.Name = "lbl_DateRangeUnsavedChanges";
            this.lbl_DateRangeUnsavedChanges.Size = new System.Drawing.Size(95, 13);
            this.lbl_DateRangeUnsavedChanges.TabIndex = 13;
            this.lbl_DateRangeUnsavedChanges.Text = "Unsaved Changes";
            // 
            // lbl_DateRangeNoChanges
            // 
            this.lbl_DateRangeNoChanges.AutoSize = true;
            this.lbl_DateRangeNoChanges.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbl_DateRangeNoChanges.Location = new System.Drawing.Point(402, 305);
            this.lbl_DateRangeNoChanges.Name = "lbl_DateRangeNoChanges";
            this.lbl_DateRangeNoChanges.Size = new System.Drawing.Size(66, 13);
            this.lbl_DateRangeNoChanges.TabIndex = 12;
            this.lbl_DateRangeNoChanges.Text = "No Changes";
            // 
            // btn_DeleteDateRange
            // 
            this.btn_DeleteDateRange.Location = new System.Drawing.Point(381, 338);
            this.btn_DeleteDateRange.Name = "btn_DeleteDateRange";
            this.btn_DeleteDateRange.Size = new System.Drawing.Size(106, 23);
            this.btn_DeleteDateRange.TabIndex = 7;
            this.btn_DeleteDateRange.Text = "Delete";
            this.btn_DeleteDateRange.UseVisualStyleBackColor = true;
            this.btn_DeleteDateRange.Click += new System.EventHandler(this.btn_DeleteDateRange_Click);
            // 
            // btn_SaveDateRangeAsNew
            // 
            this.btn_SaveDateRangeAsNew.Location = new System.Drawing.Point(381, 250);
            this.btn_SaveDateRangeAsNew.Name = "btn_SaveDateRangeAsNew";
            this.btn_SaveDateRangeAsNew.Size = new System.Drawing.Size(106, 23);
            this.btn_SaveDateRangeAsNew.TabIndex = 5;
            this.btn_SaveDateRangeAsNew.Text = "Save as New";
            this.btn_SaveDateRangeAsNew.UseVisualStyleBackColor = true;
            this.btn_SaveDateRangeAsNew.Click += new System.EventHandler(this.btn_SaveDateRangeAsNew_Click);
            // 
            // btn_SaveDateRange
            // 
            this.btn_SaveDateRange.Enabled = false;
            this.btn_SaveDateRange.Location = new System.Drawing.Point(381, 279);
            this.btn_SaveDateRange.Name = "btn_SaveDateRange";
            this.btn_SaveDateRange.Size = new System.Drawing.Size(106, 23);
            this.btn_SaveDateRange.TabIndex = 6;
            this.btn_SaveDateRange.Text = "Save";
            this.btn_SaveDateRange.UseVisualStyleBackColor = true;
            this.btn_SaveDateRange.Click += new System.EventHandler(this.btn_SaveDateRange_Click);
            // 
            // lbl_DateRangeLabel
            // 
            this.lbl_DateRangeLabel.AutoSize = true;
            this.lbl_DateRangeLabel.Location = new System.Drawing.Point(34, 237);
            this.lbl_DateRangeLabel.Name = "lbl_DateRangeLabel";
            this.lbl_DateRangeLabel.Size = new System.Drawing.Size(33, 13);
            this.lbl_DateRangeLabel.TabIndex = 7;
            this.lbl_DateRangeLabel.Text = "Label";
            // 
            // txtBox_DateRangeLabel
            // 
            this.txtBox_DateRangeLabel.Location = new System.Drawing.Point(37, 253);
            this.txtBox_DateRangeLabel.Name = "txtBox_DateRangeLabel";
            this.txtBox_DateRangeLabel.Size = new System.Drawing.Size(302, 20);
            this.txtBox_DateRangeLabel.TabIndex = 0;
            this.txtBox_DateRangeLabel.TextChanged += new System.EventHandler(this.txtBox_DateRangeLabel_TextChanged);
            // 
            // lbl_EndDateTime
            // 
            this.lbl_EndDateTime.AutoSize = true;
            this.lbl_EndDateTime.Location = new System.Drawing.Point(37, 325);
            this.lbl_EndDateTime.Name = "lbl_EndDateTime";
            this.lbl_EndDateTime.Size = new System.Drawing.Size(87, 13);
            this.lbl_EndDateTime.TabIndex = 5;
            this.lbl_EndDateTime.Text = "End Date + Time";
            // 
            // lbl_StartTime
            // 
            this.lbl_StartTime.AutoSize = true;
            this.lbl_StartTime.Location = new System.Drawing.Point(34, 276);
            this.lbl_StartTime.Name = "lbl_StartTime";
            this.lbl_StartTime.Size = new System.Drawing.Size(90, 13);
            this.lbl_StartTime.TabIndex = 4;
            this.lbl_StartTime.Text = "Start Date + Time";
            // 
            // dtPicker_EndTime
            // 
            this.dtPicker_EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtPicker_EndTime.Location = new System.Drawing.Point(246, 341);
            this.dtPicker_EndTime.Name = "dtPicker_EndTime";
            this.dtPicker_EndTime.ShowUpDown = true;
            this.dtPicker_EndTime.Size = new System.Drawing.Size(93, 20);
            this.dtPicker_EndTime.TabIndex = 4;
            this.dtPicker_EndTime.ValueChanged += new System.EventHandler(this.dtPicker_EndTime_ValueChanged);
            // 
            // dtPicker_EndDate
            // 
            this.dtPicker_EndDate.Location = new System.Drawing.Point(40, 341);
            this.dtPicker_EndDate.Name = "dtPicker_EndDate";
            this.dtPicker_EndDate.Size = new System.Drawing.Size(200, 20);
            this.dtPicker_EndDate.TabIndex = 3;
            this.dtPicker_EndDate.ValueChanged += new System.EventHandler(this.dtPicker_EndDate_ValueChanged);
            // 
            // dtPicker_StartTime
            // 
            this.dtPicker_StartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtPicker_StartTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtPicker_StartTime.Location = new System.Drawing.Point(246, 292);
            this.dtPicker_StartTime.Name = "dtPicker_StartTime";
            this.dtPicker_StartTime.ShowUpDown = true;
            this.dtPicker_StartTime.Size = new System.Drawing.Size(93, 20);
            this.dtPicker_StartTime.TabIndex = 2;
            this.dtPicker_StartTime.ValueChanged += new System.EventHandler(this.dtPicker_StartTime_ValueChanged);
            // 
            // dtPicker_StartDate
            // 
            this.dtPicker_StartDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtPicker_StartDate.Location = new System.Drawing.Point(40, 292);
            this.dtPicker_StartDate.Name = "dtPicker_StartDate";
            this.dtPicker_StartDate.Size = new System.Drawing.Size(200, 20);
            this.dtPicker_StartDate.TabIndex = 1;
            this.dtPicker_StartDate.ValueChanged += new System.EventHandler(this.dtPicker_StartDate_ValueChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.grpBox_Config);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(531, 388);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Advanced";
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(212, 25);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(75, 26);
            this.btn_Refresh.TabIndex = 9;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.Button2_Click);
            // 
            // treeView_WBWS
            // 
            this.treeView_WBWS.Location = new System.Drawing.Point(12, 56);
            this.treeView_WBWS.Name = "treeView_WBWS";
            this.treeView_WBWS.Size = new System.Drawing.Size(275, 382);
            this.treeView_WBWS.TabIndex = 8;
            this.treeView_WBWS.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_WBWS_AfterSelect);
            // 
            // lbl_OpenWorkbooks
            // 
            this.lbl_OpenWorkbooks.AutoSize = true;
            this.lbl_OpenWorkbooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OpenWorkbooks.Location = new System.Drawing.Point(8, 24);
            this.lbl_OpenWorkbooks.Name = "lbl_OpenWorkbooks";
            this.lbl_OpenWorkbooks.Size = new System.Drawing.Size(168, 24);
            this.lbl_OpenWorkbooks.TabIndex = 7;
            this.lbl_OpenWorkbooks.Text = "Open Workbooks: ";
            this.lbl_OpenWorkbooks.Click += new System.EventHandler(this.Label1_Click);
            // 
            // lbl_TargetSheet
            // 
            this.lbl_TargetSheet.AutoEllipsis = true;
            this.lbl_TargetSheet.AutoSize = true;
            this.lbl_TargetSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TargetSheet.Location = new System.Drawing.Point(8, 0);
            this.lbl_TargetSheet.Name = "lbl_TargetSheet";
            this.lbl_TargetSheet.Size = new System.Drawing.Size(132, 20);
            this.lbl_TargetSheet.TabIndex = 11;
            this.lbl_TargetSheet.Text = "Target Sheet: n/a";
            this.lbl_TargetSheet.Click += new System.EventHandler(this.Label1_Click_1);
            // 
            // dgView_AppSettings
            // 
            this.dgView_AppSettings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgView_AppSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView_AppSettings.Location = new System.Drawing.Point(23, 19);
            this.dgView_AppSettings.MultiSelect = false;
            this.dgView_AppSettings.Name = "dgView_AppSettings";
            this.dgView_AppSettings.Size = new System.Drawing.Size(456, 289);
            this.dgView_AppSettings.TabIndex = 6;
            // 
            // btn_ClearLogs
            // 
            this.btn_ClearLogs.Location = new System.Drawing.Point(23, 327);
            this.btn_ClearLogs.Name = "btn_ClearLogs";
            this.btn_ClearLogs.Size = new System.Drawing.Size(75, 23);
            this.btn_ClearLogs.TabIndex = 0;
            this.btn_ClearLogs.Text = "Clear Logs";
            this.btn_ClearLogs.UseVisualStyleBackColor = true;
            this.btn_ClearLogs.Click += new System.EventHandler(this.btn_ClearLogs_Click);
            // 
            // btn_SaveAppSettings
            // 
            this.btn_SaveAppSettings.Location = new System.Drawing.Point(404, 327);
            this.btn_SaveAppSettings.Name = "btn_SaveAppSettings";
            this.btn_SaveAppSettings.Size = new System.Drawing.Size(75, 23);
            this.btn_SaveAppSettings.TabIndex = 7;
            this.btn_SaveAppSettings.Text = "Save";
            this.btn_SaveAppSettings.UseVisualStyleBackColor = true;
            this.btn_SaveAppSettings.Click += new System.EventHandler(this.btn_SaveAppSettings_Click);
            // 
            // grpBox_Config
            // 
            this.grpBox_Config.Controls.Add(this.btn_DeleteAppSetting);
            this.grpBox_Config.Controls.Add(this.btn_ClearLogs);
            this.grpBox_Config.Controls.Add(this.dgView_AppSettings);
            this.grpBox_Config.Controls.Add(this.btn_SaveAppSettings);
            this.grpBox_Config.Location = new System.Drawing.Point(29, 6);
            this.grpBox_Config.Name = "grpBox_Config";
            this.grpBox_Config.Size = new System.Drawing.Size(496, 376);
            this.grpBox_Config.TabIndex = 4;
            this.grpBox_Config.TabStop = false;
            this.grpBox_Config.Text = "Configuration";
            this.grpBox_Config.Enter += new System.EventHandler(this.grpBox_Config_Enter);
            // 
            // btn_DeleteAppSetting
            // 
            this.btn_DeleteAppSetting.Location = new System.Drawing.Point(309, 327);
            this.btn_DeleteAppSetting.Name = "btn_DeleteAppSetting";
            this.btn_DeleteAppSetting.Size = new System.Drawing.Size(75, 23);
            this.btn_DeleteAppSetting.TabIndex = 8;
            this.btn_DeleteAppSetting.Text = "Delete";
            this.btn_DeleteAppSetting.UseVisualStyleBackColor = true;
            this.btn_DeleteAppSetting.Click += new System.EventHandler(this.btn_DeleteAppSetting_Click);
            // 
            // lb_DateRangesRunView
            // 
            this.lb_DateRangesRunView.FormattingEnabled = true;
            this.lb_DateRangesRunView.Location = new System.Drawing.Point(242, 19);
            this.lb_DateRangesRunView.Name = "lb_DateRangesRunView";
            this.lb_DateRangesRunView.Size = new System.Drawing.Size(270, 264);
            this.lb_DateRangesRunView.TabIndex = 22;
            // 
            // pb_RunDateTimeMacros
            // 
            this.pb_RunDateTimeMacros.Location = new System.Drawing.Point(17, 33);
            this.pb_RunDateTimeMacros.Name = "pb_RunDateTimeMacros";
            this.pb_RunDateTimeMacros.Size = new System.Drawing.Size(451, 23);
            this.pb_RunDateTimeMacros.Step = 1;
            this.pb_RunDateTimeMacros.TabIndex = 23;
            // 
            // gb_RunDateTimeMacrosStatus
            // 
            this.gb_RunDateTimeMacrosStatus.Controls.Add(this.lbl_RunDateTimeMacrosProgress);
            this.gb_RunDateTimeMacrosStatus.Controls.Add(this.pb_RunDateTimeMacros);
            this.gb_RunDateTimeMacrosStatus.Location = new System.Drawing.Point(24, 303);
            this.gb_RunDateTimeMacrosStatus.Name = "gb_RunDateTimeMacrosStatus";
            this.gb_RunDateTimeMacrosStatus.Size = new System.Drawing.Size(488, 79);
            this.gb_RunDateTimeMacrosStatus.TabIndex = 24;
            this.gb_RunDateTimeMacrosStatus.TabStop = false;
            this.gb_RunDateTimeMacrosStatus.Text = "Task Status";
            // 
            // lbl_RunDateTimeMacrosProgress
            // 
            this.lbl_RunDateTimeMacrosProgress.AutoSize = true;
            this.lbl_RunDateTimeMacrosProgress.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_RunDateTimeMacrosProgress.Location = new System.Drawing.Point(424, 16);
            this.lbl_RunDateTimeMacrosProgress.Name = "lbl_RunDateTimeMacrosProgress";
            this.lbl_RunDateTimeMacrosProgress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_RunDateTimeMacrosProgress.Size = new System.Drawing.Size(61, 13);
            this.lbl_RunDateTimeMacrosProgress.TabIndex = 24;
            this.lbl_RunDateTimeMacrosProgress.Text = "Not Started";
            this.lbl_RunDateTimeMacrosProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(843, 450);
            this.Controls.Add(this.lbl_TargetSheet);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.treeView_WBWS);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.lbl_OpenWorkbooks);
            this.Name = "Form1";
            this.Text = "QA Tool v3.0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgView_AppSettings)).EndInit();
            this.grpBox_Config.ResumeLayout(false);
            this.gb_RunDateTimeMacrosStatus.ResumeLayout(false);
            this.gb_RunDateTimeMacrosStatus.PerformLayout();
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
        private System.Windows.Forms.Label lbl_UnsavedChanges;
        private System.Windows.Forms.Label lbl_ChangesSaved;
        private System.Windows.Forms.Label lbl_NoChanges;
        private System.Windows.Forms.Button btn_DeleteColumnData;
        private System.Windows.Forms.Label lbl_ColumnMacros;
        private System.Windows.Forms.Label lbl_Description;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txtBox_targetColumn;
        private System.Windows.Forms.TextBox txtBox_dateColumn;
        private System.Windows.Forms.Label lbl_TargetColumn;
        private System.Windows.Forms.Label lbl_DateColumn;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DateTimePicker dtPicker_StartDate;
        private System.Windows.Forms.Button btn_DeleteDateRange;
        private System.Windows.Forms.Button btn_SaveDateRangeAsNew;
        private System.Windows.Forms.Button btn_SaveDateRange;
        private System.Windows.Forms.Label lbl_DateRangeLabel;
        private System.Windows.Forms.TextBox txtBox_DateRangeLabel;
        private System.Windows.Forms.Label lbl_EndDateTime;
        private System.Windows.Forms.Label lbl_StartTime;
        private System.Windows.Forms.DateTimePicker dtPicker_EndTime;
        private System.Windows.Forms.DateTimePicker dtPicker_EndDate;
        private System.Windows.Forms.DateTimePicker dtPicker_StartTime;
        private System.Windows.Forms.Label lbl_DateRangeChangesSaved;
        private System.Windows.Forms.Label lbl_DateRangeUnsavedChanges;
        private System.Windows.Forms.Label lbl_DateRangeNoChanges;
        private System.Windows.Forms.ListBox lb_DateRange;
        private System.Windows.Forms.TextBox txtBox_Fallback;
        private System.Windows.Forms.Label lbl_Fallback;
        private System.Windows.Forms.Button btn_RunDateLabelMacros;
        private System.Windows.Forms.DataGridView dgView_AppSettings;
        private System.Windows.Forms.GroupBox grpBox_Config;
        private System.Windows.Forms.Button btn_ClearLogs;
        private System.Windows.Forms.Button btn_SaveAppSettings;
        private System.Windows.Forms.Button btn_DeleteAppSetting;
        private System.Windows.Forms.ListBox lb_DateRangesRunView;
        private System.Windows.Forms.ProgressBar pb_RunDateTimeMacros;
        private System.Windows.Forms.GroupBox gb_RunDateTimeMacrosStatus;
        private System.Windows.Forms.Label lbl_RunDateTimeMacrosProgress;
    }
}

