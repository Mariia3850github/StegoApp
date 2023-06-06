using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stego_app
{
    
    internal class LogFile
    {
        private const string logname = "Stego_App.log";

        public static void tolog(string str)
        {
            DateTime localDate = DateTime.Now;
            StreamWriter sw= new StreamWriter(logname, true);
            sw.Write(localDate.ToString()+"  "+str+Environment.NewLine);
            sw.Close();
        }

    }
}
