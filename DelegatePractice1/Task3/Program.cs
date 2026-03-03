using System;

namespace DelegateTask3
{
    public delegate bool FilterPredicate(int n);
    class Program
    {
        public static void FilterArray(int[] numbers, FilterPredicate predicate)
        {
            foreach (int n in numbers)
            {
                if (predicate(n))
                {
                    {
                        Console.Write(n + " ");
                    }
                }
            }
            Console.WriteLine();
        }
        public static bool IsEven(int n)
        {
            return n % 2 == 0;
        }
        public static bool IsGreaterThanFive(int n)
        {
            return n > 5;
        }
        static void Main(string[] args)
        {
            int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            FilterArray(numbers, IsEven);
            FilterArray(numbers, IsGreaterThanFive);
        }

    }
}