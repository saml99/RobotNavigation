using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public class Maze
    {
        public int Width { get; set; }
        public int Height { get; set; }
       
        private Position[,] _maze;

        public Maze()
        {
        }

        public Maze(int height, int width)
        {
            Width = width;
            Height = height;
            Init();
        }

        public void Init()
        {
            _maze = new Position[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    _maze[i, j] = new Position();
                    _maze[i, j].X = i;
                    _maze[i, j].Y = j;
                    _maze[i, j].Type = Position.CellType.Empty;
                }
            }
        }

        public void SetPosition(int x, int y, Position.CellType c)
        {
            _maze[x, y].X = x;
            _maze[x, y].Y = y;
            _maze[x, y].Type = c;
        }

        public Position GetPosition(int x, int y)
        {
            return _maze[x, y];
        }
    }
}
