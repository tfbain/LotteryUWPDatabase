
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LotteryApp.Models;

namespace UnitTestTickets
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void TestCustomer()
        {
            //arrange
            String name = "Young";
            String phone = "09876765";
            String email = "Young.Hat @Dun.ac.uk";
            Customer testCust = new Customer(name, phone, email);
            string expected = name;
            //act
            string response = testCust.Name;

            //assert
            Assert.AreEqual(expected, response);
        }

        [TestMethod]
        public void TestCustomerToString()
        {
            //arrange
            String Name = "Young";
            String Phone = "09876765";
            String Email = "Young.Hat @Dun.ac.uk";
            Customer testCust = new Customer(Name, Phone, Email);
            string expected = String.Format("Name: {0} \nPhone Number: {1} \n" +
                                             "Email: {2}\n", Name, Phone, Email);

            //act
            string response = testCust.ToString();

            //assert
            Assert.AreEqual(expected, response);

        }
    }
}
