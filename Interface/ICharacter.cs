using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceImpactGame.Classes;

namespace SpaceImpactGame.Interface
{
    internal interface ICharacter
    {
        void Move();
        void Print();
        void Erase();
        Bullet Shoot();
    }
}
