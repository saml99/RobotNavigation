using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public class Program
    {
        static void Main(string[] args)
        {
            MazeConfigReader mazeReader = new MazeConfigReader(args[0]);

            var dimensions = mazeReader.ReadMazeDimensions();
            var startPosition = mazeReader.ReadStartPosition();
            var targetPositions = mazeReader.ReadTargetPositions();
            var wallPositions = mazeReader.ReadWallPositions();

            Maze maze = new Maze(dimensions, wallPositions, targetPositions);

            Position position = new Position();
            MazeSearch mazeSearch = new MazeSearch(maze);

            if (args[1].Equals("breadthfirstsearch", StringComparison.InvariantCultureIgnoreCase))
            {
                BreadthFirstSearch bfs = new BreadthFirstSearch(mazeSearch);
                bfs.Search(new State<Position>(null, null, new Position(startPosition.ElementAt(0), startPosition.ElementAt(1), "Initial")));
            } 
            else if (args[1].Equals("depthfirstsearch", StringComparison.InvariantCultureIgnoreCase)) 
            {
                DepthFirstSearch dfs = new DepthFirstSearch(mazeSearch);
                dfs.Search(new State<Position>(null, null, new Position(startPosition.ElementAt(0), startPosition.ElementAt(1), "Initial")));
            }
            else if (args[1].Equals("uniformcostsearch", StringComparison.InvariantCultureIgnoreCase))
            {
                UniformCostSearch ucs = new UniformCostSearch(mazeSearch);
                ucs.Search(new State<Position>(null, null, new Position(startPosition.ElementAt(0), startPosition.ElementAt(1), "Initial"), 0));
            }
            // else 
            // {
            //    ... unknown search method.  print an error.
            // }



            //maze.setCell(0, 1, Maze.Cell.Target);
            //maze.setCell(7, 0, Maze.Cell.Target);
            //maze.setCell(10, 3, Maze.Cell.Target);


            var view = new MazeView(maze, position);

            //view.Display();

            Console.ReadLine();
        }
    }
}
