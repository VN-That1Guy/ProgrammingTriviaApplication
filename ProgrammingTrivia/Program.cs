using System;
namespace ProgrammingTrivia
/*
    A Short Trivia Game By: Vinh Nguyen
    Introduction to Programming
    March 9, 2021
    ASCII art taken from https://www.asciiart.eu/books/books
    ASCII Book Diddled by David Issel, Original Unknown
*/
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Console.WriteLine(@"
      ______ ______
    _/      Y      \_
   // ~~ ~~ | ~~ ~  \\
  // ~ ~ ~~ | ~~~ ~~ \\
 //________.|.________\\
`----------`-'----------'
");
            game.Start();
        }
    }
}
