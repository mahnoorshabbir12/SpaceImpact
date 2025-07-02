using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceImpactGame.Classes
{
    public class HorizontalEnemy:Enemy
    {
        public HorizontalEnemy(int x, int y, int health, int collosionDamage, int bulletDamage, string bulletShape, int killReward, char[,] EnemyShape) : base(x, y, health, collosionDamage, bulletDamage, bulletShape, killReward, EnemyShape) { }
    }
}
