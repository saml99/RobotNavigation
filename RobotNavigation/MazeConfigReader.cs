using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace RobotNavigation
{
    public class MazeConfigReader
    {
        private Maze _maze;                     // TL - this doesn't belong here.  The class shouldn't have one of these inside it.
        private Maze.Cell _initial;             // TL - shouldn't be required either
        private Maze.Cell[] _targets;           // TL - see above

        // TL - Make a MazeConfigReader constructor.  Pass the filename as the argument for it.  Open the file there.

        public Maze Load(string name)    // TL - Would recommend calling this function Load() instead and pass in a Maze object.  The objective is to read the config file and load the Maze with it.
        {
            StreamReader file = new StreamReader(name);  // TL - this should be done in the constructor.  The file variable should be a member variable.

            string line = file.ReadLine();
            Regex rgxComma = new Regex(",");
            string[] rgxArray1 = rgxComma.Split(line);
            int[] mazeSize =  GetCoordinates(rgxArray1);
            int rows = mazeSize[0];
            int columns = mazeSize[1];

            line = file.ReadLine();
            string[] rgxArray2 = rgxComma.Split(line);
            int[] initialState = GetCoordinates(rgxArray2);
            int initialX = initialState[0];
            int initialY = initialState[1];

            _maze = new Maze(rows, columns);
            _maze.setCell(initialX, initialY, Maze.Cell.Target);
            _initial = _maze.getCell(initialX, initialY);

            line = file.ReadLine();
            Regex rgxSplit = new Regex(@"\|");
            string[] rgxArray3 = rgxSplit.Split(line);
            _targets = new Maze.Cell[rgxArray3.Length];
            foreach (string rgx in rgxArray3)
            {
                int i = 0;
                string[] rgxArray = rgxComma.Split(rgx);
                int[] coordinates = GetCoordinates(rgxArray);
                int XPosition = coordinates[0];
                int YPosition = coordinates[1];
                _maze.setCell(XPosition, YPosition, Maze.Cell.Target);
                _targets[i] = _maze.getCell(XPosition, YPosition);
                i++;
            }

            line = file.ReadLine();
            while (line != null)
            {
                string[] rgxArray4 = rgxComma.Split(line);
                int[] walls = GetCoordinates(rgxArray4);
                for (int i = walls[0]; i < (walls[2] + walls[0]); i++)
                {
                    for (int j = walls[1]; j < (walls[3] + walls[1]); j++)
                    {
                        _maze.setCell(i, j, Maze.Cell.Wall);
                    }
                }
                line = file.ReadLine();
            }

            file.Close();

            return _maze;
        }

        private int[] GetCoordinates(string[] rgxArray)
        {
            int[] regexArray = new int[4];
            for (int i = 0; i < rgxArray.Length; i++)
            {
                Regex regex = new Regex(@"\d+");
                regexArray[i] = Int32.Parse(regex.Match(rgxArray[i]).ToString());
            }
            return regexArray;
        }

        public Maze getMaze()        // TL - not required.  Delete
        {
            return _maze;
        }

        public Maze.Cell getInitial()  // TL - not required - Delete
        {
            return _initial;
        }

        public Maze.Cell[] getTargets()   // TL - not required - Delete.
        {
            return _targets;
        }
    }
}
