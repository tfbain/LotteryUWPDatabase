using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LotteryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LotteryApp.Repository
{
    public class LotteryContext : DbContext
    {
        /// <summary>
        /// Creates a new DbContext.
        /// </summary>
        public LotteryContext(DbContextOptions<LotteryContext> options) : base(options)
        { }

        /// <summary>
        /// Gets the customers DbSet.
        /// </summary>
        //public DbSet<Customer> customer { get; set; } // DbSet is used to query and save instances of the entity Customers  //TB change from Customers to customer
        public DbSet<Customer> Customers { get; set; }  // DbSet is used to query and save insances of the entity Customers, Customer is the model (cs file)
        // ****  Add a DbSet for each entity 
    }
}