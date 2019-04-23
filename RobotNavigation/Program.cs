using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    class Program
    {
        static void Main(string[] args)
        {
            MazeConfigReader mazeReader = new MazeConfigReader();

            var maze = mazeReader.ReadFile("C:\\Users\\sam.lewis\\Documents\\IntroToAI\\RobotNavigation\\MazeConfig.txt");

            MazeSearch mazeSearch = new MazeSearch();
            BreadthFirstSearch<Position> bfs = new BreadthFirstSearch<Position>(mazeSearch);

            bfs.search(new State<Position>(null, null, new Position(mazeReader.getInitial(), "Initial")));

            //maze.setCell(0, 1, Maze.Cell.Target);
            //maze.setCell(7, 0, Maze.Cell.Target);
            //maze.setCell(10, 3, Maze.Cell.Target);


            var view = new MazeView(maze);

            view.Display();

            Console.ReadLine();
        }
    }
}
