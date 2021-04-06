using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ProgrammingTrivia
{
    class MenuSystem
    {
        private int SelectedOption;
        private List<string> Options; //Instead of using stringarrays, the option has been turned into a list to accomodate the use of Lists in this application
        private string Prompt;

        public MenuSystem(string messageprompt, List<string> promptoptions)
        {
            Prompt = messageprompt;
            Options = new List<string>(); //Creates a list
            Options.AddRange(promptoptions); //Adds in items from a specified list into this list
            SelectedOption = 0;
        }

        public void DisplayOptions()
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine(Prompt);
            ResetColor();
            WriteLine("\nUse arrow keys up and down to cycle through options and press enter to select an option.");
            for (int i = 0; i < Options.Count; i++)
            {
                string currentOption = Options[i];
                string prefix;
                string afterfix;
                //Highlights a specific line and adds a set prefix and afterfix to the Option when it is selected.
                if (i == SelectedOption)
                {
                    prefix = ">";
                    afterfix = "<";
                }
                else
                {
                    prefix = " ";
                    afterfix = " ";
                }
                WriteLine($"{prefix} [{currentOption}] {afterfix}");
            }

        }
        //Starts the Menu process when called, uses same string as Display Options because the DisplayOptions is called in this method.
        public int Run()
        {
            ConsoleKey PressedKey;
            do
            {
                CursorVisible = false;
                Clear();
                DisplayOptions();
                ConsoleKeyInfo keyInfo = ReadKey(true);
                PressedKey = keyInfo.Key;
                if (PressedKey == ConsoleKey.UpArrow)
                {
                    SelectedOption--;
                    if (SelectedOption == -1)
                    {
                        SelectedOption = Options.Count - 1;
                    }
                }
                else if (PressedKey == ConsoleKey.DownArrow)
                {
                    SelectedOption++;
                    if (SelectedOption == Options.Count)
                    {
                        SelectedOption = 0;
                    }
                }
            }
            while (PressedKey != ConsoleKey.Enter);

            return SelectedOption;
        }
    }
}
