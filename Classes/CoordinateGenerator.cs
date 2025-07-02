using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceImpactGame.Classes
{
    static public class CoordinateGenerator
    {
        static private Random random = new Random();

        static public int GenerateCoodinateGenos()
        {
            List<int> coordinates = Enumerable.Range(5, 21).ToList();
            foreach (Enemy e in Game.EnemiesList)
            {
                int height = e.EnemyShape.GetLength(0);

                coordinates.Remove(e.Y);
                for (int i = 0; i < height; i++)
                {
                    coordinates.Remove(e.Y + i);
                }
            }

            int index = random.Next(coordinates.Count);
            return coordinates[index];
        }
    }
}
