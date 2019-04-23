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

            // TL - this should be using args[1] instead of this hard coded config file.
            var maze = mazeReader.ReadFile("C:\\Users\\sam.lewis\\Documents\\IntroToAI\\RobotNavigation\\MazeConfig.txt");

            // TL - you should add your 
            // if (args[2].Equals("breadthfirst", StringComparison.InvariantCultureIgnoreCase))
            // { 
            //    ... do breath first here
            // } 
            // else if (args[2].Equals("depthfirst", StringComparison.InvariantCultureIgnoreCase)) 
            // {
            //    ... do depth first here
            // } 
            // else 
            // {
            //    ... unknown search method.  print an error.
            // }
            MazeSearch mazeSearch = new MazeSearch();
            BreadthFirstSearch<Maze.Cell> bfs = new BreadthFirstSearch<Maze.Cell>(mazeSearch);

            bfs.search(new State<Maze.Cell>(null, null, maze.getCell(mazeReader.getInitial())));

            //maze.setCell(0, 1, Maze.Cell.Target);
            //maze.setCell(7, 0, Maze.Cell.Target);
            //maze.setCell(10, 3, Maze.Cell.Target);


            var view = new MazeView(maze);

            view.Display();

            Console.ReadLine();
        }
    }
}
