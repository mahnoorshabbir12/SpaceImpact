using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceImpactGame.Classes.Enemies
{
    internal class Voltronix : VerticalEnemy
    {
        static readonly int Health = 50;
        static readonly int CollosionDamage = 3;
        static readonly int BulletDamage = 3;
        static readonly string BulletShape = "<=-";
        static readonly int KillReward = 100;
        static char[,] EnemyShape = new char[,]
        {
            { ' ', ' ', '~', '-', '#' },
            { '_', '-', 'o', '@', '|' },
            { ' ', '-', 'o', '@', '|' },
            { ' ', ' ', '~', '-', '#' }
        };

        public Voltronix(int x, int y) : base(x, y, Health, CollosionDamage, BulletDamage, BulletShape, KillReward, EnemyShape)
        {
        }
    }
}
