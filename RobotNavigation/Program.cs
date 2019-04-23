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
            MazeConfigReader mazeReader = new MazeConfigReader("C:\\Users\\sam.lewis\\Documents\\IntroToAI\\RobotNavigation\\MazeConfig.txt");
            Maze maze = new Maze();
            Position position = new Position();
            // TL - this should be using args[1] instead of this hard coded config file.
            mazeReader.Load(maze, position);

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
            MazeSearch mazeSearch = new MazeSearch(maze);
            BreadthFirstSearch bfs = new BreadthFirstSearch(mazeSearch);

            bfs.Search(new State<Position>(null, null, new Position(position.X, position.Y, "Initial")));

            //maze.setCell(0, 1, Maze.Cell.Target);
            //maze.setCell(7, 0, Maze.Cell.Target);
            //maze.setCell(10, 3, Maze.Cell.Target);


            var view = new MazeView(maze, position);

            view.Display();

            Console.ReadLine();
        }
    }
}
