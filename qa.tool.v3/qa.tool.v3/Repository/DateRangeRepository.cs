using QA_Tool_Standalone.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Tool_Standalone.Repository
{
    class DateRangeRepository
    {
        public static List<DateRange> GetDateRanges(ConnectionManager cm, string labelFilter)
        {
            try
            {
                List<DateRange> dateRanges = new List<DateRange>();
                var conn = cm.GetSQLConnection();
                var selectDateRangesCmd = conn.CreateCommand();

                selectDateRangesCmd.CommandText = @"SELECT id, label, start_time, end_time FROM date_range WHERE label like @Label";
                selectDateRangesCmd.Parameters.Add(new SQLiteParameter("@Label", labelFilter));

                var reader = selectDateRangesCmd.ExecuteReader();
                while (reader.Read())
                {
                    dateRanges.Add(new DateRange
                    {
                        Id = reader.GetInt32(0),
                        Label = reader.GetString(1),
                        StartTime = new DateTime(reader.GetInt64(2)),
                        EndTime = new DateTime(reader.GetInt64(3))
                    });
                }

                return dateRanges;
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }

        public static void AddDateRange(ConnectionManager cm, DateRange dateRange)
        {
            try
            {
                var conn = cm.GetSQLConnection();
                var insertDateRangeCmd = conn.CreateCommand();

                insertDateRangeCmd.CommandText = @"INSERT INTO date_range (start_time, end_time, label) VALUES (@StartTime, @EndTime, @Label)";
                insertDateRangeCmd.Parameters.Add(new SQLiteParameter("@StartTime", dateRange.StartTime.Ticks));
                insertDateRangeCmd.Parameters.Add(new SQLiteParameter("@EndTime", dateRange.EndTime.Ticks));
                insertDateRangeCmd.Parameters.Add(new SQLiteParameter("@Label", dateRange.Label));

                insertDateRangeCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }

        public static void UpdateDateRange(ConnectionManager cm, DateRange dateRange)
        {
            try
            {
                var conn = cm.GetSQLConnection();
                var updateDateRangeCmd = conn.CreateCommand();

                updateDateRangeCmd.CommandText = @"UPDATE date_range SET label=@Label, start_time=@StartTime, end_time=@EndTime WHERE id=@Id";
                updateDateRangeCmd.Parameters.Add(new SQLiteParameter("@Id", dateRange.Id));
                updateDateRangeCmd.Parameters.Add(new SQLiteParameter("@Label", dateRange.Label));
                updateDateRangeCmd.Parameters.Add(new SQLiteParameter("@StartTime", dateRange.StartTime.Ticks));
                updateDateRangeCmd.Parameters.Add(new SQLiteParameter("@EndTime", dateRange.EndTime.Ticks));

                updateDateRangeCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }

        public static void DeleteDateRange(ConnectionManager cm, DateRange dateRange)
        {
            try
            {
                var conn = cm.GetSQLConnection();
                var deleteDateRangeCmd = conn.CreateCommand();

                deleteDateRangeCmd.CommandText = @"DELETE FROM date_range WHERE id=@Id";
                deleteDateRangeCmd.Parameters.Add(new SQLiteParameter("@Id", dateRange.Id));

                deleteDateRangeCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }

        public static string GetDateLabelsForDateTime(ConnectionManager cm, DateTime dt, string fallback = "")
        {
            try
            {
                string result = "";
                var conn = cm.GetSQLConnection();
                var selectLabelsCmd = conn.CreateCommand();

                selectLabelsCmd.CommandText = @"SELECT DISTINCT label FROM date_range WHERE @DateTime >= start_time AND @DateTime <= end_time";
                selectLabelsCmd.Parameters.Add(new SQLiteParameter("@DateTime", dt.Ticks));

                var reader = selectLabelsCmd.ExecuteReader();
                while (reader.Read())
                {
                    result += result.Length > 0? ","+ reader.GetString(0) : reader.GetString(0);
                }

                if (result.Length == 0)
                {
                    return fallback;
                }
                return result;
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex.ToString());
                throw ex;
            }
        }
    }
}
