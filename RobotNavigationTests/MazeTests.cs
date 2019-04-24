using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotNavigation;

namespace RobotNavigationTests
{
    [TestClass]
    public class MazeTests
    {
        [TestMethod]
        public void TestCellEmpty()
        {
            Maze maze = new Maze(5, 11);
            Assert.AreEqual(maze.GetPosition(2, 2), Position.CellType.Empty);
        }

        [TestMethod]
        public void TestSetCell()
        {
            Maze maze = new Maze(5, 11);
            maze.SetPosition(2, 2, Position.CellType.Wall);
            Assert.AreEqual(maze.GetPosition(2, 2), Position.CellType.Wall);
        }
    }
}
