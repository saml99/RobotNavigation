using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    class MazeSearch
    {
        private Maze _maze;
        
        // TL - recommend storing the current position in the maze as a property (_current_pos)

        public MazeSearch(Maze maze)   // TL - you might want to pass in the start position of the robot as well as the maze, then store it in _current_pos;
        {
            this._maze = maze;
        }

        public bool IsSolved(Position currentPos) 
        {
            return currentPos.GetPosition(_maze).Type == Position.CellType.Target;
        }

        public ArrayList DetermineMoveSet(State<Position> state, HashSet<Position> visited)
        {
            ArrayList moves = new ArrayList();

            int x = state.GetData().X;
            int y = state.GetData().Y;

            if (y > 0)
            {
                var up = _maze.GetPosition(x, y - 1);
                if (!visited.Contains(up) && up.Type != Position.CellType.Wall)
                {
                    up.SetDirection("UP; ");
                    moves.Add(up);
                }
            }
            
            if (x < _maze.Width - 1)
            {
                var right = _maze.GetPosition(x + 1, y);
                if (!visited.Contains(right) && right.Type != Position.CellType.Wall)
                {
                    right.SetDirection("RIGHT; ");
                    moves.Add(right);
                }
            }
            
            if (y < _maze.Height - 1)
            {
                var down = _maze.GetPosition(x, y + 1);
                if (!visited.Contains(down) && down.Type != Position.CellType.Wall)
                {
                    down.SetDirection("DOWN; ");
                    moves.Add(down);
                }
            }
            
            if (x > 0)
            {
                var left = _maze.GetPosition(x - 1, y);
                if (!visited.Contains(left) && left.Type != Position.CellType.Wall)
                {
                    left.SetDirection("LEFT; ");
                    moves.Add(left);
                }
            }
            
            return moves;
        }

        public void DisplaySolution(State<Position> state, int discovered)
        {
            Stack<string> stack = new Stack<string>();

            while (state != null)
            {
                stack.Push(state.GetMessage());
                state = state.GetParent();
            }

            Console.WriteLine(discovered);

            while (stack.Any())
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
