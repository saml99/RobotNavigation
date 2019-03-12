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

        private int _width;
        private int _height;
        private Cell[,] _maze;

        public Maze(int width, int height)
        {
            _width = width;
            _height = height;
            _maze = new Cell[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    _maze[i, j] = Cell.Empty;
                }
            }
        }
        
        public Cell getCell(int x, int y)
        {
            return _maze[x, y];
        }

        public void setCell(int x, int y, Cell c)
        {
            _maze[x, y] = c;
        }
    }
}
