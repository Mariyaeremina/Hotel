using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Logging
    {
        public static void Log(string type, string message)
        {
            message = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss ") + message + Environment.NewLine;
            File.AppendAllText("log.txt", message);
        }
    }
}
