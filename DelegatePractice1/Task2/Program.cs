using System;

namespace DelegateTask2
{
    public delegate void NotificationHandler(string msg);

    class Program
    {
        public static void SendEmail(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }

        public static void SendSMS(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }

        static void Main(string[] args)
        {
            NotificationHandler handler;
            handler = SendEmail;
            handler += SendSMS;
            handler("Test");

        }
    }
}