using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SpaceImpactGame.UI;

namespace SpaceImpactGame.Classes
{
    static public class CollosionDetection
    {
        static public bool DetectCollosion(Bug bug)
        {
            for (int i = 0; i < 6; i++) // checks player width
                for (int j = 0; j < 3; j++) // checks player height
                    if (bug.X == Game.Player.X + i + 1 && bug.Y == Game.Player.Y + j)   // all condition for collision excluding space.
                        return true;
            return false;
        }
        static public bool DetectCollosion(Enemy enemy)
        {
            int enemyHeight = enemy.EnemyShape.GetLength(0);
            for (int i = 0; i < 6; i++) // checks player width
                for (int j = 0 - enemyHeight + 1; j < 3; j++) // checks player height
                    if (enemy.X == Game.Player.X + i + 1 && enemy.Y == Game.Player.Y + j)   // all condition for collision excluding space.
                        return true;
            return false;
        }

        static public bool DetectCollosion(Bullet bullet)
        {
            for (int i = 0; i < 6; i++) // checks player width
                for (int j = 0; j < 3; j++) // checks player height
                    if (bullet.X == Game.Player.X + i + 1 && bullet.Y == Game.Player.Y + j)   // all condition for collision excluding space.
                        return true;
            return false;
        }

        static public bool BulletHitBug()
        {
            for (int i = 0; i < Game.BulletsList.Count; i++)
            {
                Bullet bullet = Game.BulletsList[i];
                for (int j = 0; j < Game.BugsList.Count; j++)
                {
                    Bug bug = Game.BugsList[j];
                    if ((bullet.X == bug.X || bullet.X == bug.X + 1 || bullet.X == bug.X + 2) && bullet.Y == bug.Y)
                    {
                        bullet.Erase();
                        Game.BulletsList.RemoveAt(i);
                        bug.Erase();
                        Game.Score += Bug.KillReward;
                        Utility.PrintScore();
                        Game.BugsList.RemoveAt(j);

                        return true;
                    }
                }
            }
            return false;
        }

        static public bool BulletHitEnemy()
        {
            for (int i = 0; i < Game.BulletsList.Count; i++)
            {
                Bullet bullet = Game.BulletsList[i];
                for (int j = 0; j < Game.EnemiesList.Count; j++)
                {
                    Enemy enemy = Game.EnemiesList[j];
                    if ((bullet.X == enemy.X || bullet.X == enemy.X + 1 || bullet.X == enemy.X + 2) && (bullet.Y == enemy.Y || bullet.Y -1 == enemy.Y))
                    {
                        bullet.Erase();
                        Game.BulletsList.RemoveAt(i);
                        enemy.Health -= bullet.Damage;
                        if (enemy.Health <= 0)
                        {
                            enemy.Erase();
                            Game.Score += Bug.KillReward;
                            Utility.PrintScore();
                            Game.EnemiesList.RemoveAt(j);

                        }
                        return true;
                    }
                }
            }
            return false;
        }

        static public bool BulletHitBullet()
        {
            for (int i = 0; i < Game.BulletsList.Count; i++)
            {
                Bullet bullet = Game.BulletsList[i];

                for (int j = i + 1; j < Game.BulletsList.Count; j++) // Start from i + 1 to avoid duplicates
                {
                    Bullet bullet2 = Game.BulletsList[j];

                    if ((bullet.X == bullet2.X || bullet.X == bullet2.X + 1 || bullet.X == bullet2.X + 2) &&
                        bullet.Y == bullet2.Y)
                    {
                        bullet.Erase();
                        bullet2.Erase();

                        // Always remove the item with the higher index first to avoid shifting the lower one
                        if (i > j)
                        {
                            Game.BulletsList.RemoveAt(i);
                            Game.BulletsList.RemoveAt(j);
                        }
                        else
                        {
                            Game.BulletsList.RemoveAt(j);
                            Game.BulletsList.RemoveAt(i);
                        }

                        return true;
                    }
                }
            }
            return false;
        }
    }
}
