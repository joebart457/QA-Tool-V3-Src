using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QA_Tool_Standalone
{


    public class ColumnData
    {
        public string Name { get; set; }
        public string Data { get; set; }

        public ColumnData(string name, string data)
        {
            this.Name = name;
            this.Data = data;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

    static class ColumnDataLoaderService
    {
        static public List<ColumnData> GetDataFromFile(string filePath)
        {
            int counter = 0;
            string line = "";
            List<ColumnData> data = new List<ColumnData>();

            
            if (!System.IO.File.Exists(filePath))
            {
                LoggerService.Log("Could not open file: '" + filePath + "'.");
                System.IO.File.Create(filePath).Dispose();
                System.IO.StreamReader file = new System.IO.StreamReader(filePath);

                while ((line = file.ReadLine()) != null)
                {
                    line = line.Trim();
                    LoggerService.Log("Read '" + line + "' from file: '" + filePath + "'");

                    ColumnData cd = GetColumnData(line);
                    if (cd != null)
                    {
                        LoggerService.Log("Verified line.");
                        data.Add(cd);
                    }
                    else
                    {
                        LoggerService.Log("Failed to verify line. Skipping...");
                    }
                    counter++;
                }
                file.Close();
                LoggerService.Log("Finished reading " + counter.ToString() + " lines from file: " + filePath);
                return data;
            }
            else
            {
                System.IO.StreamReader file = new System.IO.StreamReader(filePath);
                while ((line = file.ReadLine()) != null)
                {
                    line = line.Trim();
                    LoggerService.Log("Read '" + line + "' from file: '" + filePath + "'");

                    ColumnData cd = GetColumnData(line);
                    if (cd != null)
                    {
                        LoggerService.Log("Verified line.");
                        data.Add(cd);
                    }
                    else
                    {
                        LoggerService.Log("Failed to verify line. Skipping...");
                    }
                    counter++;
                }
                file.Close();
                LoggerService.Log("Finished reading " + counter.ToString() + " lines from file: " + filePath);
                return data;
            }

           
        }

        static public bool VerifyColumnFormat(string str)
        {
            string[] columnRanges = str.Split(',');
            foreach(string colRange in columnRanges)
            {
                string[] cols = colRange.Split(':');
                if (cols.Length == 2)
                {
                    foreach(string column in cols)
                    {
                        foreach (char c in column){
                            if (Char.IsLetter(c))
                            {
                                continue;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        static public ColumnData GetColumnData(string raw)
        {
            string[] data = raw.Split('|');
            if (data.Length == 2)
            {
                if (VerifyColumnFormat(data[1]))
                {
                    ColumnData cd = new ColumnData(data[0], data[1]);
                    return cd;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }


        public static void AddColumn(string filePath, ColumnData cd)
        {
            if (System.IO.File.Exists(filePath))
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true);

                StringBuilder sb = new StringBuilder();
                sb.Append(cd.Name);
                sb.Append("|");
                sb.Append(cd.Data);
                LoggerService.Log("Adding columndata: " + sb.ToString());
                file.WriteLine(sb.ToString());
                file.Close();
            }
            else
            {
                LoggerService.Log(filePath + " does not exist. Creating it...");
                System.IO.File.Create(filePath).Dispose();
                System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true);

                StringBuilder sb = new StringBuilder();
                sb.Append(cd.Name);
                sb.Append("|");
                sb.Append(cd.Data);
                LoggerService.Log("Adding columndata: " + sb.ToString());
                file.WriteLine(sb.ToString());
                file.Close();
            }
        }


        public static void WriteColumnDataToFile(string filePath, List<ColumnData> lsColumnData, bool overwrite)
        {
            if (System.IO.File.Exists(filePath))
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, !overwrite);
                foreach (ColumnData cd in lsColumnData)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(cd.Name);
                    sb.Append("|");
                    sb.Append(cd.Data);
                    LoggerService.Log("Adding columndata: " + sb.ToString());
                    file.WriteLine(sb.ToString());
                }
                file.Close();
            }
            else
            {
                LoggerService.Log(filePath + " does not exist. Creating it...");
                System.IO.File.Create(filePath).Dispose();
                System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, !overwrite);
                foreach (ColumnData cd in lsColumnData)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(cd.Name);
                    sb.Append("|");
                    sb.Append(cd.Data);
                    LoggerService.Log("Adding columndata: " + sb.ToString());
                    file.WriteLine(sb.ToString());
                }
                file.Close();
            }
        }

    }
}
