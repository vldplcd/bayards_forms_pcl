using BayardsSafetyApp.AppResources;
using System;
using System.IO;
using System.Text;
//using Android.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BayardsSafetyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserAgreementPage : ContentPage
    {
        public UserAgreementPage()
        {
            InitializeComponent();
            AgrmntLabel.Text = LangResources.AgrmntLabel;
            ContinueButton.Text = LangResources.ContinueButton;
        }
        private void ContinueButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties["LocAgr"] = true;
            Navigation.PushAsync(new Sections());
        }
    }
}