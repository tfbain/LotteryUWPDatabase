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
    public class EuroTTests
    {
        [TestMethod]
        public void TestAllCorrectLuckyStar()
        {
            //arrange
            Euro EuroTicket = new Euro();
            EuroTicket.Numbers = new int[] { 12, 17, 14, 15, 16, 18};
            int[] testNumbers = { 7, 32 };

            //act
            EuroTicket.LuckyStar = testNumbers;

            // assert
            Assert.AreEqual(testNumbers, EuroTicket.LuckyStar);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
               "The ball numbers must be between 1 and 49")]
        public void TestLuckyWithInvalidBalls() 
        {
            //arrange
            Euro EuroTicket = new Euro();
            int[] testNumbers = { 17, 18, 14, 1, 3, 5 };
            int[] testLucky = { 50, 19 };
            //act
            EuroTicket.Numbers = testNumbers;
            EuroTicket.LuckyStar = testLucky;

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "The Lucky star numbers cannot match the standard numbers")]
        public void TestLuckyWithMatchingBalls()
        {
            //arrange
            Euro EuroTicket = new Euro();
            int[] testNumbers = { 17, 18, 14, 1, 27, 5 };
            int[] testLucky = { 27, 19 };
            //act
            EuroTicket.Numbers = testNumbers;
            EuroTicket.LuckyStar = testLucky;

        }
    }
}
