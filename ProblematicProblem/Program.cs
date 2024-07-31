using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem;

public class Program
{
    public static Random rng = new();
    public static bool cont = true;

    public static List<string> activities = new List<string>()
    {
        "Movies",
        "Paintball",
        "Bowling",
        "Lazer Tag",
        "LAN Party",
        "Hiking",
        "Axe Throwing",
        "Wine Tasting"
    };

     static void Main(string[] args)
    {
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            var userInput = Console.ReadLine().ToLower();

            while (userInput != "yes" && userInput != "no")
            {
                Console.WriteLine("Invalid input, Please type yes/no");
                userInput = Console.ReadLine().ToLower();
            }

            if (userInput == "no") Console.WriteLine("Good bye!, Program closing");

            {
                Console.WriteLine();
                Console.Write("We are going to need your information first! What is your name? ");
                var userName = Console.ReadLine();

                Console.WriteLine();
                Console.Write("What is your age? ");
                int userAge;
                while (!int.TryParse(Console.ReadLine(), out userAge))
                {
                    Console.Write("That is not a valid age, Please try again!: ");
                }
                
                Console.WriteLine();
                Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
                userInput = Console.ReadLine().ToLower();

                while (userInput != "sure" && userInput != "no thanks")
                {
                    Console.WriteLine("That option is not valid. Please use Sure/No thanks:");
                    userInput = Console.ReadLine().ToLower();
                } 
                
                if (userInput == "sure")
                {
                    foreach (var activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }

                    Console.WriteLine();
                    Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                    userInput = Console.ReadLine().ToLower();

                    while (userInput != "yes" && userInput != "no")
                    {
                        Console.WriteLine("Not valid option. Please use yes/no");
                        userInput = Console.ReadLine().ToLower();
                    }

                    Console.WriteLine();

                    while (userInput == "yes")
                    {
                        Console.Write("What would you like to add? ");
                        var userAddition = Console.ReadLine();
                        activities.Add(userAddition);

                        foreach (var activity in activities)
                        {
                            Console.Write($"{activity} ");
                            Thread.Sleep(250);
                        }

                        Console.WriteLine();
                        Console.WriteLine("Would you like to add more? yes/no: ");
                        userInput = Console.ReadLine().ToLower();

                        while (userInput != "yes" && userInput != "no")
                        {
                            Console.WriteLine("Not valid option. Please use yes/no");
                            userInput = Console.ReadLine().ToLower();
                        }
                    }

                    while (cont)
                    {
                        Console.Write("Connecting to the database");
                        for (var i = 0; i < 10; i++)
                        {
                            Console.Write(". ");
                            Thread.Sleep(500);
                        }

                        Console.WriteLine();

                        Console.Write("Choosing your random activity");
                        for (var i = 0; i < 9; i++)
                        {
                            Console.Write(". ");
                            Thread.Sleep(500);
                        }

                        Console.WriteLine();
                        var randomNumber = rng.Next(activities.Count);
                        var randomActivity = activities[randomNumber];
                        if (userAge < 21 && randomActivity == "Wine Tasting")
                        {
                            Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                            Console.WriteLine("Pick something else!");
                            activities.Remove(randomActivity);
                            randomNumber = rng.Next(activities.Count);
                            randomActivity = activities[randomNumber];
                        }

                        Console.Write(
                            $"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                        Console.WriteLine();
                        userInput = Console.ReadLine().ToLower();

                        while (userInput != "keep" && userInput != "redo")
                        {
                            Console.WriteLine("That was not a valid option. Please type keep/Redo");
                            userInput = Console.ReadLine().ToLower();
                        }

                        if (userInput == "keep") cont = false;
                    }
                }
            }
        }
    }
}