using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceImpactGame.Classes.Enemies
{
    public class Megatronix : HorizontalEnemy
    {
        static readonly int Health = 10;
        static readonly int CollosionDamage = 5;
        static readonly int BulletDamage = 2;
        static readonly string BulletShape = "-=";
        static readonly int KillReward = 10;

        static readonly int Speed = 5;

        static readonly int ShootSpeed = 50;
        static char[,] EnemyShape = new char[,]
        {
            { ' ', ' ', '-', '-', '#' },
            { '<', '-', '|', 'o', '|' },
            { ' ', ' ', '-', '-', '#' }
        };


        public Megatronix(int x, int y) : base(x, y, Health, CollosionDamage, BulletDamage, BulletShape, KillReward, EnemyShape)
        {
        }

        public override void Print()
        {
            int rows = EnemyShape.GetLength(0);
            int cols = EnemyShape.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                Console.SetCursorPosition(X, Y + i);
                Console.ForegroundColor = ConsoleColor.Blue;

                for (int j = 0; j < cols; j++)
                {
                    Console.Write(EnemyShape[i, j]);
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public override void Erase()
        {
            int rows = EnemyShape.GetLength(0);
            int cols = EnemyShape.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                Console.SetCursorPosition(X, Y + i);

                for (int j = 0; j < cols; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(); // Move to the next line after each row
            }
        }

        public override void Move()
        {
            if (Tick.TickCount % Speed == 0)
            {
                Erase();
                X--;
                Print();
            }
        }

        public override Bullet Shoot()
        {
            if (Tick.TickCount % ShootSpeed == 0)
            {
                Bullet bullet = new EnemyBullet(this);
                bullet.Print();
                bullet.Move();
                return bullet;
            }
            return null;
        }
    }
}
