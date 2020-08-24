using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using LotteryApp.Repository;
using LotteryApp.Repository.Sql;
using Windows.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using System.Threading.Tasks;
using LotteryApp.Models;

namespace LotteryApp
{

    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        // Initialises an instance of the database entities to be manipulated, coded in ItutorialRepository
        public static ILotteryRepository Repository { get; set; }
        public static  Customer SignedInCust;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>

        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            SqliteDatabase(); // calls the method to connect to and setup dbase


            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (!(Window.Current.Content is Frame rootFrame))
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        public static void SqliteDatabase()
        {
            string demoDatabasePath = Package.Current.InstalledLocation.Path + @"\Assets\LottoAppDbRepository.db";
            string databasePath = ApplicationData.Current.LocalFolder.Path + @"\LottoAppDbRepository.db";
            if (!File.Exists(databasePath))
            {
                try
                {
                    File.Copy(demoDatabasePath, databasePath);
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    System.ArgumentException argEx = new System.ArgumentException("LottoDbRepository not found in assets folder", "copy sqlite file", ex);
                    throw argEx;

                }
            }
            var dbOptions = new DbContextOptionsBuilder<LotteryContext>().UseSqlite("Data Source=" + databasePath);
            Repository = new SqlLotteryRepository(dbOptions);
            string email = "g.starr@basil.com";   //  this would be replaced with authentication or login
            Task.Run(()=>GetSignedInAsync(email));

            // ****  THE FOLLOWING CODE WOULD REPLACE THE ABOVE CODE TO CREATE AN INITIAL INSTANCE OF THE DATABASE ****
            //string databasePath = ApplicationData.Current.LocalFolder.Path + @"\fffLottoAppDbRepository.db";

            //if (!File.Exists(databasePath))
            //{
            //    //create database tables
            //    using (SqliteConnection db = new SqliteConnection($"Filename={databasePath}"))
            //    {
            //        try
            //        {
            //            db.Open();
            //            SqliteCommand CreateTables = new SqliteCommand(System.IO.File.ReadAllText(@"Assets/LotterysqliteCreate.sql"), db);
            //            CreateTables.ExecuteReader();
            //            db.Close();
            //        }
            //        catch (Exception)
            //        {
            //            throw new Exception("Error creating database tables");
            //        }
            //    }
            //    //insert data into database tables
            //    using (SqliteConnection db = new SqliteConnection($"Filename={databasePath}"))
            //    {
            //        try
            //        {
            //            db.Open();
            //            SqliteCommand InsertData = new SqliteCommand(System.IO.File.ReadAllText(@"Assets/LotterysqliteInsert.sql"), db);
            //            InsertData.ExecuteReader();
            //            db.Close();
            //        }
            //        catch (Exception)
            //        {
            //            throw new Exception("Error inserting data to database tables");
            //        }
            //    }
            //}
            //var dbOptions = new DbContextOptionsBuilder<LotteryContext>().UseSqlite("Data Source=" + databasePath);
            //Repository = new SqlLotteryRepository(dbOptions);
        }

        public static async Task GetSignedInAsync(string email)             //TB  added this  method, not this would normally be part of authentication
        {
            
            // CustModel object of type Customer, Customers is the database entity name.
            //CustModel = (Customer)await App.Repository.Customers.GetEmailAsync(email);
            //IEnumerable<Customer> custemails = await App.Repository.Customers.GetAsync("g");

            SignedInCust = await App.Repository.CustomersR.GetEmailAsync(email);


        }
    }
}

