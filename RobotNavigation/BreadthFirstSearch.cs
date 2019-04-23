using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    class BreadthFirstSearch
    {
        private LinkedList<State<Position>> _frontier;

        public MazeSearch search;

        private int _discovered;
        private int _searched;

        public BreadthFirstSearch(MazeSearch search)
        {
            _frontier = new LinkedList<State<Position>>();
            this.search = search;
            _discovered = 0;
            _searched = 0;
        }

        public void Search(State<Position> initial)
        {
            if (initial.GetData() != null)
            {
                _frontier.AddFirst(initial);
            }

            State<Position> state = null;

            while (_frontier.Any())
            {
                _frontier.RemoveFirst();

                _searched++;

                if (search.IsSolved(state.GetData()))
                {
                    break;
                }

                AddArrayToFrontier(search.DetermineMoveSet(state), state);
            }
        }

        public void AddArrayToFrontier(ArrayList data, State<Position> parent)
        {
            foreach (Position s in data)
            {
                _frontier.AddLast(new State<Position>(parent, s.ToString(), s));

                _discovered++;
            }
        }
    }
}
