using QA_Tool_Standalone.Repository;
using QA_Tool_Standalone.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace QA_Tool_Standalone.Tasks
{
    class ExcelRunDateLabelMacrosTask: TaskInterface
    {
        private string _dateColumn { get; set; }
        private string _targetColumn { get; set; }
        private string _fallback { get; set; }
        private ConnectionManager _connectionManager { get; set; }

        private Excel.Worksheet _activeSheet { get; set; }

        public ExcelRunDateLabelMacrosTask(ConnectionManager connectionManager, Excel.Worksheet activeSheet, 
            string dateColumn, string targetColumn, string fallback)
        {
            _connectionManager = connectionManager;
            _activeSheet = activeSheet;
            _dateColumn = dateColumn;
            _targetColumn = targetColumn;
            _fallback = fallback;
        }

        public void Execute(CallBack callback)
        {

            if (!(ValidatorService.ValidateSingleColumn(_dateColumn) && ValidatorService.ValidateSingleColumn(_targetColumn)))
            {
               throw new TaskException("Expect date column and target column to be a single column value.");
            }

            if (_activeSheet != null)
            {
                var xlRange = _activeSheet.UsedRange;

                for (int i = 1; i <= xlRange.Rows.Count; i++)
                {
                    Excel.Range rawDateColumn = xlRange.Rows[i].Columns[_dateColumn];

                    if (rawDateColumn != null)
                    {
                        if (rawDateColumn.Value is System.DateTime)
                        {
                            string label = DateRangeRepository.GetDateLabelsForDateTime(_connectionManager, rawDateColumn.Value, _fallback);
                            xlRange.Rows[i].Columns[_targetColumn] = label;
                        }
                        else
                        {
                            LoggerService.LogWarning($"Date column in row {i.ToString()} was not of type System.DateTime");
                        }
                    }
                    else
                    {
                        LoggerService.LogWarning($"Date column in row {i.ToString()} was null.");
                    }
                    callback();
                }
            }
            else
            {
                throw new TaskException("Target sheet was null");
            }
        }
    }
}
