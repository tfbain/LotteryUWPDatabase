using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryApp.Models
{
    public class Customer : IEquatable<Customer>
    {
        [Key]
        public Guid CustID { get; set; } = Guid.NewGuid();
        public string CustName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        // constructor using an expression body, this is a shorthand version
        //public Customer(int customerId) => custID = customerId;
        public Customer()
        {
            this.CustName = "";
            this.Phone = "";
            this.Email = "";
        }
        public Customer(string Name, string Phone, string Email)
        {
            this.CustName = Name;
            this.Phone = Phone;
            this.Email = Email;
        }

        public bool Equals(Customer otherCustomer)
        {
            return
                this.CustName == otherCustomer.CustName &&
                this.Phone == otherCustomer.Phone &&
                this.Email == otherCustomer.Email;
        }
        public override string ToString() // This overrides the standard String ToString() class.
        {
            return String.Format("Name: {0} \nPhone Number: {1} \nEmail: {2}\n",
                CustName, Phone, Email);
        }

    }
}
