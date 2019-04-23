using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public class Position
    {
        private string _message;

        private Maze.Cell _cell;

        public int X { get; set; }
        public int Y { get; set; }

        public Position()
        {

        }

        public Position(int x, int y, string message)
        {
            this.X = x;
            this.Y = y;
            this._message = message;
        }

        public Position(Maze.Cell cell, string message)
        {
            this._cell = cell;
            this._message = message;
        }

        public Maze.Cell getPosition(Maze maze)
        {
            return maze.getCell(X, Y);
        }

        public Maze.Cell[] getTargets()
        {
            return null;
        }
    }
}
