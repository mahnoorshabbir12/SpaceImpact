using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceImpactGame.Interface;

namespace SpaceImpactGame.Classes
{
    public abstract class Bullet : GameEntity, IMove
    {
        private int _damage;
        private string _symbol;

        public int Damage { get => _damage; set => _damage = value; }
        public string Symbol { get => _symbol; set => _symbol = value; }

        public Bullet(int x, int y, int Damage, string Symbol) : base(x, y)
        {
            _damage = Damage;
            _symbol = Symbol;
        }

        public abstract void Move();
        public abstract void Print();
        public abstract void Erase();
    }
}
