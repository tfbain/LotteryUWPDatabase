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
     /// <summary>
     /// ViewModel for Logon, email would be sent to main page
     /// currently no authentication so hard coding logon email for example purposes.
     /// </summary>
    public class MainViewModel  
    {
        public MainViewModel(string email) => Task.Run(()=>GetSignedInAsync(email));

        public Customer SignedInCust { get; set; }
        public Customer TempCust;     //  used to store changes on cancel of customer info

        public async Task GetSignedInAsync(string email)             //TB  added this  method, not this would normally be part of authentication
        {
            SignedInCust = (Customer) await App.Repository.CustomersR.GetEmailAsync(email);
        }

    }


}
