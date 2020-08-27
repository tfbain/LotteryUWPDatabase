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


namespace LotteryApp.Pages
{
    /// <summary>
    /// Customer page, allows update of customer details.
    /// INotifyPropertyChanged is inherited to allow for two way binding through propertychanged()
    /// </summary>
    public sealed partial class CustomerPage : Page, INotifyPropertyChanged
    {
        public CustomerPage()
        {
            this.InitializeComponent();
            // gets or sets the datacontext for the Customer.xaml page, used for binding xaml to customer page
            DataContext = CustViewModel;   
        }
           
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
 
        /// <summary>
        /// Used when navigating to the Customer form to ensure correct Customer model is displayed. 
        /// </summary>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
             
            if (App.AppViewModel.SignedInCust == null)
            {
                // This should not happen will display a blank customer
                CustViewModel = new CustomerViewModel(new Customer());
            }
            else if (App.AppViewModel.TempCust != null)   // TempCust used for cancelled changes
            {
                CustViewModel = new CustomerViewModel(App.AppViewModel.TempCust);
            }
            else
            {
                // Customer is an existing customer.
                var customer = await App.Repository.CustomersR.GetAsync(App.AppViewModel.SignedInCust.CustID);
                CustViewModel = new CustomerViewModel(customer);
            }

            base.OnNavigatedTo(e);
        }

        /// <summary>
        /// Used when navigating from the Customer form to avoid unsaved changes. 
        /// </summary>
        protected async override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            if (CustViewModel.IsModified)
            {
                var saveDialog = new SaveChangesDialog()
                {
                    Title = $"Save changes to Customer {CustViewModel.Email}?",
                    Message = $"Customer {CustViewModel.CustModel} " +
                        "has unsaved changes that will be lost. Do you want to save your changes?"
                };

                await saveDialog.ShowAsync();
                SaveChangesDialogResult result = saveDialog.Result;
                App.AppViewModel.TempCust = null;
                switch (result)
                {
                    case SaveChangesDialogResult.Save:
                        await CustViewModel.UpdateCustomersAsync();
                        break;
                    case SaveChangesDialogResult.DontSave:
                        await CustViewModel.RefreshCustomer();
                        break;
                    case SaveChangesDialogResult.Cancel:
                        App.AppViewModel.TempCust = CustViewModel.CustModel;
                        if (e.NavigationMode == NavigationMode.Back)
                        {
                            Frame.GoForward();
                        }
                        else
                        {
                            Frame.GoBack();
                        }
                        e.Cancel = true;
                        CustViewModel.IsModified = true;
                        break;
                }
            }
            
            base.OnNavigatingFrom(e);
        }

        /// <summary>
        /// Fired when a property value changes to allow for binding model to xaml page. 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies listeners that a property value changed. 
        /// </summary>
        private void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}



