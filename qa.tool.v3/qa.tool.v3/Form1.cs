using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.InteropServices;
using QA_Tool_Standalone.Repository;
using QA_Tool_Standalone.Models;
using QA_Tool_Standalone.Service;

namespace QA_Tool_Standalone
{
    public partial class Form1 : Form
    {

        private Excel.Worksheet _activeSheet;
        private Excel.Workbook _activeWB;
        private ConnectionManager _connectionManager;

        public Form1()
        {
            LoggerService.Log("Starting session.....");
            InitializeComponent();
            _connectionManager = new ConnectionManager();

            SetupLogger();
            InitTreeView();
            InitColumnList();
            InitDateRangeList();

            lbl_ChangesSaved.Visible = false;
            lbl_UnsavedChanges.Visible = false;
            lbl_NoChanges.Visible = true;

            lbl_DateRangeChangesSaved.Visible = false;
            lbl_DateRangeUnsavedChanges.Visible = false;
            lbl_DateRangeNoChanges.Visible = true;
        }

        private void SetupLogger()
        {
            LoggerService.DoLogDebug = ConfigRepository.GetBooleanOption(_connectionManager, "Logger.DoLogDebug", true);
            LoggerService.DoLogWarning = ConfigRepository.GetBooleanOption(_connectionManager, "Logger.DoLogWarning", true);
            LoggerService.DoLogError = ConfigRepository.GetBooleanOption(_connectionManager, "Logger.DoLogError", true);
        }
        private void SetActive(Utilities.Double<string> node)
        {
            _activeWB = null;
            lbl_TargetSheet.Text = "Target Sheet: n/a";
            foreach (Excel.Workbook wb in MSExcelWorkbookRunningInstances.Enum())
            {

                if (wb.Name == node.A)
                {
                    _activeWB = wb;
                    break;
                }
            }
            if (_activeWB == null)
            {
                MessageBox.Show("Unable to load worksheet. Worksheet '" + node.A + "'was not found.");
                return;
            }
            else
            {
                _activeSheet = _activeWB.Sheets[node.B];
                lbl_TargetSheet.Text = _activeWB.Name + "." + _activeSheet.Name;
            }
        }





        private void TextBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }

        private void InitTreeView()
        {
            LoggerService.Log("Initializing treeview.");
            try
            {
                treeView_WBWS.Nodes.Clear();
                uint counter = 0;
                foreach (dynamic wb in MSExcelWorkbookRunningInstances.Enum())
                {

                    TreeNode node = treeView_WBWS.Nodes.Add(wb.Name);
                    foreach (Excel.Worksheet ws in wb.Worksheets)
                    {
                        node.Nodes.Add(ws.Name);
                        counter++;
                    }
                }
                LoggerService.Log("Finished initializing treeview");
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                treeView_WBWS.Nodes.Clear();
            }

        }

        private void InitColumnList()
        {
            LoggerService.Log("Initializing column list");
            chkLB_TargetColumns.Items.Clear();
            LB_EditColumns.Items.Clear();
            List<ColumnData> data = ColumnDataRepository.GetColumnData(_connectionManager, "%", "%");
            
            foreach (ColumnData columnRange in data)
            {
                chkLB_TargetColumns.Items.Add(columnRange);
                LB_EditColumns.Items.Add(columnRange);
            }
            LoggerService.Log("Finished loading column data");

        }

        private void InitDateRangeList()
        {
            LoggerService.Log("Initializing date range list");
            lb_DateRange.Items.Clear();
            List<DateRange> data = DateRangeRepository.GetDateRanges(_connectionManager, "%");

            foreach (DateRange dateRange in data)
            {
                lb_DateRange.Items.Add(dateRange);
            }
            LoggerService.Log("Finished loading date ranges");
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TreeView_WBWS_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count == 0 && e.Node.Parent != null)
            {

                Utilities.Double<string> node = new Utilities.Double<string>(e.Node.Parent.Text, e.Node.Text);

                SetActive(node);
            }

        }

        private Utilities.Double<string> GetActiveChoice()
        {
            if (treeView_WBWS.SelectedNode != null && treeView_WBWS.SelectedNode.Nodes.Count == 0 && treeView_WBWS.SelectedNode.Parent != null)
            {
                Utilities.Double<string> node = new Utilities.Double<string>(treeView_WBWS.SelectedNode.Parent.Text, treeView_WBWS.SelectedNode.Text);
                return node;
            }
            else
            {
                LoggerService.Log("Non-terminal error: Unable to retrieve selected node data.");
                return null;
            }
        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void ChkLB_TargetColumns_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox_Description.Text = ((ColumnData)LB_EditColumns.Items[LB_EditColumns.SelectedIndex]).Name;
                textBox_ColumnCodes.Text = ((ColumnData)LB_EditColumns.Items[LB_EditColumns.SelectedIndex]).Data;
            }
            catch (Exception ex)
            {
                LoggerService.Log("Non-terminal error: " + ex.ToString());
            }
        }



        private void Button6_Click(object sender, EventArgs e)
        {
            // Save as new
            if (textBox_Description.Text.Length <= 0)
            {
                MessageBox.Show("Description must not be blank", "Invalid Input");
            }
            if (ValidatorService.ValidateColumnFormat(textBox_ColumnCodes.Text))
            {
                ColumnData cd = new ColumnData(textBox_Description.Text, textBox_ColumnCodes.Text);
                ColumnDataRepository.AddColumnData(_connectionManager, cd);
                InitColumnList();

                lbl_ChangesSaved.Visible = false;
                lbl_UnsavedChanges.Visible = false;
                lbl_NoChanges.Visible = true;

            }
            else
            {
                MessageBox.Show("Invalid column range format. Must be like A:C,W:Z", "Invalid Format!");
            }

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (LB_EditColumns.SelectedItem == null)
                {
                    MessageBox.Show("Must select an item to save changes.", "Please select item");
                    return;
                }
                if (ValidatorService.ValidateColumnFormat(textBox_ColumnCodes.Text))
                {
                    ((ColumnData)LB_EditColumns.SelectedItem).Name = textBox_Description.Text;
                    ((ColumnData)LB_EditColumns.SelectedItem).Data = textBox_ColumnCodes.Text;

                    ColumnDataRepository.UpdateColumnData(_connectionManager, (ColumnData)LB_EditColumns.SelectedItem);
                    lbl_ChangesSaved.Visible = true;
                    lbl_UnsavedChanges.Visible = false;
                    lbl_NoChanges.Visible = false;


                }
                else
                {
                    MessageBox.Show("Invalid column range format. Must be like A:C,W:Z", "Invalid Format!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("A non-terminal error has occurred. No worries.", "Every little thing will be alright.");
                LoggerService.Log("Non-terminal exception occurred: " + ex.ToString());
            }
        }

        private void LB_EditColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (LB_EditColumns.SelectedIndex >= 0)
                {
                    textBox_Description.Text = ((ColumnData)LB_EditColumns.Items[LB_EditColumns.SelectedIndex]).Name;
                    textBox_ColumnCodes.Text = ((ColumnData)LB_EditColumns.Items[LB_EditColumns.SelectedIndex]).Data;

                    btn_SaveChanges.Enabled = true;
                    lbl_ChangesSaved.Visible = false;
                    lbl_UnsavedChanges.Visible = false;
                    lbl_NoChanges.Visible = true;
                }
            }
            catch (Exception ex)
            {
                LoggerService.Log("Non-terminal error: " + ex.ToString());
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            btn_Refresh.UseWaitCursor = true;
            InitTreeView();
            btn_Refresh.UseWaitCursor = false;

        }

        private List<string> GetColumnsToHide()
        {
            List<string> cols = new List<string>();
            foreach (var obj in chkLB_TargetColumns.CheckedItems)
            {
                ColumnData cd = (ColumnData)obj;
                cols.Add(cd.Data);
            }
            return cols;
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {

            if (_activeSheet != null)
            {
                List<string> cols = GetColumnsToHide();
                foreach (string col in cols)
                {
                    _activeSheet.Range[col].EntireColumn.Hidden = !_activeSheet.Range[col].EntireColumn.Hidden;

                }

               
                if (chkBox_ConvertToXLS.Checked && _activeWB.FullName.ToLower().EndsWith("csv"))
                {
                    string oldFilePath = _activeWB.FullName;
                    string filepath = System.IO.Path.ChangeExtension(_activeWB.FullName, ".xlsx");
                    LoggerService.Log("Converting file '"+_activeWB.FullName+"' to file: '" + filepath + "'...");
                    _activeWB.SaveAs(filepath, Excel.XlFileFormat.xlOpenXMLWorkbook, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    LoggerService.Log("...action completed.");

                    if (chkBox_DeleteOldCSV.Checked)
                    {
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                            LoggerService.Log("Successfully deleted file '" + oldFilePath + "'.");
                        }
                        else
                        {
                            LoggerService.LogWarning("Unable to delete file '" + oldFilePath + "'. File does not exist.");
                        }
                    }
                }



                if (chkBox_SaveAsNewFile.Checked)
                {
                    if (System.IO.Directory.Exists(txtBox_OutputFolder.Text))
                    {
                        string fName = txtBox_OutputFolder.Text + "\\" + txtBox_Prefix.Text + _activeWB.Name;
                        try
                        {
                            _activeWB.SaveAs(fName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                            LoggerService.Log("Saved file '" + fName + "'.");
                        }
                        catch (Exception ex)
                        {
                            LoggerService.LogError("An error has occurred while trying to save the file '" + fName + "': " + ex.ToString());
                            MessageBox.Show("Hmm. Something went wrong. Columns were hidden but unable to save the file. See logs for more details.", "Error");
                        }
                    }
                    else
                    {
                        LoggerService.LogError("Columns were hidden, but unable to save file. Directory '" + txtBox_OutputFolder.Text + "' is not a valid directory");
                        MessageBox.Show("Columns were hidden, but unable to save file. Directory '" + txtBox_OutputFolder.Text + "' is not a valid directory.", "Warning!");
                    }
                }
            }

        }

        private void TextBox_ColumnCodes_TextChanged(object sender, EventArgs e)
        {
            if (LB_EditColumns.SelectedItem != null)
            {
                lbl_ChangesSaved.Visible = false;
                lbl_UnsavedChanges.Visible = true;
                lbl_NoChanges.Visible = false;
            }
        }

        private void TextBox_Description_TextChanged(object sender, EventArgs e)
        {
            if (LB_EditColumns.SelectedItem != null)
            {
                lbl_ChangesSaved.Visible = false;
                lbl_UnsavedChanges.Visible = true;
                lbl_NoChanges.Visible = false;
            }
        }

        private void Btn_DeleteColumnData_Click(object sender, EventArgs e)
        {
            if (LB_EditColumns.SelectedItem != null)
            {
                ColumnData cdToDelete = (ColumnData)LB_EditColumns.SelectedItem;
                ColumnDataRepository.DeleteColumnData(_connectionManager, cdToDelete);
                InitColumnList();
            }
            else
            {
                MessageBox.Show("Please select item.", "Select item");
            }
        }

        private void btn_ChooseDestFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f1 = new FolderBrowserDialog();
            if (f1.ShowDialog() == DialogResult.OK)
            {
                txtBox_OutputFolder.Text = f1.SelectedPath;
            }
        }

        private void txtBox_OutputFolder_TextChanged(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(txtBox_OutputFolder.Text))
            {
                txtBox_OutputFolder.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                txtBox_OutputFolder.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void btn_ClearLogs_Click(object sender, EventArgs e)
        {
            LoggerService.ClearLogs();
        }


        private void chkBox_ConvertToXLS_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void grpBox_Config_Enter(object sender, EventArgs e)
        {

        }

        private void txtBox_dateColumn_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtPicker_StartDate_ValueChanged(object sender, EventArgs e)
        {
            if (lb_DateRange.SelectedItem != null)
            {
                lbl_DateRangeUnsavedChanges.Visible = true;
                lbl_DateRangeNoChanges.Visible = false;
                lbl_DateRangeChangesSaved.Visible = false;
            }
        }


        private void btn_SaveDateRangeAsNew_Click(object sender, EventArgs e)
        {
            // Save as new

            if (txtBox_DateRangeLabel.Text.Length <= 0)
            {
                MessageBox.Show("Label must not be blank", "Invalid Input");
                return;
            }

            DateRange dateRange = new DateRange();

            dateRange.Label = txtBox_DateRangeLabel.Text;
            dateRange.StartTime = dtPicker_StartDate.Value.Add(dtPicker_StartTime.Value.TimeOfDay);
            dateRange.EndTime = dtPicker_EndDate.Value.Add(dtPicker_EndTime.Value.TimeOfDay);


            DateRangeRepository.AddDateRange(_connectionManager, dateRange);

            InitDateRangeList();

            lbl_DateRangeChangesSaved.Visible = false;
            lbl_DateRangeUnsavedChanges.Visible = false;
            lbl_DateRangeNoChanges.Visible = true;

            
        }

        private void btn_SaveDateRange_Click(object sender, EventArgs e)
        {
            try
            {
                if (lb_DateRange.SelectedItem == null)
                {
                    MessageBox.Show("Must select an item to save changes.", "Please select item");
                    return;
                }

                ((DateRange)lb_DateRange.SelectedItem).Label = txtBox_DateRangeLabel.Text;
                ((DateRange)lb_DateRange.SelectedItem).StartTime = dtPicker_StartDate.Value.Add(dtPicker_StartTime.Value.TimeOfDay);
                ((DateRange)lb_DateRange.SelectedItem).EndTime = dtPicker_EndDate.Value.Add(dtPicker_EndTime.Value.TimeOfDay);

                DateRangeRepository.UpdateDateRange(_connectionManager, (DateRange)lb_DateRange.SelectedItem);

                lbl_DateRangeChangesSaved.Visible = true;
                lbl_DateRangeUnsavedChanges.Visible = false;
                lbl_DateRangeNoChanges.Visible = false;

                var selectedIndex = lb_DateRange.SelectedIndex;
                InitDateRangeList();

                lb_DateRange.SetSelected(selectedIndex, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("A non-terminal error has occurred. No worries.", "Every little thing will be alright.");
                LoggerService.Log("Non-terminal exception occurred: " + ex.ToString());
            }
        }

        private void btn_DeleteDateRange_Click(object sender, EventArgs e)
        {
            if (lb_DateRange.SelectedItem != null)
            {
                DateRange drToDelete = (DateRange)lb_DateRange.SelectedItem;
                DateRangeRepository.DeleteDateRange(_connectionManager, drToDelete);
                InitDateRangeList();
            }
            else
            {
                MessageBox.Show("Please select item.", "Select item");
            }
        }

        private void txtBox_DateRangeLabel_TextChanged(object sender, EventArgs e)
        {
            if (lb_DateRange.SelectedItem != null)
            {
                lbl_DateRangeUnsavedChanges.Visible = true;
                lbl_DateRangeNoChanges.Visible = false;
                lbl_DateRangeChangesSaved.Visible = false;
            }
        }

        private void lb_DateRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lb_DateRange.SelectedIndex >= 0)
                {
                    txtBox_DateRangeLabel.Text = ((DateRange)lb_DateRange.Items[lb_DateRange.SelectedIndex]).Label;
                    dtPicker_StartDate.Value = ((DateRange)lb_DateRange.Items[lb_DateRange.SelectedIndex]).StartTime.Date;
                    dtPicker_StartTime.Value = ((DateRange)lb_DateRange.Items[lb_DateRange.SelectedIndex]).StartTime;
                    dtPicker_EndDate.Value = ((DateRange)lb_DateRange.Items[lb_DateRange.SelectedIndex]).EndTime.Date;
                    dtPicker_EndTime.Value = ((DateRange)lb_DateRange.Items[lb_DateRange.SelectedIndex]).EndTime;

                    btn_SaveDateRange.Enabled = true;
                    lbl_DateRangeChangesSaved.Visible = false;
                    lbl_DateRangeUnsavedChanges.Visible = false;
                    lbl_DateRangeNoChanges.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                LoggerService.Log("Non-terminal error: " + ex.ToString());
            }
        }

        private void dtPicker_StartTime_ValueChanged(object sender, EventArgs e)
        {
            if (lb_DateRange.SelectedItem != null)
            {
                lbl_DateRangeUnsavedChanges.Visible = true;
                lbl_DateRangeNoChanges.Visible = false;
                lbl_DateRangeChangesSaved.Visible = false;
            }
        }

        private void dtPicker_EndDate_ValueChanged(object sender, EventArgs e)
        {
            if (lb_DateRange.SelectedItem != null)
            {
                lbl_DateRangeUnsavedChanges.Visible = true;
                lbl_DateRangeNoChanges.Visible = false;
                lbl_DateRangeChangesSaved.Visible = false;
            }
        }

        private void dtPicker_EndTime_ValueChanged(object sender, EventArgs e)
        {
            if (lb_DateRange.SelectedItem != null)
            {
                lbl_DateRangeUnsavedChanges.Visible = true;
                lbl_DateRangeNoChanges.Visible = false;
                lbl_DateRangeChangesSaved.Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_RunDateLabelMacros_Click(object sender, EventArgs e)
        {
            string dateColumn = txtBox_dateColumn.Text;
            string targetColumn = txtBox_targetColumn.Text;
            if (!(ValidatorService.ValidateSingleColumn(dateColumn) && ValidatorService.ValidateSingleColumn(targetColumn)))
            {
                MessageBox.Show("Expect date column and target column to be a single column value.");
                return;
            }

            if (_activeSheet != null)
            {
                var xlRange = _activeSheet.UsedRange;

                for (int i = 1; i <= xlRange.Rows.Count; i++)
                {
                    Excel.Range rawDateColumn = xlRange.Rows[i].Columns[dateColumn];

                    if (rawDateColumn != null)
                    {
                        if (rawDateColumn.Value is System.DateTime)
                        {
                            string label = DateRangeRepository.GetDateLabelsForDateTime(_connectionManager, rawDateColumn.Value, txtBox_Fallback.Text);
                            xlRange.Rows[i].Columns[targetColumn] = label;
                        }
                        else
                        {
                            LoggerService.Log($"Date column in row {i.ToString()} was not of type System.DateTime");
                        }
                    }
                    else
                    {
                        LoggerService.Log($"Date column in row {i.ToString()} was null.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a target worksheet");
            }
        }

    }
}
