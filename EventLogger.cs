using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SmartHomeSystem
{
    public class EventLogger
    {
        private readonly List<string> log = new List<string>();

        public void Log(string message)
        {
            string logEntry = $"[{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}] {message}";
            log.Add(logEntry);
        }

        public void ShowLog()
        {
           foreach (var elem in log)
            {
                Console.WriteLine(elem);
            }
        }
    }
}
