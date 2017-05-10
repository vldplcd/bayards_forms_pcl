using BayardsSafetyApp.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BayardsSafetyApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            AInd.IsEnabled = false;
            AInd.IsRunning = false;
        }

        bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        private string password = string.Empty;
        private async void ContinueButton_Clicked(object sender, EventArgs e)
        {
            AInd.IsEnabled = true;
            AInd.IsRunning = true;
            ContinueButton.IsEnabled = false;
            try
            {
                await Task.Run(async () =>
                {

                    var api = new API();
                    if (api.isPasswordCorrect(PasswordEntry.Text))
                    {
                        if (Application.Current.Properties.ContainsKey("LocAgr") && (bool)Application.Current.Properties["LocAgr"])
                        {
                            var AllSections = new Sections();
                            AllSections.Contents = await LoadSections();
                            Navigation.PushAsync(AllSections);
                        }

                        else
                            Navigation.PushAsync(new LocalePage());
                    }
                    else
                    {
                        throw new Exception("Incorrect");
                    }
                });
            }
            catch(TaskCanceledException ex)
            {
                await DisplayAlert("Warning", "The server doesn't responds", "OK");
            }
            catch(Exception ex)
            {
                if(ex.Message.StartsWith("Incorrect"))
                    await DisplayAlert("Warning", "The password is incorrect", "OK");
            }
            AInd.IsEnabled = false;
            AInd.IsRunning = false;
            ContinueButton.IsEnabled = true;

        }

        private void PasswordEntry_Completed(object sender, EventArgs e)
        {

            password = ((Entry)sender).Text;
        }

        private async Task<List<Section>> LoadSections()
        {
            List<Section> contents = new List<Section>();
            API api = new API();
            bool flag = false;
            while (!flag)
            {
                try
                {
                    contents = await api.getCompleteSectionsList(AppResources.LangResources.Language);
                    flag = true;
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null && ex.InnerException.Message.StartsWith("A task"))
                    {
                        throw new TaskCanceledException();
                    }
                }
            }
            return contents;
        }
    }
}
