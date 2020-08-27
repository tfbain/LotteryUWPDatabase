using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Toolkit.Uwp.UI.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using LotteryApp.ViewModels;
using LotteryApp.Views;
using LotteryApp.Models;
using LotteryApp;
using System.ComponentModel;
using System.Runtime.CompilerServices;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LotteryApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomerPage : Page, INotifyPropertyChanged
    {
        public CustomerPage()
        {
            this.InitializeComponent();
            // gets or sets the datacontext for the RadDataGrid in the xaml which requires binding
            DataContext = CustViewModel;   // code below links this to CustomerListPageViewModel
        }


        // creates an instance of the CustomerViewModel
        // NOTE AT THIS POINT it would be the customer who has logged on who 
        // would be sent to the CustomerViewModel, for now this is a new instance
        // Data can be added in the customer.xaml.
        // public CustomerViewModel CustViewModel { get; set; } =
        //     new CustomerViewModel(new Models.Customer("Garry starr", "0131 345678", "g.starr@basil.com"));

        // public CustomerViewModel CustViewModel { get; set; } =
        //   new CustomerViewModel(App.SignedInCust);   //  note this is set at app.xaml.cs for now to replace logon or authentication
        
        private CustomerViewModel _custViewModel;
        public CustomerViewModel CustViewModel 
        {    get => _custViewModel;
            set
            {
                if (_custViewModel != value)
                {
                    _custViewModel = value;
                    OnPropertyChanged();
                }
            }
             
        }
        //      new CustomerViewModel(App.AppViewModel.SignedInCust);   //  note this is set at app.xaml.cs for now to replace logon or authentication
        
        
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
             
            
            //      new CustomerViewModel(App.AppViewModel.SignedInCust);
            if (App.AppViewModel.SignedInCust == null)
            {
                // Order is a new order
                CustViewModel = new CustomerViewModel(new Customer());
            }
            else
            {
                // Customer is an existing customer.
                var customer = await App.Repository.CustomersR.GetAsync(App.AppViewModel.SignedInCust.CustID);
                CustViewModel = new CustomerViewModel(customer);
            }

            base.OnNavigatedTo(e);
        }
        protected async override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            if (CustViewModel.IsModified)
            {
                var saveDialog = new SaveChangesDialog()
                {
                    Title = $"Save changes to Customer {CustViewModel.Email.ToString()}?",
                    Message = $"Customer {CustViewModel.CustModel.ToString()} " +
                        "has unsaved changes that will be lost. Do you want to save your changes?"
                };

                await saveDialog.ShowAsync();
                SaveChangesDialogResult result = saveDialog.Result;

                switch (result)
                {
                    case SaveChangesDialogResult.Save:
                        await CustViewModel.UpdateCustomersAsync();
                        break;
                    case SaveChangesDialogResult.DontSave:
                        await CustViewModel.RefreshCustomer();
                        break;
                    case SaveChangesDialogResult.Cancel:
                        if (e.NavigationMode == NavigationMode.Back)
                        {
                            Frame.GoForward();
                        }
                        else
                        {
                            Frame.GoBack();
                        }
                        e.Cancel = true;
                        // This flag gets cleared on navigation, so restore it. 
                        CustomerViewModel tempCust = CustViewModel;
                        CustViewModel.IsModified = true;
                        break;
                }
            }
            
            base.OnNavigatingFrom(e);
        }

        /// <summary>
        /// Fired when a property value changes. 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies listeners that a property value changed. 
        /// </summary>
        private void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}



