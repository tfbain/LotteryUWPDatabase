using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LotteryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LotteryApp.Repository.Sql
{
    public class SqlCustomerRepository : ICustomerRepository
    {
        private readonly LotteryContext _db;

        public SqlCustomerRepository(LotteryContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Returns all customers. 
        /// a task represents an asynchronous operation that can return a value, 
        /// in this case GetAsync() is returning a list of customers, 
        /// TASK is actually the return of GetAsync and is an object than contains the result within it.
        /// </summary>
        public async Task<IEnumerable<Customer>> GetAsync()
        {
            return await _db.Customers  // this is entity
                .AsNoTracking()  // this is read only so disables change tracking, i.e. checking if data updated
                .ToListAsync();  // creates a list from the queriable db customers
        }
        /// <summary>
        /// Returns the customer with the given ID. 
        /// </summary>
        public async Task<Customer> GetAsync(Guid id)
        {
            return await _db.Customers     //  Customers is the database Entity
                .AsNoTracking()                 // this is read only so disables change tracking, i.e. checking if data updated
                .FirstOrDefaultAsync(x => x.CustID == id);   // searches for a customer with the specific ID and returns if exists ?????
        }

        /// <summary>
        /// Returns the customer with the given Email.  RETURNS a Customer object 
        /// </summary>
        public async Task<Customer> GetEmailAsync(string email)
        {
            return await _db.Customers     //  Customers is the database Entity
                .AsNoTracking()                 // this is read only so disables change tracking, i.e. checking if data updated
                .FirstOrDefaultAsync(x => x.Email == email);   // searches for a customer with the specific email and returns if exists.
        }

        /// <summary>
        /// Returns all customers with a data field matching the start of the given string. RETURNS A LIST 
        /// </summary>
        public async Task<IEnumerable<Customer>> GetAsync(string value)
        {
            string[] parameters = value.Split(' ');
            return await _db.Customers
                .Where(x =>
                    parameters.Any(y =>
                        x.CustName.StartsWith(y) ||
                        x.Email.StartsWith(y) ||
                        x.Phone.StartsWith(y) ))
                .OrderByDescending(x =>
                    parameters.Count(y =>
                        x.CustName.StartsWith(y) ||
                        x.Email.StartsWith(y) ||
                        x.Phone.StartsWith(y) ))
                 .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Customer> UpsertAsync(Customer customer)  // update or insert customer
        {
            var current = await _db.Customers.FirstOrDefaultAsync(x => x.CustID == customer.CustID);
            if (null == current)
            {
                _db.Customers.Add(customer);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(customer);
            }
            await _db.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteAsync(Guid id)  // delete customer
        {
            var customer = await _db.Customers.FirstOrDefaultAsync(x => x.CustID == id);
            if (null != customer)
            {
                _db.Customers.Remove(customer);
                await _db.SaveChangesAsync();
            }
        }
    }
}




