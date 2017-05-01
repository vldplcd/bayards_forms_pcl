using System;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace BayardsSafetyApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private string password = string.Empty;
        private void ContinueButton_Clicked(object sender, EventArgs e)
        {
            var api = new API();
            if (api.isPasswordCorrect(PasswordEntry.Text))
            {
                if (Application.Current.Properties.ContainsKey("LocAgr") && (bool)Application.Current.Properties["LocAgr"])
                    Navigation.PushAsync(new Sections());
                else
                    Navigation.PushAsync(new LocalePage());
            }
            else
            {
                DisplayAlert("Warning", "The password is incorrect", "OK");
            }
        }

        private void PasswordEntry_Completed(object sender, EventArgs e)
        {

            password = ((Entry)sender).Text;
        }
    }
}
