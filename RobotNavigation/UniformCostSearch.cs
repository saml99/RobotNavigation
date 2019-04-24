using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public class UniformCostSearch
    {
        private LinkedList<State<Position>> _toCheck;
        private HashSet<State<Position>> _visited;

        public MazeSearch search;

        public UniformCostSearch(MazeSearch search)
        {
            _toCheck = new LinkedList<State<Position>>();
            _visited = new HashSet<State<Position>>();
            this.search = search;
        }

        public void Search(State<Position> initial)
        {
            if (initial.GetData() != null)
            {
                _toCheck.AddFirst(initial);
            }

            State<Position> state = null;

            var visited = new HashSet<Position>();

            while (_toCheck.Any())
            {
                state = _toCheck.First.Value;
                _visited.Add(state);
                _toCheck.RemoveFirst();

                if (search.IsSolved(state.GetData()))
                {
                    break;
                }

                foreach (State<Position> statePosition in _visited)
                {
                    visited.Add(statePosition.GetData());
                }
                AddArrayToFrontier(visited, search.DetermineMoveSet(state, visited), state);
            }

            search.DisplaySolution(state, visited.Count);
        }

        public void AddArrayToFrontier(HashSet<Position> visited, ArrayList data, State<Position> parent)
        {
            foreach (Position s in data)
            {
                if (!visited.Contains(s))
                {
                    _toCheck.AddLast(new State<Position>(parent, s.ToString(), s, parent.GetCost()+1));
                }
            }
        }
    }
}
