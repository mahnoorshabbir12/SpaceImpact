using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceImpactGame.Classes
{
    public class Bug : Character
    {
        private static int playerInitialHealth = 1;
        static readonly int Health = 1;
        static public int CollosionDamage = 1;
        public static readonly int KillReward = 2;
        static readonly string EnemyShape = "(@@";
        static readonly int Speed = 1;
        public Bug(int x, int y) : base(x, y, Health)
        {
        }

        public override void Print()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(X, Y);
            Console.Write(EnemyShape);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override void Erase()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("   ");
        }

        public override void Move()
        {
            if(Tick.TickCount % Speed == 0)
            {
                Erase();
                X--;
                Print();
            }
        }
    }
}