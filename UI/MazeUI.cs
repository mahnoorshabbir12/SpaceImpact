using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceImpactGame.Classes;

namespace SpaceImpactGame.UI
{
    public class MazeUI
    {
        private Maze mazeInstance;

        public MazeUI(Maze maze)
        {
            mazeInstance = maze;
        }

        public void PrintMaze()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n");
            Console.WriteLine(mazeInstance.topBottomBorder);
            for (int i = 0; i < 22; i++)
            {
                Console.WriteLine(mazeInstance.middleLine);
            }
            Console.WriteLine(mazeInstance.topBottomBorder);
        }
    }
}
