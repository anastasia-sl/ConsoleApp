namespace ConsoleApp2
{
    public class Menu
    {
        private static void PrintMenu(MenuOptions selectedOption)
        {
            Console.WriteLine(InterfaceItems.MenuStr);

            Console.WriteLine($"{(selectedOption == MenuOptions.Calculator ? $"{InterfaceItems.Arrow} " : $"    ")} {MenuOptions.Calculator}");
            Console.WriteLine($"{(selectedOption == MenuOptions.StringReverse ? $"{InterfaceItems.Arrow} " : $"    ")} {MenuOptions.StringReverse}");
            Console.WriteLine($"{(selectedOption == MenuOptions.Quit ? $"{InterfaceItems.Arrow} " : $"    ")} {MenuOptions.Quit}");
        }

        private static MenuOptions ChangeMenuOption(ConsoleKeyInfo keyInfo, MenuOptions selectedOption)
        {
            var optionsCount = Enum.GetNames(typeof(MenuOptions)).Length;

            return keyInfo.Key switch
            {
                ConsoleKey.DownArrow => (MenuOptions)Math.Min((int)selectedOption + 1, optionsCount),
                ConsoleKey.UpArrow => (MenuOptions)Math.Min((int)selectedOption - 1, optionsCount),
                _ => selectedOption
            };
        }

        private static void ExecuteCalculatorOption()
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

        private static void ExecuteReverseStrOption()
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
                ConsoleKeyInfo keyInfo =  Console.ReadKey();
                selectedOption = ChangeMenuOption(keyInfo, selectedOption);

                Console.Clear();
                PrintMenu(selectedOption);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.Clear();

                    switch(selectedOption)
                    {
                        case MenuOptions.Calculator:
                            ExecuteCalculatorOption();
                            break;
                        case MenuOptions.StringReverse:
                            ExecuteReverseStrOption();
                            break;
                        case MenuOptions.Quit:
                            Environment.Exit(0);
                            break;
                    };
                }
            }
        }
    }
}
