using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryApp.Models
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
                if (!(value > 0 && value < 50))
                {
                    throw new ArgumentException("The bonus ball must be between 1 and 49");
                }
                else if (!validateBonus(value))
                {
                    throw new ArgumentException("The bonus ball must not match any of the Lottery Numbers");
                }
                else
                {
                    _bonusBall = value;
                }
            }
        }
        public string retailerCode { get; set; }

        public LottoT() : base()
        {
            _bonusBall = generateBonusBall();
        }

        public int generateBonusBall()
        {
            Random rand = new Random();
            int randNo = 0;
            do
            {
                randNo = rand.Next(1, 49) + 1;
            } while (!validateBonus(randNo));

            return randNo;
        }

        public Boolean validateBonus(int Bonus)
        {
            Boolean bOK = true;
            int index = Array.IndexOf(Numbers, Bonus);

            if (index >= 0) bOK = false;
            return bOK;
        }

        public override string ToString() // This overrides the ToString() class in Ticket.
        {
            string message;
            StringBuilder sb = new StringBuilder();

            sb.Append(Customer.Name);
            sb.Append(Customer.Email);
            sb.Append(Day);
            sb.Append(Numbers[1]);
            sb.Append(BonusBall);
            message = sb.ToString();

            return message;

        }
    }
}

