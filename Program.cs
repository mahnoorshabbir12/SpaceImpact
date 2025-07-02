using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EZInput;
using SpaceImpactGame.Classes;
using SpaceImpactGame.UI;
using SpaceImpactGame.Classes.Enemies;

namespace SpaceImpactGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Random random = new Random();

            MazeUI MazeUIInstance = new MazeUI(new Maze(1, 2));
            MazeUIInstance.PrintMaze();
            Utility.PrintLevel();
            Utility.PrintScore();

            Game.Player = new Player(5, 5);
            Game.Player.Print();

            Utility.PrintHealth((Player)Game.Player);

            int BugGenerationTime = 11;
            int GenosGenerationTime = 51;
            int FiringTime = 6;


            while (true)
            {
                Thread.Sleep(100);
                Tick.TickCount++;
                if (Tick.TickCount > 99)
                    Tick.TickCount = 0;

                Game.Player.Move();

                if(Keyboard.IsKeyPressed(Key.Space) && FiringTime >5)
                {
                    Game.BulletsList.Add(new PlayerBullet());
                    FiringTime = 0;
                }


                foreach(Enemy e in Game.EnemiesList)
                {
                    Bullet b = e.Shoot();
                    if(b != null)
                    {
                        Game.BulletsList.Add(b);
                    }
                }

                CollosionDetection.BulletHitBug();
                CollosionDetection.BulletHitEnemy();

                for (int i = Game.BulletsList.Count - 1; i >= 0; i--)
                {
                    Bullet bullet = Game.BulletsList[i];
                    bullet.Move();

                    bullet.Move();

                    CollosionDetection.BulletHitBug();
                    CollosionDetection.BulletHitEnemy();
                    if (CollosionDetection.DetectCollosion(bullet))
                        {
                            bullet.Erase();
                            Game.Player.Print();
                            Game.BulletsList.RemoveAt(i);
                            Game.Player.Health -= bullet.Damage;
                            Utility.PrintHealth(Game.Player);
                        }
                }   //Move and collosion Bullets
                for (int i = Game.BulletsList.Count - 1; i >= 0; i--)
                {
                    Bullet bullet = Game.BulletsList[i];
                    if(bullet.X >66 || bullet.X < 4)
                    {
                        bullet.Erase();
                        Game.BulletsList.RemoveAt(i);
                    }
                }   //Delete Bullets


                if (BugGenerationTime > 10)
                { 
                    Game.BugsList.Add(new Bug(65, CoordinateGenerator.GenerateCoodinateGenos()));
                    BugGenerationTime = 0;
                }
                for (int i = Game.BugsList.Count - 1; i >= 0; i--)
                {
                    Bug bug = Game.BugsList[i];
                    bug.Move();
                    if (CollosionDetection.DetectCollosion(bug))
                    {
                        bug.Erase();
                        Game.Player.Print();
                        Game.BugsList.RemoveAt(i);
                        Game.Player.Health -= Bug.CollosionDamage;
                        Utility.PrintHealth(Game.Player);
                    }

                }       //Move and Collosion Bugs
                for (int i = Game.BugsList.Count - 1; i >= 0; i--)
                {
                    Bug bug = Game.BugsList[i];
                    if (bug.X < 4)
                    {
                        bug.Erase();
                        Game.BugsList.RemoveAt(i);
                    }
                }       //Delete Bugs

                if(GenosGenerationTime >= 51)
                {
                    Game.EnemiesList.Add(new Genos(62, random.Next(5, 25)));
                    GenosGenerationTime =0;
                }
                for(int i = Game.EnemiesList.Count - 1; i>=0; i--)
                {
                    Enemy enemy = Game.EnemiesList[i];
                    enemy.Move();
                    if(CollosionDetection.DetectCollosion(enemy))
                    {
                        enemy.Erase();
                        Game.Player.Print();
                        Game.EnemiesList.RemoveAt(i);
                        Game.Player.Health -= enemy.CollosionDamage;
                        Utility.PrintHealth(Game.Player);
                    }
                }       //Generation and Collosion
                for(int i = Game.EnemiesList.Count -1; i>=0; i--)
                {
                    Enemy enemy = Game.EnemiesList[i];
                    if(enemy.X < 4)
                    {
                        enemy.Erase();
                        Game.EnemiesList.RemoveAt(i);
                    }
                }       //Delete Enemies


                FiringTime++;
                GenosGenerationTime++;
                BugGenerationTime++;
            }
        }
    }
}
