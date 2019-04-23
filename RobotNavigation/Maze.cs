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
        public enum Cell
        {
            Empty,
            Target,
            Wall
        }

        public int Width { get; set; }
        public int Height { get; set; }
       
        private Cell[,] _maze;

        private ArrayList _targets;
        private Position _pos;

        public Maze()
        {
            _pos = new Position();
            _targets = new ArrayList();
        }

        public Maze(int height, int width)
        {
            Width = width;
            Height = height;
            init();
        }

        public void init()
        {
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

        public void setCell(int x, int y, Cell c)
        {
            _maze[x, y] = c;
        }

        public void setTargets(int x, int y)
        {
            _pos.X = x;
            _pos.Y = y;
            _targets.Add(_pos);
        }

        public ArrayList getTargets()
        {
            return _targets;
        }
    }
}
