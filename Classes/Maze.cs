using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceImpactGame.Classes
{
    public class Maze
    {
        public string topBottomBorder = new string('#', 72);
        public string middleLine = "||" + new string(' ', 68) + "||";

        protected int Height;
        protected int Width;
        protected char[,] maze;

        public Maze(int width, int height)
        {
            maze = new char[width, height];
        }
    }
}
