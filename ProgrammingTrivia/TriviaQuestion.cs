using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
namespace ProgrammingTrivia
{
    class TriviaQuestion
    {
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
        public string Input { get; set; }
        public List<string> PossibleAnswers { get; set; }

        public TriviaQuestion(string question, string correctanswer, string[] possibleanswers)
        {
            QuestionText = question;
            CorrectAnswer = correctanswer;
            //Makes a new list
            PossibleAnswers = new List<string>();
            //Adds in both the Right answer and Wrong answers into the list
            PossibleAnswers.Add(correctanswer);
            PossibleAnswers.AddRange(possibleanswers);
        }
        public bool AskQuestion ()
        {
            string QuestionPrompt = $"Question #{Game.CurrentQuestion}\n" + QuestionText;
            //Game.TheHostWriteLine(QuestionText + "\n");
            //Shuffles the list of answers given by the question
            List<string> shuffleanswers = Utility.Randomize(PossibleAnswers);
            //Creates a new class for the Menusystem to run on, getting the QuestionPrompt to print out and listing down the answers
            MenuSystem Menu = new MenuSystem(QuestionPrompt, shuffleanswers);
            //Runs the Menusystem and gets the index number for this interger
            int index = Menu.Run();
            CursorVisible = true;

            //foreach (string choice in shuffleanswers)
            //{
            //    WriteLine($"({index + 1}) {shuffleanswers[index]}\n");
            //    index++;
            //}
            //Waits for the player input reusing a utility
            //int playerchosenanswer = Utility.GetANumberFromUser(index);

            //Converts the player input from the menu as an interger into the final answer as a string and then checks if it is correct
            string finalanswer = shuffleanswers[index];
            Input = finalanswer;
            if (finalanswer == CorrectAnswer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
