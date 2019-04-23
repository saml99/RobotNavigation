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
        public bool isSolved(Position data, Maze maze)
        {
            foreach (Maze.Cell cell in data.getTargets())
            {
                if (data.getPosition(maze) == data.getTargets()[0])
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
