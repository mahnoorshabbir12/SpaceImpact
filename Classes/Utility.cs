using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SpaceImpactGame.Classes
{
    static public class Utility
    {
        static public void PrintLevel()
        {
            Console.SetCursorPosition(3, 1);
            Console.WriteLine("           ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(3, 1);
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Game.CurrentLevel);
        }

        static public void PrintScore()
        {
            Console.SetCursorPosition(30, 1);
            Console.WriteLine("            ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(30, 1);
            Console.Write("Score: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Game.Score);
        }

        static public void PrintHealth(Player player)
        {
            char healthBar = (char)219;

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(43, 1);
            Console.Write("                             ");
            Console.SetCursorPosition(43, 1);
            Console.Write("Health: [");

            //if (playerHarm == 0)                        //Normal Print
            //    SetConsoleTextAttribute(hConsole, 31);
            //else if (playerHarm > 0)                    //Print When Player Harm
            //    SetConsoleTextAttribute(hConsole, 79);
            //else if (playerHarm < 0)                    //Print when player ear Healer
            //    SetConsoleTextAttribute(hConsole, 47);

            Console.BackgroundColor = ConsoleColor.Blue;

            for (int i = 1; i <= player.Health; i += 1)
                Console.Write(" ");



            Console.SetCursorPosition(60, 1);

            if (player.Health < 10)
                Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(player.Health * 100 / 20 + "%");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(72, 1);
            Console.Write("]");
        }
    }
}