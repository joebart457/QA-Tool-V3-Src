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
                    cmd.CommandText = "select * from sqlite_master where type='table' AND name='config'";
                    bool tableFound = cmd.ExecuteScalar() != null;
                    if (!tableFound)
                    {
                        throw new Exception("Fatal! Invalid db data.");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                SetupNewDatabase();
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

                
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
