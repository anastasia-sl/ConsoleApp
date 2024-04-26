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
            Console.WriteLine("MENU:");

            Console.WriteLine(selectedOption == MenuOptions.Calculator ? $"{InterfaceItems.Arrow} {MenuOptions.Calculator}" : $"    {MenuOptions.Calculator}");
            Console.WriteLine(selectedOption == MenuOptions.StringReverse ? $"{InterfaceItems.Arrow} {MenuOptions.StringReverse}" : $"    {MenuOptions.StringReverse}");
            Console.WriteLine(selectedOption == MenuOptions.Quit ? $"{InterfaceItems.Arrow} {MenuOptions.Quit}" : $"    {MenuOptions.Quit}");
        }
        public static ConsoleKeyInfo GetUserInput()
        {
            return Console.ReadKey();
        }

        public static MenuOptions ChangeMenuOption(ConsoleKeyInfo keyInfo, MenuOptions selectedOption)
        {
            return keyInfo.Key switch
            {
                ConsoleKey.DownArrow => (MenuOptions)Math.Min((int)selectedOption + 1, 3),
                ConsoleKey.UpArrow => (MenuOptions)Math.Min((int)selectedOption - 1, 3),
                _ => selectedOption
            };
        }

        public static void ExecuteCalculatorOption()
        {
            string continueCalcOperation;
            do
            {
                Calculator.Calculate();
                Console.WriteLine(InterfaceItems.continueCalc);
                continueCalcOperation = Console.ReadLine();
            } while (continueCalcOperation == InterfaceItems.agreeToContinue);

            if (continueCalcOperation == InterfaceItems.cancelOperation)
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
                Console.WriteLine(InterfaceItems.getReverseString);

                var enteredString = Console.ReadLine();
                var enteredStringConverted = enteredString.Select(char.ToString).ToArray();

                StringReverser.ReverseString(enteredStringConverted);
                Console.WriteLine(InterfaceItems.continueReverse);

                continueRevOperation = Console.ReadLine();
            } while (continueRevOperation == InterfaceItems.agreeToContinue);

            if (continueRevOperation == InterfaceItems.cancelOperation)
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
