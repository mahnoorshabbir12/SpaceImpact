using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceImpactGame.Classes
{
    public class Enemy : Character
    {
        public int CollosionDamage;
        public readonly int BulletDamage;
        public readonly string BulletShape;
        public readonly int KillReward;
        public char[,] EnemyShape = new char[,]
        {
        };
        public Enemy(int x, int y, int health, int collosionDamage, int bulletDamage, string bulletShape, int killReward, char[,] enemyShape) : base(x, y, health) 
        {
            CollosionDamage = collosionDamage;
            BulletDamage = bulletDamage;
            BulletShape = bulletShape;
            KillReward = killReward;
            EnemyShape = enemyShape;
        }


        public virtual void TakeDamage(int amount)
        {
            Health -= amount;
        }

        public override void Move()
        { }

        public override void Print()
        { }

        public override void Erase()
        { }

        public virtual Bullet Shoot() { return null; }
    }
}
