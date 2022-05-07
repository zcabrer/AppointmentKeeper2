using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentKeeper2
{
    static class Logger
    {
        //Set the path to the log file .txt in the Documents folder
        private static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AppointmentKeeper_AuthLogs.txt";

        //Create the log file if it does not exist
        public static void initializeLogFile()
        {
            if (!File.Exists(path))
            {
                using (StreamWriter outputFile = File.CreateText(path))
                {
                    outputFile.WriteLine($"{DateTime.Now} - Log Created");
                }
            }
        }

        public static void writeLog(bool success, string user, DateTime timestamp)
        {
            using (StreamWriter outputFile = new StreamWriter(path, true))
            {
                if (success)
                {
                    outputFile.WriteLine($"{timestamp} - Successful login by {user}");
                }
                else
                {
                    outputFile.WriteLine($"{timestamp} - Failed login by {user}");
                }
            }
        }

    }
}
