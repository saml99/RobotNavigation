using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    class Position
    {
        private int _x;
        private int _y;

        private string _message;

        private Maze.Cell _cell;

        public Position(int x, int y, string message)
        {
            this._x = x;
            this._y = y;
            this._message = message;
        }

        public Position(Maze.Cell cell, string message)
        {
            this._cell = cell;
            this._message = message;
        }

        public int getX()
        {
            return _x;
        }

        public int getY()
        {
            return _y;
        }

        public Maze.Cell getPosition(Maze maze)
        {
            return maze.getCell(_x, _y);
        }

        public Maze.Cell[] getTargets()
        {
            return null;
        }
    }
}
