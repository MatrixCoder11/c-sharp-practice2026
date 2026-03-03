using System;

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
            MathOperation op;
            op = Add;
            Console.WriteLine(op(10,5));
            op = Subtract;
            Console.WriteLine(op(10,5));
            op = Multiply;
            Console.WriteLine(op(10,5));
            op = Divide;
            Console.WriteLine(op(10,5));
        }
    }
}