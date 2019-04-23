using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public class MazeView
    {
        private Maze _maze;
        private Position _position;
        public MazeView(Maze maze, Position position)
        {
            _maze = maze;
            _position = position;
        }

        public void Display()
        {
            for (int y = 0; y < _maze.Height; y++)
            {

                for (int x = 0; x < _maze.Width; x++)
                {
                    switch (_maze.GetPosition(x, y).Type)
                    {
                        case Position.CellType.Empty:
                            Console.Write("*");
                            break;
                        case Position.CellType.Target:
                            Console.Write("T");
                            break;
                        case Position.CellType.Wall:
                            Console.Write("X");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
