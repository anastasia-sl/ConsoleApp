using ConsoleApp2;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Diagnostics;

MenuOpen();

static int ReadNumber(string interfaceString)
{
    int number;
    bool isParsedSuccessfully;

    do
    {
        Console.WriteLine(interfaceString);
        string inputNumber = Console.ReadLine();
        isParsedSuccessfully = int.TryParse(inputNumber, out number);

        if (!isParsedSuccessfully)
        {
            Console.WriteLine("Invalid input");
        }
    } while (!isParsedSuccessfully);

    return number;
}

static void Calculator()
{
    var num1 = ReadNumber("Enter first number:");

    Console.WriteLine("Enter operation:");

    var operation = Console.ReadLine();

    var num2 = ReadNumber("Enter second number:");

    switch (operation)
    {
        case "+":
            var result = num1 + num2;
            Console.WriteLine(result);
            break;
        case "-":
            result = num1 - num2;
            Console.WriteLine(result);
            break;
        case "*":
            result = num1 * num2;
            Console.WriteLine(result);
            break;
        case "/":
            result = num1 / num2;
            Console.WriteLine(result);
            break;
        default:
            Console.WriteLine("Select operation");
            break;
    }
}


static void ReverseString(string[] arr)
{
    for (int i = arr.Length - 1; i >= 0; i--)
    {
        Console.WriteLine(arr[i]);
    }
}

static void PrintMenu(MenuOptions selectedOption)
{
    Console.WriteLine("MENU:");

    Console.WriteLine(selectedOption == MenuOptions.Calculator ? $"{InterfaceItems.Arrow} {MenuOptions.Calculator}" : $"    {MenuOptions.Calculator}");
    Console.WriteLine(selectedOption == MenuOptions.StringReverse ? $"{InterfaceItems.Arrow} {MenuOptions.StringReverse}" : $"    {MenuOptions.StringReverse}");
    Console.WriteLine(selectedOption == MenuOptions.Quit ? $"{InterfaceItems.Arrow} {MenuOptions.Quit}" : $"    {MenuOptions.Quit}");
}

static void MenuOpen()
{
    MenuOptions selectedOption = MenuOptions.Calculator;
    PrintMenu(selectedOption);

    while (true)
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey();

        if (keyInfo.Key == ConsoleKey.DownArrow)
        {
            selectedOption = (MenuOptions)Math.Min((int)selectedOption + 1, 3);
            Console.Clear();
            PrintMenu(selectedOption);
        }
        else if (keyInfo.Key == ConsoleKey.UpArrow)
        {
            selectedOption = (MenuOptions)Math.Min((int)selectedOption - 1, 3);
            Console.Clear();
            PrintMenu(selectedOption);
        }

        if (selectedOption == MenuOptions.Calculator && keyInfo.Key == ConsoleKey.Enter)
        {
            string continueCalcOperation;

            do
            {
                Console.Clear();
                Calculator();
                Console.WriteLine("Do you want to do a new operation? y/n");
                continueCalcOperation = Console.ReadLine();
            } while (continueCalcOperation == "y");

            if (continueCalcOperation == "n")
            {
                Console.Clear();
                MenuOpen();
            }
        }
        else if (selectedOption == MenuOptions.StringReverse && keyInfo.Key == ConsoleKey.Enter)
        {
            string continueRevOperation;

            do
            {
                Console.Clear();
                Console.WriteLine("What string you want to reverse?");

                var enteredString = Console.ReadLine();
                var enteredStringConverted = enteredString.Select(char.ToString).ToArray();

                ReverseString(enteredStringConverted);
                Console.WriteLine("Do you want to try again? y/n");

                continueRevOperation = Console.ReadLine();
            } while (continueRevOperation == "y");

            if (continueRevOperation == "n")
            {
                Console.Clear();
                MenuOpen();
            }
        }
        else if (selectedOption == MenuOptions.Quit && keyInfo.Key == ConsoleKey.Enter)
        {
            return;
        }
    }
}
enum MenuOptions
{
    Calculator = 1,
    StringReverse,
    Quit
}