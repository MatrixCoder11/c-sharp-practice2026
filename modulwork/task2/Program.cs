using System;
using System.IO;
using System.Text;

class MessagePublisher
{

    public event EventHandler<MessageEventArgs> MessageSent;


    public void Send(string message)
    {
        Console.WriteLine($"[Publisher] Відправлено: {message}");
        MessageSent?.Invoke(this, new MessageEventArgs(message));
    }
}


class MessageEventArgs : EventArgs
{
    public string Message { get; }

    public MessageEventArgs(string message)
    {
        Message = message;
    }
}


class FileLogger
{
    private readonly string _logPath;

    public FileLogger(string logPath)
    {
        _logPath = logPath;
    }


    public void Subscribe(MessagePublisher publisher)
    {
        publisher.MessageSent += OnMessageSent;
    }

 
    private void OnMessageSent(object sender, MessageEventArgs e)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string record    = $"[{timestamp}] {e.Message}";

        File.AppendAllText(_logPath, record + Environment.NewLine);
        Console.WriteLine($"[Logger]    Записано у файл: {record}");
    }
}


class Program
{
    static void Main()
    {
        string logFile = "logPD25.txt";
        Console.OutputEncoding = Encoding.UTF8;

        Console.InputEncoding = Encoding.UTF8;


        File.WriteAllText(logFile, string.Empty);

        var publisher = new MessagePublisher();
        var logger    = new FileLogger(logFile);


        logger.Subscribe(publisher);

        Console.WriteLine("Введіть 4 рядки тексту (після кожного натисніть Enter):");
        Console.WriteLine(new string('-', 50));

        for (int i = 1; i <= 4; i++)
        {
            Console.Write($"Рядок {i}: ");
            string input = Console.ReadLine();
            publisher.Send(input);
            Console.WriteLine();
        }

        Console.WriteLine(new string('-', 50));
        Console.WriteLine($"Готово! Лог збережено у файл: {logFile}");
    }
}
