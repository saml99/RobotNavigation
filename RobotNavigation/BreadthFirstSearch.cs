using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    class BreadthFirstSearch<T>
    {
        private LinkedList<State<T>> _frontier;

        public MazeSearch scene;

        private int _discovered;
        private int _searched;

        public BreadthFirstSearch(MazeSearch scene)
        {
            _frontier = new LinkedList<State<T>>();
            this.scene = scene;
            _discovered = 0;
            _searched = 0;
        }

        public void search(State<T> initial)
        {
            if(initial.getData() != null)
            {
                _frontier.AddFirst(initial);
            }

            State<T> state = null;

            while (_frontier.Any())
            {
                _frontier.RemoveFirst();

                _searched++;

                if (scene.isSolved(state.getData()))
                {
                    break;
                }
            }
        }
    }
}
