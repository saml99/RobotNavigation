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
       
        private Cell[,] _maze;

        public Maze(int width, int height)
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

        public void setCell(int x, int y, Cell c)
        {
            _maze[x, y] = c;
        }

    }
}
