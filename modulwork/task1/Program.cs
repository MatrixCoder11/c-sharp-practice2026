
using System;
using System.IO;
using System.Text;

class Program
{


    delegate string TextOperation(string line);

    static string ToUpperCase(string line)
    {
        return line.ToUpper();
    }

    static string CountCharacters(string line)
    {
        return $"Кількість символів: {line.Length}";
    }

    static string CountWords(string line)
    {
        int wordCount = line.Split(new char[] { ' ', '\t' },
                                   StringSplitOptions.RemoveEmptyEntries).Length;
        return $"Кількість слів: {wordCount}";
    }

    static void ProcessFile(string inputPath, string outputPath, TextOperation operation)
    {
        string[] lines = File.ReadAllLines(inputPath);

        using StreamWriter writer = new StreamWriter(outputPath, append: true);

        foreach (string line in lines)
        {
            string result = operation(line);
            writer.WriteLine(result);
        }

        writer.WriteLine(); 
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.InputEncoding = Encoding.UTF8;
        string inputFile  = "textPD25.txt";
        string outputFile = "resultPD25.txt";

        File.WriteAllText(outputFile, string.Empty);


        File.AppendAllText(outputFile, "=== UPPERCASE ===" + Environment.NewLine);
        ProcessFile(inputFile, outputFile, ToUpperCase);


        File.AppendAllText(outputFile, "=== КІЛЬКІСТЬ СИМВОЛІВ ===" + Environment.NewLine);
        ProcessFile(inputFile, outputFile, CountCharacters);

        File.AppendAllText(outputFile, "=== КІЛЬКІСТЬ СЛІВ ===" + Environment.NewLine);
        ProcessFile(inputFile, outputFile, CountWords);

        Console.WriteLine($"Готово! Результат збережено у файл: {outputFile}");
    }
}
