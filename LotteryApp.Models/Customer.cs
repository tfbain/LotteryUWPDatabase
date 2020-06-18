using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryApp.Models
{
    public class Customer : IEquatable<Customer>
    {
        public Guid CustID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        // constructor using an expression body, this is a shorthand version
        //public Customer(int customerId) => custID = customerId;
        public Customer()
        {
            this.Name = "";
            this.Phone = "";
            this.Email = "";
        }
        public Customer(string Name, string Phone, string Email)
        {
            this.Name = Name;
            this.Phone = Phone;
            this.Email = Email;
        }

        public bool Equals(Customer otherCustomer)
        {
            return
                this.Name == otherCustomer.Name &&
                this.Phone == otherCustomer.Phone &&
                this.Email == otherCustomer.Email;
        }
        public override string ToString() // This overrides the standard String ToString() class.
        {
            return String.Format("Name: {0} \nPhone Number: {1} \nEmail: {2}\n",
                Name, Phone, Email);
        }

    }
}
