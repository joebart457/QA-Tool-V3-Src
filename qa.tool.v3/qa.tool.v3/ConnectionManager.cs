using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;


namespace QA_Tool_Standalone
{

    class ConnectionManager
    {
        private string _dbFileName { get; } = "data.db";
        private SQLiteConnection _sqlConn { get; set; }

        private List<string> RELEASES = new List<string>
        {
            "1.0.0"
        };

        public ConnectionManager() { CreateConnection(); }
        ~ConnectionManager() { }

        public SQLiteConnection GetSQLConnection()
        {
            if (_sqlConn != null)
            {
                return _sqlConn;
            }
            throw new Exception("Fatal! db was unitialized when requested.");
        }
        private void CreateConnection()
        {
            if (File.Exists(_dbFileName))
            {
                try
                {
                    _sqlConn = new SQLiteConnection($"Data Source={_dbFileName};");
                    _sqlConn.Open();
                    var cmd = _sqlConn.CreateCommand();
                    cmd.CommandText = "select value from config where param='Db.Version'";
                    object version = cmd.ExecuteScalar();
                    if (version == null || !(version is string))
                    {
                        throw new Exception("Fatal! Invalid db data.");
                    } else
                    {
                        string versionStr = version.ToString();
                        int index = RELEASES.FindIndex(x => x == versionStr);
                        if (index == -1)
                        {
                            throw new Exception("Invalid db version. Please update manually. Or recreate db.");
                        } else
                        {
                            for (int i = index; i < RELEASES.Count(); i++)
                            {
                                RunUpgrade(RELEASES.ElementAt(i));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LoggerService.LogError(ex.ToString());
                    throw ex;
                }
            }
            else
            {
                LoggerService.Log("Existing db not found. Creating...");
                SetupNewDatabase();
                LoggerService.Log("Finished new db creation.");
            }
        }

        private void UpgradeDatabase() { }

        private void SetupNewDatabase()
        {
            try
            {
                _sqlConn = new SQLiteConnection($"Data Source={_dbFileName};");
                _sqlConn.Open();

                var createConfigTblCmd = _sqlConn.CreateCommand();
                createConfigTblCmd.CommandText = @"CREATE TABLE config (
                	id	INTEGER NOT NULL,
                	param	TEXT NOT NULL UNIQUE,
                	value	TEXT,
                	PRIMARY KEY(id AUTOINCREMENT)
                )";

                createConfigTblCmd.ExecuteNonQuery();

                var createColumnDataTblCmd = _sqlConn.CreateCommand();
                createColumnDataTblCmd.CommandText = @"CREATE TABLE excel_column_data (
                	id	INTEGER NOT NULL,
                	name	TEXT NOT NULL,
                	data	TEXT NOT NULL,
                	PRIMARY KEY(id AUTOINCREMENT)
                );";

                createColumnDataTblCmd.ExecuteNonQuery();

                var createDateRangeTblCmd = _sqlConn.CreateCommand();
                createDateRangeTblCmd.CommandText = @"CREATE TABLE date_range (
                	id	INTEGER NOT NULL,
                	start_time	INTEGER NOT NULL,
                	end_time	INTEGER NOT NULL,
                	label	TEXT NOT NULL,
                	PRIMARY KEY(id AUTOINCREMENT)
                );";

                createDateRangeTblCmd.ExecuteNonQuery();

                SetApplicationSettings();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetApplicationSettings()
        {
            try
            {
                var insertAppParamsCmd = _sqlConn.CreateCommand();
                insertAppParamsCmd.CommandText = @"INSERT INTO config (param, value) 
                    VALUES  ('Db.Version', '1.0.0'),
                            ('Logger.DoLogDebug', 'true'),
                            ('Logger.DoLogWarning', 'true'),
                            ('Logger.DoLogError', 'true'),
                            ('Excel.HideColumns.Output.ConvertToXLS', 'true'),
                            ('Excel.HideColumns.Output.DeleteOldCSV', 'true'),
                            ('Excel.HideColumns.Output.SaveAsNew', 'true'),
                            ('Excel.HideColumns.Output.Prefix', 'hdn-'),
                            ('Excel.HideColumns.Output.Folder', '')";
                insertAppParamsCmd.ExecuteNonQuery();

            } catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }

        private void RunUpgrade(string upgradeVersion)
        {
            LoggerService.Log("Running upgrade :" + upgradeVersion);
            if (upgradeVersion == "1.0.0")
            {
                // Initial Release
            }
        }
    }
}
