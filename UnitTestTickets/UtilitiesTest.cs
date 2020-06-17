using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LotteryApp.Models;

namespace UnitTestTickets
{
    [TestClass]
    public class UtilitiesTest
    {
        [DataRow(49, new int[] { 31, 22, 30, 41, 5, 16 }, DisplayName = "All good")]
        [DataRow(49, new int[] { 1, 5, 3, 4, 43, 49 }, DisplayName = "All good extremes")]
        [DataTestMethod]
        public void TestCheckAllGoodBalls(int to, int[] balls)
        {
            Boolean bOk = Utilities.checkAllBalls(to, balls);
            Assert.IsTrue(bOk);
        }

        [TestMethod]
        public void TestCheckAllBallsWithDuplicates()
        {
            int[] balls = { 49, 2, 3, 4, 45, 45 };
            Boolean bOk = Utilities.checkAllBalls(49, balls);
            Assert.IsFalse(bOk);
        }

        [DataRow(49, new int[] { 0, 2, 3, 4, 5, 6 }, DisplayName = "Invalid with zero")]
        [DataRow(49, new int[] { 1, 7, 3, 4, 5, 50 }, DisplayName = "Invalid with 50")]
        [DataRow(49, new int[] { 49, 2, 3, 4, 45, -3}, DisplayName = "Invalid with negative")]
        [DataTestMethod]
        public void TestCheckAllBallsWithInvalid(int to, int[] balls)
        {
            Boolean bOk = Utilities.checkAllBalls(to, balls);
            Assert.IsFalse(bOk);
        }

        [TestMethod]
        public void TestCheckAllBallsWithDuplicatesInvalids()
        {
            int[] balls = { 1, 1, 3, 4, 5, 56 };
            Boolean bOk = Utilities.checkAllBalls(49, balls);
            Assert.IsFalse(bOk);
        }
    }
}
