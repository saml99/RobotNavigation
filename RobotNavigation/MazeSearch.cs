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
        private Position _currentPosition;
        
        // TL - recommend storing the current position in the maze as a property (_current_pos)

        public MazeSearch(Maze maze)   // TL - you might want to pass in the start position of the robot as well as the maze, then store it in _current_pos;
        {
            this._maze = maze;
        }

        public bool IsSolved(Position currentPos) 
        {
            return currentPos.GetPosition(_maze).Type == Position.CellType.Target;
        }

        public ArrayList DetermineMoveSet(State<Position> state)
        {
            ArrayList moves = new ArrayList();

            int x = state.GetData().X;
            int y = state.GetData().Y;

            if (y > 0 || _maze.GetPosition(x, y - 1).Type != Position.CellType.Wall)
            {
                moves.Add(new Position(x, y - 1, "UP"));
            }

            if (x < _maze.Width || _maze.GetPosition(x + 1, y).Type != Position.CellType.Wall)
            {
                moves.Add(new Position(x + 1, y, "RIGHT"));
            }

            if (y < _maze.Height || _maze.GetPosition(x, y + 1).Type != Position.CellType.Wall)
            {
                moves.Add(new Position(x, y + 1, "DOWN"));
            }

            if (x > 0 || _maze.GetPosition(x - 1, y).Type != Position.CellType.Wall)
            {
                moves.Add(new Position(x - 1, y, "LEFT"));
            }

            return moves;
        }
    }
}
