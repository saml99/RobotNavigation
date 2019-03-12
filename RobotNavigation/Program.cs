using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    class Program
    {
        static void Main(string[] args)
        {
            var maze = new Maze(5, 11);

            maze.setCell(2, 7, Maze.Cell.Target);


            var view = new MazeView(maze);

            view.Display();
        }
    }
}
