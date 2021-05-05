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
using QA_Tool_Standalone.Tasks;
using System.Data.SQLite;

namespace QA_Tool_Standalone
{
    public partial class Form1 : Form
    {

        private Excel.Worksheet _activeSheet;
        private Excel.Workbook _activeWB;
        private ConnectionManager _connectionManager;

        private DataTable _configDataTable;

        public Form1()
        {
            LoggerService.Log("Starting session.....");
            InitializeComponent();
            _connectionManager = new ConnectionManager();

            SetupLogger();
            SetupAppSettingsTable();
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

        private void Form1_Load(object sender, EventArgs e)
        {
     
        }

        private void SetupAppSettingsTable()
        {
            string selectConfigSql = @"select id, param, value from config";
            using (SQLiteCommand command = new SQLiteCommand(selectConfigSql, _connectionManager.GetSQLConnection()))
            {
                _configDataTable = new DataTable();
                _configDataTable.Load(command.ExecuteReader());
                dgView_AppSettings.DataSource = _configDataTable;
            }
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
            lb_DateRangesRunView.Items.Clear();

            List<DateRange> data = DateRangeRepository.GetDateRanges(_connectionManager, "%");

            foreach (DateRange dateRange in data)
            {
                lb_DateRange.Items.Add(dateRange);
                lb_DateRangesRunView.Items.Add(dateRange);
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
            // Hide/Unhide Columns
            if (_activeWB != null && _activeSheet != null)
            {
                try
                {
                    ExcelHideColumnsTask task = new ExcelHideColumnsTask(
                        _activeWB,
                        _activeSheet,
                        GetColumnsToHide(),
                        ConfigRepository.GetBooleanOption(_connectionManager, "Excel.HideColumns.Output.ConvertToXLS", false),
                        ConfigRepository.GetBooleanOption(_connectionManager, "Excel.HideColumns.Output.DeleteOldCSV", false),
                        ConfigRepository.GetBooleanOption(_connectionManager, "Excel.HideColumns.Output.SaveAsNew", false),
                        ConfigRepository.GetStringOption(_connectionManager, "Excel.HideColumns.Output.Folder", ""),
                        ConfigRepository.GetStringOption(_connectionManager, "Excel.HideColumns.Output.Prefix", "hdn-"));
                    task.Execute(() => { });

                } catch (TaskException te) {
                    MessageBox.Show(te.ToString(), "Error in Task");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Program Error");
                }

            } else
            {
                MessageBox.Show("Please select a target sheet.");
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

        private void btn_RunDateLabelMacros_Click(object sender, EventArgs e)
        {
            if (_activeSheet != null)
            {
                try
                {
                    pb_RunDateTimeMacros.Value = 0;
                    pb_RunDateTimeMacros.Maximum = _activeSheet.UsedRange.Rows.Count;
                    pb_RunDateTimeMacros.PerformStep();

                    ExcelRunDateLabelMacrosTask task = new ExcelRunDateLabelMacrosTask(
                        _connectionManager,
                        _activeSheet,
                        txtBox_dateColumn.Text,
                        txtBox_targetColumn.Text,
                        txtBox_Fallback.Text
                        );

                    task.Execute(() => { pb_RunDateTimeMacros.PerformStep(); });
                } catch (TaskException te)
                {
                    MessageBox.Show(te.ToString(), "Error in Task");
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Program Error");
                }
            }
            else
            {
                MessageBox.Show("Please select a target worksheet");
            }
        }

        private void btn_SaveAppSettings_Click(object sender, EventArgs e)
        {
            using (SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(@"select id, param, value from config", _connectionManager.GetSQLConnection()))
            {
                SQLiteCommandBuilder commandBuilder = new SQLiteCommandBuilder(sQLiteDataAdapter);
                sQLiteDataAdapter.Update(_configDataTable);
            }
        }

        private void btn_DeleteAppSetting_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgView_AppSettings.SelectedRows)
            {
                if (row.Cells[0].Value != null)
                {
                    ConfigRepository.DeleteParameter(_connectionManager, int.Parse(row.Cells[0].Value.ToString()));
                }   
            }
            SetupAppSettingsTable();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
    }
}
