using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceImpactGame.Classes;

namespace SpaceImpactGame.Interface
{
    public interface IKeyMovements
    {
        void MovePlayerRight(char[,] maze, Player P1);

        void MovePlayerLeft(char[,] maze, Player P1);

        void MovePlayerUp(char[,] maze, Player P1);

        void MovePlayerDown(char[,] maze, Player P1);
        
    }
}
