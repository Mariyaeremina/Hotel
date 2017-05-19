using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static void Log(string type, string message)
        {
            message += DateTime.Now.ToString("dd.mm.yyyy hh.mm.ss");
            File.AppendAllText("log.txt", message);
        }
    static void Main(string[] args)
        {
            
        }
    }
}
