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

namespace QA_Tool_Standalone
{
    public partial class Form1 : Form
    {

        private Excel.Worksheet _activeSheet;
        private Excel.Workbook _activeWB;



        public Form1()
        {
            LoggerService.Log("Starting session.....");
            InitializeComponent();
            InitTreeView();
            InitColumnList();

            lbl_ChangesSaved.Visible = false;
            lbl_UnsavedChanges.Visible = false;
            lbl_NoChanges.Visible = true;

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
            }
            catch (Exception ex)
            {
                treeView_WBWS.Nodes.Clear();
            }

        }

        private void InitColumnList()
        {
            chkLB_TargetColumns.Items.Clear();
            LB_EditColumns.Items.Clear();
            List<ColumnData> data = ColumnDataLoaderService.GetDataFromFile("column_data.txt");
            foreach (ColumnData columnRange in data)
            {
                chkLB_TargetColumns.Items.Add(columnRange);
                LB_EditColumns.Items.Add(columnRange);
            }
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
            if (ColumnDataLoaderService.VerifyColumnFormat(textBox_ColumnCodes.Text))
            {
                ColumnData cd = new ColumnData(textBox_Description.Text, textBox_ColumnCodes.Text);
                ColumnDataLoaderService.AddColumn("column_data.txt", cd);
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

                if (ColumnDataLoaderService.VerifyColumnFormat(textBox_ColumnCodes.Text))
                {
                    ((ColumnData)LB_EditColumns.SelectedItem).Name = textBox_Description.Text;
                    ((ColumnData)LB_EditColumns.SelectedItem).Data = textBox_ColumnCodes.Text;

                    ColumnDataLoaderService.WriteColumnDataToFile("column_data.txt", GetColumnDataListFromEditColumnsLB(), true);
                    if (LB_EditColumns.SelectedItem != null)
                    {
                        lbl_ChangesSaved.Visible = true;
                        lbl_UnsavedChanges.Visible = false;
                        lbl_NoChanges.Visible = false;
                    }


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

                LB_EditColumns.Items.Remove(LB_EditColumns.SelectedItem);

                ColumnDataLoaderService.WriteColumnDataToFile("column_data.txt", GetColumnDataListFromEditColumnsLB(), true);
                InitColumnList();

            }
            else
            {
                MessageBox.Show("Please select item.", "Select item");
            }
        }

        private List<ColumnData> GetColumnDataListFromEditColumnsLB()
        {
            List<ColumnData> lsCd = new List<ColumnData>();
            foreach (ColumnData cd in LB_EditColumns.Items)
            {
                lsCd.Add(cd);
            }
            return lsCd;
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

        private void btn_ClearColumns_Click(object sender, EventArgs e)
        {

        }

        private void chkBox_ConvertToXLS_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
