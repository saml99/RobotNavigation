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
        public bool isSolved(MazeConfigReader data)
        {
            foreach (Maze.Cell cell in data.getTargets())
            {
                if (data.getCurrent() == data.getTargets()[0])
                {
                    return true;
                }
            }
            return false;
        }

        public ArrayList determineMoveSet(State<Maze> state)
        {
            ArrayList moves = new ArrayList();

            int up = state.getData().getUp();
            int right = state.getData().getRight();
            int down = state.getData().getDown();
            int left = state.getData().getLeft();
        }
    }
}
