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
        internal Customer CustModel { get; set; }

        /// <summary>
        /// The underlying customer model. Internal so it is 
        /// not visible to the RadDataGrid. 
        /// </summary>
        private CustomerViewModel _selectedCust;
        public CustomerViewModel SelectedCust
        {
            get => _selectedCust;
            set
            {
                if (_selectedCust != value)
                {
                    _selectedCust = value;
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
                await App.Repository.CustomersR.UpsertAsync(CustModel);
            //
        }


        public async Task SaveInitialChangesAsync()
        {
            await App.Repository.CustomersR.UpsertAsync(CustModel);
            await UpdateCustomersAsync();
            //AddingNewCustomer = false;
        }
        //// TB ADDED 
        //public async Task GetCustomerListAsync()
        //{
        //    //App is application, Repository is database object created in application,
        //    // Customers is the entity within the sqlite database.
        //    // Reads the full Customers entity and puts it into an object customer
        //    //  
        //    var customers = await App.Repository.CustomersR.GetAsync();  //  CustomersR ***** should be populated with customer view models ****.
        //    if (customers == null)
        //    {
        //        return;
        //    }
        //    await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
        //    {
        //        CustomersVdb.Clear();
        //        foreach (var c in customers)
        //        {
        //            CustomersVdb.Add(new CustomerViewModel(c));
        //        }
        //    });
        //}

    }


}
