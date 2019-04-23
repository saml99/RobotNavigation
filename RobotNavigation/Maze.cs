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
       
        private Position.Cell[,] _maze;

        private ArrayList _targets;
        private Position _target;

        public Maze()
        {
            _target = new Position();
            _targets = new ArrayList();
        }

        public Maze(int height, int width)
        {
            Width = width;
            Height = height;
            Init();
        }

        public void Init()
        {
            _maze = new Position.Cell[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    _maze[i, j] = Position.Cell.Empty;
                }
            }
        }
        
        public Position.Cell GetCell(int x, int y)
        {
            return _maze[x, y];
        }

        public Position.Cell GetCell(Position.Cell cell)
        {
            return cell;
        }

        public void SetCell(int x, int y, Position.Cell c)
        {
            _maze[x, y] = c;
        }

        public void SetTarget(int x, int y)
        {
            _target.X = x;
            _target.Y = y;
            _targets.Add(_target);
        }

        public ArrayList GetTargets()
        {
            return _targets;
        }
    }
}
