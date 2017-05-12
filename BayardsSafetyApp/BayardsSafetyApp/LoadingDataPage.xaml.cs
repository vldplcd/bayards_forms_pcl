using BayardsSafetyApp.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BayardsSafetyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingDataPage : ContentPage
    {
        public LoadingDataPage()
        {
            InitializeComponent();
        }
        DBLoading.LoadData ld = new DBLoading.LoadData();
        double _progressState;
        public double ProgressState
        {
            get { return _progressState; }
            set
            {
                _progressState = value;
                OnPropertyChanged();
            }
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            Device.StartTimer(new TimeSpan(0, 0, 2), () => { return OnTimerToLoad().Result; });
        }

        private async Task<bool> OnTimerToLoad()
        {
            try
            {
                ld.ToDatabase().Wait();
                var Cont = new Sections();
                string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath("bayards.db");
                List<Risk> a;
                List<Media> b;
                using (var context = App.Database.SectionDatabase)
                {
                    Cont.Contents = await context.GetItemsAsync<Section>();
                }

                using (var context = App.Database.RiskDatabase)
                {
                    a = await context.GetItemsAsync<Risk>();
                }

                using (var context = App.Database.MediaDatabase)
                {
                    b = await context.GetItemsAsync<Media>();
                }

                await Navigation.PushAsync(Cont);
                //while (load.Status == TaskStatus.Running || load.Status == TaskStatus.WaitingToRun || load.Status == TaskStatus.WaitingForActivation)
                //{
                //    PrBar.Progress = ld.Process;
                //}
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
            return false;
        }
    }
}
