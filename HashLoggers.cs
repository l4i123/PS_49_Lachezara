using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
// Ensure the Microsoft.Extensions.Logging NuGet package is installed
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers
{
    internal class HashLoggers
    {
        private readonly ConcurrentDictionary<int, string> _logMessages;

        private string _name;
        public HashLoggers(string name)
        {
            _logMessages = new ConcurrentDictionary<int, string>();
            _name = name;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }
        public void Log<TState>(LogLevel logLevel,EventId eventId, TState state,Exception exeption, Func<TState, Exception, string> formatter)
        {
            var message = formatter(state, exeption);
            switch (logLevel) 
            {
                case logLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case logLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case logLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.WriteLine("- LOGGER -");
            var messageToBeLogged = new SrtringBuilder();
            messageToBeLogged.AppendLine($"[{logLevel}]");
            messageToBeLogged.AppendFormat($"[{0}]",_name);
            Console.WriteLine(messageToBeLogged);
            Console.WriteLine($"{formatter(state, exeption)}");
            Console.WriteLine("- LOGGER -");
            Console.ResetColor();
            _logMessages[eventId.Id] = message;
        }//print and save error in color
    }
}
