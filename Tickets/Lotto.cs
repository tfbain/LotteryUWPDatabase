using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    public class LottoT : Ticket
    {
        private int _bonusBall;  // backing variable for BonusBall property
        public int BonusBall    // property with logic applied, adhering to encapsulation
        {
            // ensure the bonus ball is between 1 and 49
            get { return _bonusBall; }
            set
            {
                if (value > 0 && value < 50)  // value is value of bonusball being set through the object
                {
                    _bonusBall = value;
                }
                else
                {
                    throw new ArgumentException("The ball number must be between 1 and 49");
                }
            }
        }
        public string retailerCode { get; set; }

        public LottoT()
        {
        }
        public override string ToString() // This overrides the ToString() class in Ticket.
        {
            string message;
            StringBuilder sb = new StringBuilder();

            sb.Append(customer.Name);
            sb.Append(customer.Email);
            sb.Append(Day);
            sb.Append(Numbers[1]);
            sb.Append(BonusBall);
            message = sb.ToString();

            return message;

        }
    }
}
