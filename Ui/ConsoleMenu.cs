using MyMonkeyApp.Helpers;
using MyMonkeyApp.Models;

namespace MyMonkeyApp.Ui;

public class ConsoleMenu
{

    /// <summary>
    /// Console Menu logic (UI)
    /// </summary>
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Pick an option:");
            Console.WriteLine("1. Get all monkeys.");
            Console.WriteLine("2. Find monkey by name.");
            Console.WriteLine("3. Get a random monkey.");
            Console.WriteLine("0. Exit.");
            Console.Write("> ");
            string? userInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Please enter a valid input from the options.");
                continue;
            }
            userInput = userInput.Trim();
            if (!int.TryParse(userInput, out var userOption))
            {
                Console.WriteLine("Please enter a valid input from the options.");
                continue;
            }

            switch (userOption)
            {
                case 1:
                    var monkeys = MonkeyHelper.GetMonkeys();
                    foreach (var m in monkeys)
                    {
                        PrintMonkey(m);
                        Console.WriteLine("-----");
                    }

                    break;
                case 2:
                    Console.WriteLine("Enter a name: ");
                    string? input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Please enter a valid name.");
                        break;
                    }
                    input = input.Trim();
                    var monkey = MonkeyHelper.GetMonkeyByName(input);
                    if (monkey is null)
                    {
                        Console.WriteLine("Monkey not found.");
                        break;
                    }
                    PrintMonkey(monkey);
                    break;
                case 3:
                    var randomMonkey = MonkeyHelper.GetRandomMonkey();
                    if (randomMonkey is null)
                    {
                        Console.WriteLine("Monkey not found.");
                        break;
                    }
                    PrintMonkey(randomMonkey);
                    break;
                case 0:
                    Console.WriteLine("Exit...");
                    return;
                default:
                    Console.WriteLine("Please enter a valid input from the options.");
                    break;
            }
        }
        

    }

    /// <summary>
    /// Print operations
    /// </summary>
    /// <param name="monkey">Monkey variable</param>
    private void PrintMonkey(Monkey monkey)
    {
        Console.WriteLine("Name: " + monkey.Name);
        Console.WriteLine("Location: " + monkey.Location);
        Console.WriteLine("Details: " + monkey.Details);
        Console.WriteLine(monkey.AsciiArt);
    }
}