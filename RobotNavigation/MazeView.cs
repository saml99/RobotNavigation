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
        public MazeView(Maze maze)
        {
            _maze = maze;
        }

        public void Display()
        {
            for (int y = 0; y < _maze.Height; y++)
            {
         
                for (int x = 0; x < _maze.Width; x++)
                {
                    switch (_maze.getCell(x,y))
                    {
                        case Maze.Cell.Empty:
                            Console.Write(" ");
                            break;
                        case Maze.Cell.Target:
                            Console.Write("T");
                            break;
                        case Maze.Cell.Wall:
                            Console.Write("X");
                            break;
                    }
                }
                Console.WriteLine();
            }
    }
}
