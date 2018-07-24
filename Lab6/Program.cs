using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dice;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Grand Circus Casino!");
            Console.Write("Roll a pair of dice? (y/n): ");
            string userChoice = Console.ReadLine();

            while (userChoice.ToLower() == "y")
            {

                int numberInput = int.Parse(GetValidInput(@"^\d+$", "How many sides should each die have?", "Sorry, that is not a valid number. Please input a valid number!"));

                Console.WriteLine("Numbers:");
                Console.WriteLine($"Dice one: {RandNumber(1, numberInput)}");
                Console.WriteLine($"Dice two: {RandNumber(1, numberInput)}");

                Console.WriteLine("Roll the dice again? (y/n)");
                userChoice = Console.ReadLine();

            }

            Console.ReadKey();

        }

        public static int RandNumber(int Low, int High)
        {
            Random rndNum = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));

            int rnd = rndNum.Next(Low, High+1);

            return rnd;
        }

        public static string GetValidInput(string pattern, string userMessage, string errorMessage)
        {
            Console.WriteLine(userMessage);
            string userInput = Console.ReadLine();


            while (!Regex.IsMatch(userInput, pattern))
            {
                Console.WriteLine(errorMessage);
                userInput = Console.ReadLine();
            }

            return userInput;
        }

    }
}
