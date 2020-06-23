using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LotteryApp.Models;

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

        /// <summary>
        /// The underlying customer model. Internal so it is 
        /// not visible to the RadDataGrid. 
        /// </summary>
        internal Customer CustModel { get; set; }

        /// <summary>
        /// Gets or sets whether the underlying model has been modified. 
        /// This is used when sync'ing with the server to reduce load
        /// and only upload the models that changed.
        /// </summary>
        internal bool IsModified { get; set; }



        /// <summary>
        /// Gets or sets the customer's first name.
        /// </summary>
        public string Name
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

        public async Task CreateNewCustomerAsync()
        {
            //creates a new blank customer
            await App.Repository.Customers.UpsertAsync(CustModel);
            //AddingNewCustomer = true;
        }
        public async Task UpdateCustomersAsync()
        {
            //update the Repository Customers dbSet with the modified Customer information.
                await App.Repository.Customers.UpsertAsync(CustModel);
            //
        }
        public async Task DeleteCustomerAsync()
        {
            if (CustModel != null)
            {
                await App.Repository.Customers.DeleteAsync(CustModel.CustID);
                //AddingNewCustomer = false;
            }
        }

        public async Task SaveInitialChangesAsync()
        {
            await App.Repository.Customers.UpsertAsync(CustModel);
            await UpdateCustomersAsync();
            //AddingNewCustomer = false;
        }

    }


}
