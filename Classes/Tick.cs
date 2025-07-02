using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceImpactGame.Classes
{
    static public class Tick
    {
        static private int tickCount = 0;

        static public int TickCount
        {
            get { return tickCount; }
            set
            {
                if (value > 0)
                    tickCount = value;
            }
        }

    }
}
