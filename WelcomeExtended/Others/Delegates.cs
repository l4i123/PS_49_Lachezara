using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WelcomeExtended.Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WelcomeExtended.Others
{
    public class Delegates
    {
        public static readonly ILogger logger = LoggerHelper.GetLogger("Hello", "logfile.txt");
        public static void Log(string error)
        {
            logger.LogError(error);
        }
        public static void Log2(string error)
        {
            Console.WriteLine("- Delegates -");
            Console.WriteLine($"{error}");
            Console.WriteLine("- Delegates -");
        }
        //Първият метод принтира грешката посредством Logger-а, докато вторият
        ////принтира директно в конзолата.
    }
}
