using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LotteryApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SaveChangesDialog : ContentDialog
    {
        public SaveChangesDialog()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the user's choice. 
        /// </summary>
        public SaveChangesDialogResult Result { get; set; } = SaveChangesDialogResult.Cancel;

        /// <summary>
        /// Gets or sets the display message.
        /// </summary>
        public string Message { get; set; } = "You have unsaved changes that will be lost. " +
            "Would you like to save your changes?";

        /// <summary>
        /// Fired when the user chooses to save. 
        /// </summary>
        private void yesButton_Click(object sender, RoutedEventArgs e)
        {
            Result = SaveChangesDialogResult.Save;
            Hide();
        }

        /// <summary>
        /// Fired when the user chooses to discard changes.
        /// </summary>
        private void noButton_Click(object sender, RoutedEventArgs e)
        {
            Result = SaveChangesDialogResult.DontSave;
            Hide();
        }

        /// <summary>
        /// Fired when the user chooses to cancel the operation that triggered the event.
        /// </summary>
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Result = SaveChangesDialogResult.Cancel;
            Hide();
        }
    }

    /// <summary>
    /// Defines the choices available to the user. 
    /// </summary>
    public enum SaveChangesDialogResult
    {
        Save,
        DontSave,
        Cancel
    }
}

