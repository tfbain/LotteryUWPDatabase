using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LotteryApp.Models;

namespace LotteryApp.Repository
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Returns all customers. 
        /// a task represents an asynchronous operation that can return a value, 
        /// in this case GetAsync() is returning a list of customers, 
        /// TASK is actually the return of GetAsync and is an object than contains the result within it.
        /// </summary>
        Task<IEnumerable<Customer>> GetAsync();

        /// <summary>
        /// Returns all customers with a data field matching the start of the given string. 
        /// </summary>
        Task<IEnumerable<Customer>> GetAsync(string search);

        /// <summary>
        /// Returns the customer with the given id. 
        /// </summary>
        Task<Customer> GetAsync(Guid id);

        /// <summary>
        /// Returns the customer with the given email. 
        /// </summary>
        Task<Customer> GetEmailAsync(string email);

        /// <summary>
        /// Adds a new customer if the customer does not exist, updates the 
        /// existing customer otherwise.
        /// </summary>
        Task<Customer> UpsertAsync(Customer customer);
   
    }
}
