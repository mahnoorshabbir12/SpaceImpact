using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EZInput;
using SpaceImpactGame.Interface;

namespace SpaceImpactGame.Classes
{ 
    public class Player : Character
    {
        static public int BulletDamage = 1;
        static public string BulletSymbol = "⌐";
        static int ShootSpeed = 5;
        private int life = 3;
        private static int playerInitialHealth = 20;

        public static char[,] playerShape = new char[,]
        {
          { '#', '#', ' ', '/', '\\', ' ', ' ' },
           { ' ', '#', '-', '@', '-', '#', '>' },
          { '#', '#', ' ', '\\', '/', ' ', ' ' }
        };

        public Player(int x, int y) : base(x, y, playerInitialHealth)
        {
        }

        public int Life
        {
            get { return life; }
            set { life = value; }
        }
        
        public override void Print()
        {
            ConsoleColor originalColor = Console.ForegroundColor;

            //// Set color based on playerHarm
            //if (playerHarm == 0)
            //    Console.ForegroundColor = ConsoleColor.Green;
            //else
            //    Console.ForegroundColor = ConsoleColor.Red;


            Console.ForegroundColor = ConsoleColor.Green;

            // Draw the player using SetCursorPosition
            Console.SetCursorPosition(X, Y);
            Console.Write("## /\\");

            Console.SetCursorPosition(X, Y + 1);
            Console.Write(" #-@-#>");

            Console.SetCursorPosition(X, Y + 2);
            Console.Write("## \\/");

            // Reset color to default
            Console.ForegroundColor = originalColor;
        }
        public override void Erase()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("     ");

            Console.SetCursorPosition(X, Y + 1);
            Console.Write("       ");

            Console.SetCursorPosition(X, Y + 2);
            Console.Write("     ");
        }

        public override void Move()
        {
            if (Keyboard.IsKeyPressed(Key.UpArrow))
                if (Y > 4)
                {
                    Erase();
                    Y--;
                    Print();
                }

            if (Keyboard.IsKeyPressed(Key.DownArrow))
                if(Y<23)
                {
                    Erase();
                    Y++;
                    Print();
                }
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
                if (X > 2)
                {
                    Erase();
                    X--;
                    Print();
                }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
                if (X < 63)
                {
                    Erase();
                    X++;
                    Print();
                }
        }

        public Bullet Shoot()
        {
            if (Keyboard.IsKeyPressed(Key.Space) && ShootSpeed > 20)
            {
                Bullet bullet = new PlayerBullet();
                bullet.Print();
                bullet.Move();
                return bullet;
                ShootSpeed = 0;
            }
            ShootSpeed++;
            return null;
        }
    }
}
