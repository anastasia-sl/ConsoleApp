namespace ConsoleApp2
{
    public class Calculator
    {
        private static int ReadNumber(string interfaceString)
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
                    Console.WriteLine(CalcInterfaceItems.WrongInputWarning);
                }
            } while (!isParsedSuccessfully);

            return number;
        }

        public static void Calculate()
        {
            var num1 = ReadNumber(CalcInterfaceItems.GetFirstNumber);

            Console.WriteLine(CalcInterfaceItems.GetOperation);

            var operation = Console.ReadLine();

            var num2 = ReadNumber(CalcInterfaceItems.GetSecondNumber);

            var result = operation switch
            {
                CalcOperationOptions.Addition => (num1 + num2).ToString(),
                CalcOperationOptions.Subtraction => (num1 - num2).ToString(),
                CalcOperationOptions.Multiplication => (num1 * num2).ToString(),
                CalcOperationOptions.Division => (num1 / num2).ToString(),
                _ => CalcInterfaceItems.WrongOperationWarning
            };

            Console.WriteLine(result);
        }
    }
}
