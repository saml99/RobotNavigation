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
        private StreamReader _file;

        private Maze.Cell[] _targets;           // TL - see above

        public MazeConfigReader(string name)
        {
            this._file = new StreamReader(name);
        }

        public void Load(Maze maze, Position pos)    // TL - Would recommend calling this function Load() instead and pass in a Maze object.  The objective is to read the config file and load the Maze with it.
        {
            string line = _file.ReadLine();
            Regex rgxComma = new Regex(",");
            string[] rgxArray1 = rgxComma.Split(line);
            int[] mazeSize =  GetCoordinates(rgxArray1);
            maze.Height = mazeSize[0];
            maze.Width = mazeSize[1];

            line = _file.ReadLine();
            string[] rgxArray2 = rgxComma.Split(line);
            int[] initialState = GetCoordinates(rgxArray2);
            pos.X = initialState[0];
            pos.Y = initialState[1];

            maze.drawMaze();
            maze.setCell(pos.X, pos.Y, Maze.Cell.Target);

            line = _file.ReadLine();
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
                maze.setCell(XPosition, YPosition, Maze.Cell.Target);
                _targets[i] = maze.getCell(XPosition, YPosition);
                i++;
            }

            line = _file.ReadLine();
            while (line != null)
            {
                string[] rgxArray4 = rgxComma.Split(line);
                int[] walls = GetCoordinates(rgxArray4);
                for (int i = walls[0]; i < (walls[2] + walls[0]); i++)
                {
                    for (int j = walls[1]; j < (walls[3] + walls[1]); j++)
                    {
                        maze.setCell(i, j, Maze.Cell.Wall);
                    }
                }
                line = _file.ReadLine();
            }

            _file.Close();
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

        public Maze.Cell[] getTargets()   // TL - not required - Delete.
        {
            return _targets;
        }
    }
}
