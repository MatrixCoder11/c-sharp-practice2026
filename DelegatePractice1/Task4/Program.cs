using System;
using System.Text;

namespace DelegatePractice
{
    public delegate double MathOperation(double a, double b);

    class Program
    {
        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double Divide(double a, double b)
        {
            return a / b;
        }

        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Func<double, double, double> op;
            List<string> students = new List<string> { 
                "Олексій", "Марія", "Олена", "Іван", "Олег" };
            List<string> filteredStudents = students.FindAll(s => s.StartsWith("О"));

            Console.WriteLine("Студенти на літеру О:");
            foreach (var name in filteredStudents)
            {
                Console.WriteLine(name);
            }

            op = Add;
            Console.WriteLine(op(10, 5));
            op = Subtract;
            Console.WriteLine(op(10, 5));
            op = Multiply;
            Console.WriteLine(op(10, 5));
            op = Divide;
            Console.WriteLine(op(10, 5));
        }
    }
}