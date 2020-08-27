using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LotteryApp.Models;
using System.Collections.ObjectModel;
using Microsoft.Toolkit.Uwp.Helpers;

namespace LotteryApp.ViewModels
{
    public class MainViewModel  
    {
        //public MainViewModel(string email) => Task.Run(()=>GetSignedInAsync(email));
        public MainViewModel(string email)
        {
            Task.Run(() => GetSignedInAsync(email));
        }

        public Customer SignedInCust { get; set; } 

        public async Task GetSignedInAsync(string email)             //TB  added this  method, not this would normally be part of authentication
        {

            // CustModel object of type Customer, Customers is the database entity name.
            //CustModel = (Customer)await App.Repository.Customers.GetEmailAsync(email);
            //IEnumerable<Customer> custemails = await App.Repository.Customers.GetAsync("g");

            SignedInCust = (Customer) await App.Repository.CustomersR.GetEmailAsync(email);
        

        }

    }


}
