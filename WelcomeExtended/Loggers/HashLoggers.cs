using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers
{
    public class HashLoggers : ILogger
    {
        private readonly ConcurrentDictionary<int, string> _logMessages;

        private string _name;

        private readonly string _filePath;
        public HashLoggers(string name, string filePath)
        {
            _logMessages = new ConcurrentDictionary<int, string>();
            _name = name;
            _filePath = filePath; // Ensure _filePath is initialized
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }
        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var message = formatter(state, exception);
            switch (logLevel)
            {
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.WriteLine("- LOGGER -");
            var messageToBeLogged = new StringBuilder();
            messageToBeLogged.AppendLine($"[{logLevel}]");
            messageToBeLogged.AppendFormat($"[{_name}]"); // Fixed incorrect format string
            Console.WriteLine(messageToBeLogged);
            Console.WriteLine($"{formatter(state, exception)}");
            Console.WriteLine("- LOGGER -");
            Console.ResetColor();
            _logMessages[eventId.Id] = message;

            // Записваме съобщението в файла
            try
            {
                using (var writer = new StreamWriter(_filePath, true))
                {
                    writer.WriteLine($"[{logLevel}] [{_name}] {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        } //print and save error in color
        public void PrintLog()
        {
            Console.WriteLine("Print All Log Messages:");
            foreach (var log in _logMessages)
            {
                Console.WriteLine($"[{log.Key}] {log.Value}");
            }
        } //print all errors
        public void PrintEventMessages()
        {
            Console.WriteLine("Event Messages:");
            foreach (var log in _logMessages)
            {
                Console.WriteLine($"Event ID: {log.Key}, Message: {log.Value}");
            }
        }
        public bool DeleteEventMessage(int eventId)
        {
            if (_logMessages.ContainsKey(eventId))
            {
                // Премахваме съобщението с даден eventId
                return _logMessages.TryRemove(eventId, out _);
            }
            else
            {
                Console.WriteLine($"Event ID {eventId} не съществува.");
                return false;
            }
        }
    }
}
