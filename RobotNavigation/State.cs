using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    public class State<T>
    {
        private T _data;

        private State<T> _parent;

        private string _message;  // TL - what is the messsage you're storing here?  What is it for?

        private int _cost;

        public State(State<T> parent, string message, T data)
        {
            this._parent = parent;
            this._message = message;
            this._data = data;
        }

        public State(State<T> parent, string message, T data, int cost)
        {
            this._parent = parent;
            this._message = message;
            this._data = data;
            this._cost = cost;
        }

        public State<T> getParent()
        {
            return _parent;
        }

        public T getData()
        {
            return _data;
        }

        public string getMessage()
        {
            return _message;
        }

        public int getCost()
        {
            return _cost;
        }
    }
}
