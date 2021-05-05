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
                LoggerService.LogError(ex.ToString());
                return onFail;
            }
        }

        public static string GetStringOption(ConnectionManager cm, string param, string onFail)
        {
            try
            {
                var conn = cm.GetSQLConnection();
                var selectParamCmd = conn.CreateCommand();

                selectParamCmd.CommandText = @"SELECT param, value FROM config WHERE param like @ParameterName";
                selectParamCmd.Parameters.Add(new SQLiteParameter("@ParameterName", "%" + param + "%"));

                string result = onFail;
                var reader = selectParamCmd.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetString(1);
                }

                return result;
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                return onFail;
            }
        }


        public static void SetParameterValue(ConnectionManager cm, string param, string value)
        {
            try
            {
                var conn = cm.GetSQLConnection();
                var updateParamCmd = conn.CreateCommand();

                updateParamCmd.CommandText = @"UPDATE config SET value=@Value WHERE param=@ParameterName";
                updateParamCmd.Parameters.Add(new SQLiteParameter("@Value", value));
                updateParamCmd.Parameters.Add(new SQLiteParameter("@ParameterName", param));

                updateParamCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }

        public static void DeleteParameter(ConnectionManager cm, int id)
        {
            try
            {
                var conn = cm.GetSQLConnection();
                var deleteParamCmd = conn.CreateCommand();

                deleteParamCmd.CommandText = @"DELETE FROM config WHERE id=@Id";
                deleteParamCmd.Parameters.Add(new SQLiteParameter("@Id", id));

                deleteParamCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }



    }
}
