using System.Globalization;
using BayardsSafetyApp.AppResources;
using Xamarin.Forms;

namespace BayardsSafetyApp
{
    public partial class App : Application
    {
        public static bool LocAgr = false;
        public App()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
            {
                var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                LangResources.Culture = ci; // set the RESX for resource localization
                DependencyService.Get<ILocalize>().SetLocale(ci); // set the Thread for locale-aware methods
            }

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
