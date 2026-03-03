using System;
using System.Text;

namespace DelegatePractice
{

    class Logger
    {
        
        public Action<string> LogHandler;

        public void Log(string message)
        {
            LogHandler?.Invoke(message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Logger myLogger = new Logger();

            Console.WriteLine("--- Звичайний вивід ---");
            myLogger.LogHandler = (msg) => Console.WriteLine($"[LOG]: {msg}");

            myLogger.Log("Програма розпочала роботу.");
            myLogger.Log("Завантаження даних...");

            Console.WriteLine(); 

            Console.WriteLine("--- ВЕРХНІЙ РЕГІСТР ---");
            myLogger.LogHandler = (msg) => Console.WriteLine($"[ATTENTION]: {msg.ToUpper()}");

            myLogger.Log("виявлено помилку");

            Console.WriteLine();

            Console.WriteLine("--- Подвійний вивід (через +=) ---");

            myLogger.LogHandler += (msg) => Console.WriteLine($"Резервна копія тексту: {msg}");

            myLogger.Log("Збереження результатів.");
        }
    }
}