using System;
using System.Collections.Generic;
using System.Text;

namespace Spruce_Wood_Loggers_ERP
{
    class DatabaseConfig
    {
        public string ipAddress { get; set; }
        public int port { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public static string getConfigPath()
        {
            return Environment.CurrentDirectory + @"\CutTrackerDBSettings.json";
        }
    }
}
