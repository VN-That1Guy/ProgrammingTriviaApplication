using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTrivia
{
    static class Utility
    {
        /// <summary>
        /// Returns a number greater than 0 and less than numberOfItems
        /// </summary>
        /// <param name="numberOfItems"></param>
        /// <returns></returns>
        public static int GetANumberFromUser(int numberOfItems)
        {
            //Ask the user to enter a number betwee 1 and whatever number of items you want check against
            Console.WriteLine($"Enter a number between 1 and {numberOfItems}");

            //Get the user input from console
            string userInput = Console.ReadLine();

            //Start with negative number to make sure it can't be part of the list
            int userInputAsNumber = -1;
            //Int.Tryparse will try catch converting user input to an integer
            //We need to make sure number is greater than 0
            //And less than the highest number on the list
            if (int.TryParse(userInput, out userInputAsNumber) && userInputAsNumber > 0 && userInputAsNumber <= numberOfItems)
            {
                return userInputAsNumber;
            }
            else
            {
                //If validation fails, re run this utility until user enters a valid value.
                Console.WriteLine("Please pick a Valid Number");
                return GetANumberFromUser(numberOfItems);
            }
        }

        //Makes two seperate copy of the current answer list of the term, one to be shuffled, and the other to be the final result
        public static List<string> Randomize(List<string> strings)
        {
            Random shuffle = new Random();

            List<string> clone = new List<string>(strings);
            List<string> randomize = new List<string>(strings.Count);

            while (clone.Count != 0)
            {
                int numbershuffle = shuffle.Next(0, clone.Count);
                randomize.Add(clone[numbershuffle]);
                clone.RemoveAt(numbershuffle);
            }
            return randomize;
        }
    }
}
