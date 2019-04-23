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

        public Position getPosition(Maze maze)
        {
            return this;
        }
    }
}
