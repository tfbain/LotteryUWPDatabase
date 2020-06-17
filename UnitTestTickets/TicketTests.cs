using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tickets;

namespace UnitTestTickets
{
    [TestClass]
    public class TicketTests
    {
        private LottoT lotTicket;

        [TestInitialize]
        public void TestInitialize()
        {
            lotTicket = new LottoT();
        }

        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void TestNextAvailableDrawDay(DayOfWeek CorrectDay, DateTime purchaseDate)
        {
            lotTicket.DateOfPurchase = purchaseDate;
            Assert.AreEqual(CorrectDay, lotTicket.Day);
        }

        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { DayOfWeek.Wednesday, new DateTime(2020, 6, 27, 18, 01, 0) };
            yield return new object[] { DayOfWeek.Wednesday, new DateTime(2020, 6, 27, 18, 00, 0) };
            yield return new object[] { DayOfWeek.Saturday, new DateTime(2020, 6, 27, 17, 59, 0) };
            yield return new object[] { DayOfWeek.Saturday, new DateTime(2020, 6, 24, 18, 01, 0) };
            yield return new object[] { DayOfWeek.Saturday, new DateTime(2020, 6, 24, 18, 00, 0) };
            yield return new object[] { DayOfWeek.Wednesday, new DateTime(2020, 6, 24, 17, 59, 0) };
            yield return new object[] { DayOfWeek.Saturday, new DateTime(2020, 6, 25, 18, 01, 0) };
            yield return new object[] { DayOfWeek.Wednesday, new DateTime(2020, 6, 23, 18, 00, 0) };
            yield return new object[] { DayOfWeek.Wednesday, new DateTime(2020, 6, 21, 09, 00, 0) };
        }

       // [TestCleanup]
       // public void TestCleanUp()
       // {
       //     lotTicket.
       // }
    }
}
