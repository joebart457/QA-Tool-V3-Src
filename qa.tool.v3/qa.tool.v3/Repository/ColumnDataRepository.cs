using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using QA_Tool_Standalone.Models;

namespace QA_Tool_Standalone.Repository
{
    static class ColumnDataRepository
    {
        public static List<ColumnData> GetColumnData(ConnectionManager cm, string nameFilter, string dataFilter)
        {
            try
            {
                List<ColumnData> columnData = new List<ColumnData>();
                var conn = cm.GetSQLConnection();
                var selectColumnDataCmd = conn.CreateCommand();

                selectColumnDataCmd.CommandText = @"SELECT id, name, data FROM excel_column_data WHERE name like @NameFilter AND data like @DataFilter";
                selectColumnDataCmd.Parameters.Add(new SQLiteParameter("@NameFilter", nameFilter));
                selectColumnDataCmd.Parameters.Add(new SQLiteParameter("@DataFilter", dataFilter));

                var reader = selectColumnDataCmd.ExecuteReader();
                while (reader.Read())
                {
                    columnData.Add(new ColumnData(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                }

                return columnData;
            } catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }


        public static void AddColumnData(ConnectionManager cm, ColumnData columnData)
        {
            try
            {
                var conn = cm.GetSQLConnection();
                var insertColumnDataCmd = conn.CreateCommand();

                insertColumnDataCmd.CommandText = @"INSERT INTO excel_column_data (name, data) VALUES (@Name, @Data)";
                insertColumnDataCmd.Parameters.Add(new SQLiteParameter("@Name", columnData.Name));
                insertColumnDataCmd.Parameters.Add(new SQLiteParameter("@Data", columnData.Data));

                insertColumnDataCmd.ExecuteNonQuery();
            } catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }

        public static void UpdateColumnData(ConnectionManager cm, ColumnData columnData)
        {
            try
            {
                var conn = cm.GetSQLConnection();
                var updateColumnDataCmd = conn.CreateCommand();

                updateColumnDataCmd.CommandText = @"UPDATE excel_column_data SET name=@Name, data=@Data WHERE id=@Id";
                updateColumnDataCmd.Parameters.Add(new SQLiteParameter("@Id", columnData.Id));
                updateColumnDataCmd.Parameters.Add(new SQLiteParameter("@Name", columnData.Name));
                updateColumnDataCmd.Parameters.Add(new SQLiteParameter("@Data", columnData.Data));

                updateColumnDataCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }

        public static void DeleteColumnData(ConnectionManager cm, ColumnData columnData)
        {
            try
            {
                var conn = cm.GetSQLConnection();
                var deleteColumnDataCmd = conn.CreateCommand();

                deleteColumnDataCmd.CommandText = @"DELETE FROM excel_column_data WHERE id=@Id";
                deleteColumnDataCmd.Parameters.Add(new SQLiteParameter("@Id", columnData.Id));

                deleteColumnDataCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }
    }
}
