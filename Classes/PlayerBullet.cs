using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceImpactGame.Classes
{
    internal class PlayerBullet : Bullet
    {
        public PlayerBullet() : base(Game.Player.X + 7, Game.Player.Y + 1, Player.BulletDamage, Player.BulletSymbol) { }

        public override void Move()
        {
            Erase();
                X++;
            Print();
        }
        public override void Print()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }
        public override void Erase()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }
    }
}
