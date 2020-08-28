using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LotteryApp.Models;
using Microsoft.Toolkit.Uwp.Helpers;

namespace LotteryApp.ViewModels
{    
    /// <summary>
     /// CustomerViewModel, contains code for interaction with customer page, model and database.
     /// INotifyPropertyChanged is inherited to allow for two way binding through propertychanged()
     /// </summary>
    public class CustomerViewModel : INotifyPropertyChanged
    {    
         /// <summary>
         /// currentCustModel is set in the NavigateTo event for the CustomerPage.
         /// App allows for only one logged on customer at a time
         /// </summary>
        public CustomerViewModel(Customer currentCustModel)
        {
            CustModel = currentCustModel ?? new Customer();
        }

     
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
              PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// The underlying customer model used within the Customer page.  
        /// </summary>
        private Customer _custModel;
        public Customer CustModel
        {
            get => _custModel;
            set
            {
                if (_custModel != value)
                {
                    _custModel = value;
                    OnPropertyChanged(string.Empty);  //added TB  this is required

                }
            }
        }

        /// <summary>
        /// Gets or sets whether the underlying model has been modified. 
        /// This is used when sync'ing with the server to reduce load
        /// and only upload the models that changed.
        /// </summary>
        internal bool IsModified { get; set; }


        /// <summary>
        /// Gets or sets the customer's first name.
        /// </summary>
        public string CustName
        {
            get => CustModel.CustName;
            set
            {
              if (value != CustModel.CustName)
                {
                    CustModel.CustName = value;
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the customer's email.
        /// </summary>
        public string Email
        {
            get => CustModel.Email;
            set
            {
                if (value != CustModel.Email)
                {
                    CustModel.Email = value;
                    IsModified = true;    //  indicator to say changes have been made to model
                    OnPropertyChanged();  // ensures two way binding between property and text box
                }
            }
        }

        /// <summary>
        /// Gets or sets the customer's phone.
        /// </summary>
        public string Phone
        {
            get => CustModel.Phone;
            set
            {
                if (value != CustModel.Phone)
                {
                    CustModel.Phone = value;
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// updates the Repository's Customers dbSet with the modified Customer Information
        /// </summary>
        public async Task UpdateCustomersAsync()
        {
            if (IsModified == true)
            {
                await App.Repository.CustomersR.UpsertAsync(CustModel);
                IsModified = false;
            }
            
        }

        /// <summary>
        /// Cancels changes on screen, refreshes data for that customer from database
        /// </summary>
        public async Task RefreshCustomer()
        {
            CustModel = await App.Repository.CustomersR.GetAsync(CustModel.CustID);
            IsModified = false;
            OnPropertyChanged(string.Empty); // added for two way binding
        }

    }
}
