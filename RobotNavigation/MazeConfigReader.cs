using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace RobotNavigation
{
    public class MazeConfigReader
    {
        private StreamReader _file;

        public MazeConfigReader(string name)
        {
            this._file = new StreamReader(name);
        }

        public List<int> ReadMazeDimensions()
        {
            List<int> list = new List<int>();
            Regex rgxComma = new Regex(",");
            string line = _file.ReadLine();
            string[] rgxArray1 = rgxComma.Split(line);
            return GetCoordinates(rgxArray1);
        }

        public List<int> ReadStartPosition()
        {
            Regex rgxComma = new Regex(",");
            string line = _file.ReadLine();
            string[] rgxArray2 = rgxComma.Split(line);
            return GetCoordinates(rgxArray2);
        }

        public List<List<int>> ReadTargetPositions()
        {
            List<List<int>> list = new List<List<int>>();
            Regex rgxComma = new Regex(",");
            string line = _file.ReadLine();
            Regex rgxSplit = new Regex(@"\|");
            string[] rgxArray3 = rgxSplit.Split(line);
            foreach (string rgx in rgxArray3)
            {
                string[] rgxArray = rgxComma.Split(rgx);
                List<int> coordinates = GetCoordinates(rgxArray);
                list.Add(coordinates);
            }
            return list;
        }

        public List<List<int>> ReadWallPositions()
        {
            List<List<int>> list = new List<List<int>>();
            Regex rgxComma = new Regex(",");
            string line = _file.ReadLine();
            while (line != null)
            {
                string[] rgxArray4 = rgxComma.Split(line);
                List<int> walls = GetCoordinates(rgxArray4);
                for (int i = walls[0]; i < (walls[2] + walls[0]); i++)
                {
                    for (int j = walls[1]; j < (walls[3] + walls[1]); j++)
                    {
                        list.Add(new List<int> {i, j});
                    }
                }
                line = _file.ReadLine();
            }

            return list;
        }        

        private List<int> GetCoordinates(string[] rgxArray)
        {
            List<int> regexArray = new List<int>();
            foreach (string rgxVal in rgxArray)
            {
                Regex regex = new Regex(@"\d+");
                regexArray.Add(Int32.Parse(regex.Match(rgxVal).ToString()));
            }
            return regexArray;
        }
    }
}
