using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryApp.Models
{
    public abstract class Ticket
    {
        // This is the base class Ticket, Euro and Lotto are subclasses
        public Customer Customer { get; set; }   // property

        private int[] _numbers = new int[6];      // field
        public int[] Numbers
        {
            get { return _numbers; }
            set
            {
                if (!Utilities.CheckAllBalls(49, value))
                {
                    throw new ArgumentException("The ball numbers must be between 1 and 49");
                }
                else
                {
                    _numbers = value;
                }
            }
        }      // autoproperty, integer array, with logic

        public DayOfWeek Day { get; set; }

        private DateTime _dateOfPurchase;
        public DateTime DateOfPurchase
        {
            get { return _dateOfPurchase; }
            set
            {
                _dateOfPurchase = value;
                Day = NextAvailableDraw();
            }
        } // date of Purchase

        //public List<string> contacts { get; set;}   //syntax for a list named contacts
        public Ticket() // CONSTRUCTOR
        {

            DateOfPurchase = DateTime.Now;
            Customer = new Customer();
            _numbers = Utilities.GenerateRandomBalls(49, _numbers);
        }

        public override abstract string ToString(); // This overrides the standard String ToString() class.

        public DayOfWeek NextAvailableDraw()
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

    }
}
