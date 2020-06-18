using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LotteryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LotteryApp.Repository
{
    public class CustomerContext : DbContext
    {
        /// <summary>
        /// Creates a new DbContext.
        /// </summary>
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        { }

        /// <summary>
        /// Gets the customers DbSet.
        /// </summary>
        public DbSet<Customer> Customers { get; set; } // DbSet is used to query and save instances of the entity Customers
    }
}
