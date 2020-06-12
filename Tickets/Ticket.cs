﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Ticket
    {
        // This is the base class Ticket, Euro and Lotto are subclasses
        public Customer customer { get; set; }   // property

        private int[] _numbers = new int[6];      // field
        public int[] Numbers
        {
            get { return _numbers; }
            set
            {
                Boolean bOK = true;
                foreach (int number in value)  // value is the numbers array being set through the object
                {
                    if (number < 0 || number > 49)  
                    {
                        bOK = false;
                        throw new ArgumentException("The ball numbers must be between 1 and 49");
                    }

                }
                if (bOK) { _numbers = value; }
            }
        }      // autoproperty, integer array, with logic

        public DayOfWeek Day { get; set; }

        private DateTime _dateOfPurchase;
        public DateTime DateOfPurchase { 
            get { return _dateOfPurchase; } 
            set {
                _dateOfPurchase = value;
                Day = nextAvailableDraw();
            } } // date of Purchase

        //public List<string> contacts { get; set;}   //syntax for a list named contacts
        public Ticket() // CONSTRUCTOR
        {

            DateOfPurchase = DateTime.Now;
            customer = new Customer();
  
        }

        public override abstract string ToString(); // This overrides the standard String ToString() class.

        public DayOfWeek nextAvailableDraw()
        {
            TimeSpan timePurchased;
            DayOfWeek nextAvailableDrawDay;
            timePurchased = DateOfPurchase.TimeOfDay;
            if ((DateOfPurchase.DayOfWeek == DayOfWeek.Wednesday && timePurchased >= TimeSpan.FromHours(18))
                || DateOfPurchase.DayOfWeek == DayOfWeek.Thursday
                || DateOfPurchase.DayOfWeek == DayOfWeek.Friday
                || (DateOfPurchase.DayOfWeek == DayOfWeek.Saturday && timePurchased < TimeSpan.FromHours(18)))
            {
                nextAvailableDrawDay = DayOfWeek.Saturday;
            }
            else
            {
                nextAvailableDrawDay = DayOfWeek.Wednesday;
            }
            return nextAvailableDrawDay;
        }

        //public static int[] RandomNum()
        //{
        //    Random rand = new Random();

        //    int min = 1;
        //    int max = 50;

        //    int[] randNums = new int[7];
        //    for (int i = 0; i < randNums.Length; i++)
        //    {
        //        randNums[i] = rand.Next(min, max);
        //    }
        //    return randNums;
        //}

    }
}
