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
            Assert.AreEqual(maze.getCell(2, 2), Maze.Cell.Empty);
        }

        [TestMethod]
        public void TestSetCell()
        {
            Maze maze = new Maze(5, 11);
            maze.setCell(2, 2, Maze.Cell.Wall);
            Assert.AreEqual(maze.getCell(2, 2), Maze.Cell.Wall);
        }
    }
}
