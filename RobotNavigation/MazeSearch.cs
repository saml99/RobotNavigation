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

        public bool isSolved(Position data)   // TL - data is a poor variable name as 'data' could be anything.  Try 'pos' insead
        {
            foreach (Maze.Cell cell in data.getTargets())
            {
                if (data.getPosition(_maze) == data.getTargets()[0])
                {
                    return true;
                }
            }
            return false;
        }

        public ArrayList determineMoveSet(State<Position> state)
        {
            ArrayList moves = new ArrayList();

            int x = state.getData().getX();
            int y = state.getData().getY();
            //int down = state.getData().getDown();
            //int left = state.getData().getLeft();

            if(y > 0)
            {
                moves.Add(new Position(x, y - 1, "UP"));
            }

            return moves;
        }
    }
}
