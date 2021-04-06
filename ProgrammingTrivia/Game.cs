using static System.Console;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace ProgrammingTrivia
{
    public class Game
    {
        private int points = 0;
        public static int CurrentQuestion = 0;
        public string Title = "A Simple and Short Programming Trivia Game \n(By Vinh Nguyen)";
        public string PressAnyKey = "(Press any Key to continue)";
        List<TriviaQuestion> Questions = new List<TriviaQuestion>();
        List<TriviaQuestion> AskedQuestion = new List<TriviaQuestion>();

        //Writes in a similar fashion to Console.WriteLine but with Yellow text
        public static void TheHostWriteLine(string Question)
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine(Question);
            ResetColor();
        }
        //Ditto, with Console.Write instead of WriteLine
        public static void TheHostWrite(string Question)
        {
            ForegroundColor = ConsoleColor.Yellow;
            Write(Question);
            ResetColor();
        }
        //Makes a list of questions, answers, and possible answers when called
        private void Setup()
        {
            Questions.Add(new TriviaQuestion("___ is an Object Oriented language. What should be in the blank?", "C#", new string[] 
            {
                "Python",
                "C++",
                "JavaScript",
                "F-Stop"
            }));
            Questions.Add(new TriviaQuestion("Conditional statements are one example of what to use to control the flow of program execution. True or False?", "True", new string[]
            {
                "False"
            }));
            Questions.Add(new TriviaQuestion("What is a template that you can instantiate an object from?", "Class", new string[]
            {
                "Instance",
                "Object",
                "Perk",
                "Special"
            }));
            Questions.Add(new TriviaQuestion("What are Public and Private properties are an example of?", "Access Modifiers", new string[]
            {
                "Power",
                "Control",
                "Special Pemissions",
                "Security"

            }));
            Questions.Add(new TriviaQuestion("If you want the console to print out text, what is one thing you can write?", "Console.WriteLine();", new string[]
            {
                "Console.ReadLine();",
                "Console.WriteKey();",
                "Hey dummy, can you write this line?",
                "Console.Clear();"
            }));
            Questions.Add(new TriviaQuestion("Your application can fail to compile with no errors in your coding. True or False?", "False", new string[]
            {
                "True"
            }));
            Questions.Add(new TriviaQuestion("What is one way of writing a loop?", "foreach", new string[]
            {
                "void",
                "public",
                "bool",
                "There is no way"
            }));
            Questions.Add(new TriviaQuestion("When you make a new project, what is the first cs file called?", "Program", new string[]
            {
                "Application",
                "Main",
                "Base",
                "Source",
                "Default"
            }));
            Questions.Add(new TriviaQuestion("If you want random numbers what do you do?", "Write in Random string = new Random(); and then add the string a number value with .Next();", new string[]
            {
                "Say your prayers to RNG",
                "Write rng string = new rng(); and use it in a number value",
                "Buy it through a loot box from Microsoft",
                "Add .Next(); to your number property",
                "Add .RandomNumber(); to your number property"
            }));
            Questions.Add(new TriviaQuestion("Readkey();, Read();, and Readline(); are ways that you can get player input in to the console. True or False?", "True", new string[] 
            {
                "False"
            }));
        }
        //Straight Forward, start's the Trivia Questions when called
        void StartQuestion(string Difficulty)
        {
            points = 0;
            CurrentQuestion = 0;
            Random pickquestion = new Random();
            //List for couting how many questions are instantiated in total
            List<TriviaQuestion> totalquestion = new List<TriviaQuestion>();
            totalquestion.AddRange(Questions);
            //Starts asking questions until there are no questions left to ask
            int SelectedDifficulty = 0;
            if (Difficulty == "easy")
            {
                SelectedDifficulty = 6;
            }
            else if(Difficulty == "normal")
            {
                SelectedDifficulty = 3;
            }
            else
            {
                SelectedDifficulty = 0;
            }
            while (Questions.Count > SelectedDifficulty)
            {
                Clear();
                CurrentQuestion++;;
                //Randomly picks a question in the Main list
                int randompick = pickquestion.Next(0, Questions.Count);
                TriviaQuestion question = Questions[randompick];
                //Saves the Question that is asked and also the Player input to a seperate list
                AskedQuestion.Add(Questions[randompick]);
                //Removes the chosen Question in the main list
                Questions.RemoveAt(randompick);
                //Start asking the question and await for the player input and checks if the player is correct
                bool Correct = question.AskQuestion();
                if (Correct)
                    points++;
                WriteLine($"\n{totalquestion.Count - CurrentQuestion - SelectedDifficulty} Left to go! \n Press Any Key to Continue");
                ReadKey(true);
                //Loop until 0!
            }
            Clear();
            //Prints out how many questions you got right out of the total
            TheHostWriteLine("Well then, I see you have correctly answered:");
            WriteLine($"{points} Questions out of {AskedQuestion.Count}");
            //Makes the console comment on your results based on your total score
            if (points <= AskedQuestion.Count / 2)
            {
                TheHostWriteLine($"Well it looks like you've taken a turn of unfortunate events.\nNo regets, {Player.Name}, every one has to start some where.\nYou can only go up from here, yes?");
            }
            else if (points <= AskedQuestion.Count - 2)
            {
                TheHostWriteLine("Well done.\nYou can always come back and aim a little higher? hmm?");
            }
            else if (points == AskedQuestion.Count - 1)
            {
                TheHostWriteLine("Quite Impressive that you've almost made perfect.\nPerhaps you can perfect this the next time?");
            }
            else
            {
                TheHostWriteLine($"Wisely done {Player.Name}!\nYou have gotten a perfect score.");
            }
            
        }
        //Starts the introduction, the whole process, and the flow of the game when called
        public void Start()
        {
            Console.Title = Title;
            WriteLine(Title + $"\n{PressAnyKey}");
            ReadKey();
            Clear();
            TheHostWriteLine("Rise and shine! If I may ask, what is your name?");
            Player.Name = ReadLine();
            TheHostWriteLine($"I see. Welcome, {Player.Name}. I have a couple questions for you.");
            WriteLine(PressAnyKey);
            ReadKey(true);
            string prompt = "How much do you want to be asked?";
            List<string> optionprompts = new List<string>();
            optionprompts.Add("Not much");
            optionprompts.Add("Normal");
            optionprompts.Add("Ask All Questions");
            MenuSystem YesOrNo = new MenuSystem(prompt, optionprompts);
            string difficulty = "easy";
            int GetUserResponse = YesOrNo.Run();
            switch(GetUserResponse)
            {
                case 0:
                    difficulty = "easy";
                    break;
                case 1:
                    difficulty = "normal";
                    break;
                case 2:
                    difficulty = "hard";
                    break;
            }
            StartGame(difficulty);
        }
        //Called when the Trivia Game is over after looking at the results
        private void EndOfApplication()
        {
            WriteLine("Would you like to retry?\n1. Yes\n2. No");
            var userInput = Console.ReadKey();
            Clear();
            //Checking to see if player entered the correct input.
            if (userInput.Key == ConsoleKey.D1 || userInput.Key == ConsoleKey.NumPad1)
            {
                string prompt = "How much do you want to be asked?";
                List<string> optionprompts = new List<string>();
                optionprompts.Add("Not much");
                optionprompts.Add("Normal");
                optionprompts.Add("Ask All Questions");
                MenuSystem YesOrNo = new MenuSystem(prompt, optionprompts);
                string difficulty = "easy";
                int GetUserResponse = YesOrNo.Run();
                switch (GetUserResponse)
                {
                    case 0:
                        difficulty = "easy";
                        break;
                    case 1:
                        difficulty = "normal";
                        break;
                    case 2:
                        difficulty = "hard";
                        break;
                }
                StartGame(difficulty);
            }
            else if (userInput.Key == ConsoleKey.D2 || userInput.Key == ConsoleKey.NumPad2)
            {
                TheHostWriteLine($"Thanks for stopping by {Player.Name}!\nThis is where I get off.");
                PressAnyKey = "(Press Any Key To Exit)";
                WriteLine(PressAnyKey);
                ReadKey();
                Environment.Exit(0);
            }
            else
            {
                WriteLine("Please choose a valid option");
                EndOfApplication();
            }
        }
        //Start's the Trivia game process and other functions
        private void StartGame(string Difficulty)
        {
            Setup();

            Clear();
            TheHostWriteLine("Let's see if you know these answers.");
            WriteLine("(Type in your number and press Enter to answer the question)\n(You will be able to see how many questions you've answered and how many are left)\n(You will see your right, wrong, and correct answers after the trivia)\nPress any Key to begin");
            ReadKey();
            //The Trivia Starts here
            StartQuestion(Difficulty);
            //The Trivia Ends and displays the result
            TheHostWriteLine("Let's see how you did.");
            WriteLine(PressAnyKey);
            ReadKey();
            Clear();
            ForegroundColor = ConsoleColor.Red;
            Write("Red = Wrong");
            ForegroundColor = ConsoleColor.White;
            Write(" :: ");
            ForegroundColor = ConsoleColor.Green;
            Write("Green = Correct\n");
            ResetColor();
            int CurrentQuestion = 0;
            //Calls in the stored question and player input list made from earlier to show what question is asked in each question, the player answered, and the correct answer is in this fancy list.
            foreach (TriviaQuestion question in AskedQuestion)
            {
                CurrentQuestion++;
                WriteLine("-------------");
                TheHostWrite($"Question {CurrentQuestion}: ");
                WriteLine(question.QuestionText);
                TheHostWrite("Your Input: ");
                if (question.Input == question.CorrectAnswer)
                {
                    ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    ForegroundColor = ConsoleColor.Red;
                }
                WriteLine(question.Input);
                ResetColor();
                ForegroundColor = ConsoleColor.White;
                Write("Correct ");
                TheHostWrite("Answer: ");
                ForegroundColor = ConsoleColor.DarkGreen;
                WriteLine(question.CorrectAnswer);
                ResetColor();
                WriteLine("-------------");
            }
            Write(PressAnyKey);
            ReadKey();
            Clear();
            Questions.Clear();
            AskedQuestion.Clear();
            EndOfApplication();
        }
    }
}
