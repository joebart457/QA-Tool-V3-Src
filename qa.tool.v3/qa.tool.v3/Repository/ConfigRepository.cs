using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Tool_Standalone.Repository
{
    class ConfigRepository
    {
        public static bool GetBooleanOption(ConnectionManager cm, string param, bool onFail)
        {
            try
            {
                var conn = cm.GetSQLConnection();
                var selectParamCmd = conn.CreateCommand();

                selectParamCmd.CommandText = @"SELECT param, value FROM config WHERE param like @ParameterName";
                selectParamCmd.Parameters.Add(new SQLiteParameter("@ParameterName", "%"+param+"%"));

                bool result = onFail;
                var reader = selectParamCmd.ExecuteReader();
                while (reader.Read())
                {
                    result = bool.Parse(reader.GetString(1));
                }

                return result;
            }
            catch (Exception ex)
            {
                return onFail;
            }
        }
    }
}
