using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public class Maze
    {
        public enum Cell
        {
            Empty,
            Target,
            Wall
        }

        public int Width { get; set; }
        public int Height { get; set; }

        private int up;
        private int right;
        private int down;
        private int left;
       
        private Cell[,] _maze;

        public Maze(int height, int width)
        {
            Width = width;
            Height = height;
            _maze = new Cell[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    _maze[i, j] = Cell.Empty;
                }
            }
        }
        
        public Cell getCell(int x, int y)
        {
            return _maze[x, y];
        }

        public Cell getCell(Maze.Cell cell)
        {
            return cell;
        }

        public Maze.Cell[] getTargets(MazeConfigReader mazeConfig)
        {
            return mazeConfig.getTargets();
        }

        public void setCell(int x, int y, Cell c)
        {
            _maze[x, y] = c;
        }
    }
}
