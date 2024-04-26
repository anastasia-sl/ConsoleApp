using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Menu
    {
        public static void PrintMenu(MenuOptions selectedOption)
        {
            Console.WriteLine(InterfaceItems.MenuStr);

            var selectedCalculatorOption = $"{InterfaceItems.Arrow} {MenuOptions.Calculator}";
            var selectedStrReverseOption = $"{InterfaceItems.Arrow} {MenuOptions.Calculator}";
            var selectedQuitOption = $"{InterfaceItems.Arrow} {MenuOptions.Calculator}";

            Console.WriteLine(selectedOption == MenuOptions.Calculator ? selectedCalculatorOption : $"    {MenuOptions.Calculator}");
            Console.WriteLine(selectedOption == MenuOptions.StringReverse ? selectedStrReverseOption : $"    {MenuOptions.StringReverse}");
            Console.WriteLine(selectedOption == MenuOptions.Quit ? selectedQuitOption : $"    {MenuOptions.Quit}");
        }

        public static ConsoleKeyInfo GetUserInput()
        {
            return Console.ReadKey();
        }

        public static MenuOptions ChangeMenuOption(ConsoleKeyInfo keyInfo, MenuOptions selectedOption)
        {
            var optionsCount = Enum.GetNames(typeof(MenuOptions)).Length;

            return keyInfo.Key switch
            {
                ConsoleKey.DownArrow => (MenuOptions)Math.Min((int)selectedOption + 1, optionsCount),
                ConsoleKey.UpArrow => (MenuOptions)Math.Min((int)selectedOption - 1, optionsCount),
                _ => selectedOption
            };
        }
        public static void ContinueOperation(string operationResult)
        {
            if (operationResult == InterfaceItems.CancelOperation)
            {
                Console.Clear();
                OpenMenu();
            }
        }

        public static void ExecuteCalculatorOption()
        {
            string continueCalcOperation;
            do
            {
                Calculator.Calculate();
                Console.WriteLine(InterfaceItems.ContinueCalc);
                continueCalcOperation = Console.ReadLine();
            } while (continueCalcOperation == InterfaceItems.AgreeToContinue);

            if (continueCalcOperation == InterfaceItems.CancelOperation)
            {
                Console.Clear();
                OpenMenu();
            }
        }

        public static void ExecuteReverseStrOption()
        {
            string continueRevOperation;

            do
            {
                Console.Clear();
                Console.WriteLine(InterfaceItems.GetReverseString);

                var enteredString = Console.ReadLine();
                var enteredStringConverted = enteredString.Select(char.ToString).ToArray();

                StringReverser.ReverseString(enteredStringConverted);
                Console.WriteLine(InterfaceItems.ContinueReverse);

                continueRevOperation = Console.ReadLine();
            } while (continueRevOperation == InterfaceItems.AgreeToContinue);

            if (continueRevOperation == InterfaceItems.CancelOperation)
            {
                Console.Clear();
                OpenMenu();
            }
        }

        public static void OpenMenu()
        {
            MenuOptions selectedOption = MenuOptions.Calculator;
            PrintMenu(selectedOption);

            while (true)
            {
                ConsoleKeyInfo keyInfo = GetUserInput();
                selectedOption = ChangeMenuOption(keyInfo, selectedOption);

                Console.Clear();
                PrintMenu(selectedOption);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.Clear();

                    if (selectedOption == MenuOptions.Calculator)
                    {
                        ExecuteCalculatorOption();
                    }
                    else if (selectedOption == MenuOptions.StringReverse)
                    {
                        ExecuteReverseStrOption();
                    }
                    else if (selectedOption == MenuOptions.Quit)
                    {
                        return;
                    }
                }
            }
        }
    }
}
