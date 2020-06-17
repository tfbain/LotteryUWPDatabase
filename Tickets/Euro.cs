using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System.Update;

namespace Tickets
{
    public class Euro : Ticket  // Euro is a subclass of the base class Ticket
    {
        private int[] _luckyStar = new int[2]; 
        public int[] LuckyStar
        {
            get { return _luckyStar; }
            set
            {
                if (!Utilities.checkAllBalls(49, value))
                {
                    throw new ArgumentException("The ball numbers must be between 1 and 49");
                }
                else if (!validateLucky(value))
                {
                    throw new ArgumentException("The Lucky star numbers cannot match the standard numbers");
                }
                else
                {
                    _luckyStar = value;
                }
            }
        } 
        public string Country { get; set; }
        public Euro():base()
        {
            _luckyStar = generateLuckyStar();
            Country = "UK";
        }
        public int[] generateLuckyStar()
        {
            int[] Lucky = new int[2];
            do
            {
                Lucky = Utilities.generateRandomBalls(49, Lucky);
            } while (!validateLucky(Lucky));

            return Lucky;
        }

        public Boolean validateLucky(int[] lucky)
        {
            Boolean bOK = true;
            int index;
            foreach(int lNo in lucky)
            {
                index = Array.IndexOf(Numbers, lNo);
                if (index >= 0) bOK = false;
            }
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
            sb.Append(Country);
            message = sb.ToString();

            return message;

        }
    }
}
