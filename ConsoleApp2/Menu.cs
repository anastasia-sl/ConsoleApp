using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Menu
    {
        public static void PrintMenu(MenuOptions selectedOption)
        {
            Console.WriteLine("MENU:");

            Console.WriteLine(selectedOption == MenuOptions.Calculator ? $"{InterfaceItems.Arrow} {MenuOptions.Calculator}" : $"    {MenuOptions.Calculator}");
            Console.WriteLine(selectedOption == MenuOptions.StringReverse ? $"{InterfaceItems.Arrow} {MenuOptions.StringReverse}" : $"    {MenuOptions.StringReverse}");
            Console.WriteLine(selectedOption == MenuOptions.Quit ? $"{InterfaceItems.Arrow} {MenuOptions.Quit}" : $"    {MenuOptions.Quit}");
        }
        private static ConsoleKeyInfo GetUserInput()
        {
            return Console.ReadKey();
        }

        private static MenuOptions ChangeMenuOption(ConsoleKeyInfo keyInfo, MenuOptions selectedOption)
        {
            if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                return (MenuOptions)Math.Min((int)selectedOption + 1, 3);
            }
            else if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                return (MenuOptions)Math.Min((int)selectedOption - 1, 3);
            }
            else
            {
                return selectedOption;
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
                        string continueCalcOperation;
                        do
                        {
                            Calculator.Calculate();
                            Console.WriteLine("Do you want to do a new operation? y/n");
                            continueCalcOperation = Console.ReadLine();
                        } while (continueCalcOperation == "y");

                        if (continueCalcOperation == "n")
                        {
                            Console.Clear();
                            OpenMenu();
                        }
                    }
                    else if (selectedOption == MenuOptions.StringReverse)
                    {
                        string continueRevOperation;

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("What string you want to reverse?");

                            var enteredString = Console.ReadLine();
                            var enteredStringConverted = enteredString.Select(char.ToString).ToArray();

                            StringReverser.ReverseString(enteredStringConverted);
                            Console.WriteLine("Do you want to try again? y/n");

                            continueRevOperation = Console.ReadLine();
                        } while (continueRevOperation == "y");

                        if (continueRevOperation == "n")
                        {
                            Console.Clear();
                            OpenMenu();
                        }
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
