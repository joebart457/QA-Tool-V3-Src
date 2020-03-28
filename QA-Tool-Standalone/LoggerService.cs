using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;

namespace QA_Tool_Standalone
{
    public static class LoggerService
    {
        static public void Log(string msg)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("log.txt", true);

            StringBuilder sb = new StringBuilder();
            sb.Append(GetCurrentTimeString());
            sb.Append(": ");
            sb.Append(msg);
            file.WriteLine(sb.ToString());
            file.Close();
        }

        public static string GetCurrentTimeString()
        {
            DateTime localDate = DateTime.Now;
            CultureInfo culture = new CultureInfo("en-US");
            return localDate.ToString(culture);
        }
    }
}
