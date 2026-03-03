using System;
using System.Text;

namespace DelegatePractice
{
    public delegate bool Validator(string input);

    class Program
    {
        public static Validator GetValidator(int minLength)
        {
            return (input) => input.Length >= minLength;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Validator passwordValidator = GetValidator(8); 
            Validator loginValidator = GetValidator(3);    

            Console.WriteLine("Введіть логін (мін. 3 символи):");
            string login = Console.ReadLine();
            if (loginValidator(login))
            {
                Console.WriteLine("Логін прийнято.");
            }
            else
            {
                Console.WriteLine("Логін занадто короткий!");
            }

            Console.WriteLine("\nВведіть пароль (мін. 8 символів):");
            string password = Console.ReadLine();
            if (passwordValidator(password))
            {
                Console.WriteLine("Пароль прийнято.");
            }
            else
            {
                Console.WriteLine("Пароль має бути не менше 8 символів!");
            }
        }
    }
}