using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceImpactGame.Classes
{
    public class EnemyBullet : Bullet
    {
        public EnemyBullet(Enemy enemy) : base(enemy.X, enemy.Y + enemy.EnemyShape.GetLength(0) /2 -1, enemy.BulletDamage, enemy.BulletShape) { }

        public override void Move()
        {
            Erase();
            X--;
            Print();
        }
        public override void Print()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Symbol);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public override void Erase()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }
    }
}
