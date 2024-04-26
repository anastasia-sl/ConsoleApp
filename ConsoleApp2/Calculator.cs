using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Calculator
    {
        public static int ReadNumber(string interfaceString)
        {
            int number;
            bool isParsedSuccessfully;

            do
            {
                Console.WriteLine(interfaceString);
                var inputNumber = Console.ReadLine();
                isParsedSuccessfully = int.TryParse(inputNumber, out number);

                if (!isParsedSuccessfully)
                {
                    Console.WriteLine("Invalid input");
                }
            } while (!isParsedSuccessfully);

            return number;
        }

        public static void Calculate()
        {
            var num1 = ReadNumber("Enter first number:");

            Console.WriteLine("Enter operation:");

            var operation = Console.ReadLine();

            var num2 = ReadNumber("Enter second number:");

            var result = operation switch
            {
                "+" => (num1 + num2).ToString(),
                "-" => (num1 - num2).ToString(),
                "*" => (num1 * num2).ToString(),
                "/" => (num1 / num2).ToString(),
                _ => "Invalid operation"
            };

            Console.WriteLine(result);
        }
    }
}
