using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LotteryApp.Models;
using Microsoft.Toolkit.Uwp.Helpers;

namespace LotteryApp.ViewModels
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        public CustomerViewModel(Customer currentCustModel)
        {
            // if currentCustModel parameter is null create a new customer,
            // otherwise set CustModel equal to the parameter currentCustModel
            CustModel = currentCustModel ?? new Customer();    
               
        }

     
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
              PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //internal Customer CustModel { get; set; }

        /// <summary>
        /// The underlying customer model. Internal so it is 
        /// not visible to the RadDataGrid. 
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
                    if (!IsModified)
                    {
                        Task.Run(RefreshCustomer);   // added 2408 cancel changes

                        OnPropertyChanged(string.Empty);// added 2408 cancel changes
                    }
                }
            }
        }
        public async Task RefreshCustomer()  // added 2408 cancel changes
        {
            CustModel = await App.Repository.CustomersR.GetAsync(CustModel.CustID);
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
                    IsModified = true;
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
                }
            }
        }


        public async Task UpdateCustomersAsync()
        {
            //update the Repository Customers dbSet with the modified Customer information.
            if (IsModified == true)
            {
                await App.Repository.CustomersR.UpsertAsync(CustModel);
            }
            
        }

       

    }


}
