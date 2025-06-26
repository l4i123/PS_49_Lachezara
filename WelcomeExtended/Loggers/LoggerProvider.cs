using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers
{
    public class LoggerProvider : ILoggerProvider
    {
        private readonly string _filePath; // Добавяме поле за пътя към файла

        public LoggerProvider(string filePath)
        {
            _filePath = filePath; // Инициализираме пътя към файла
        }

        public ILogger CreateLogger(string categoryName)
        {
            // Създаваме логер, подавайки и двата параметъра
            return new HashLoggers(categoryName, _filePath);
        }

        public void Dispose()
        {
            // Dispose на ресурсите, ако е необходимо
        }
    }
}