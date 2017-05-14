﻿using BayardsSafetyApp.AppResources;
using BayardsSafetyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private async void ContinueButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties["LocAgr"] = true;
            AInd.IsEnabled = true;
            AInd.IsRunning = true;
            ContinueButton.IsEnabled = false;
            var AllSections = new Sections();
            try
            {
                await Task.Run(async () =>
                {

                    var api = new API();
                    AllSections.Contents = await LoadSections();
                    throw new Exception("1");
                });

            }
            catch (TaskCanceledException ex)
            {
                await DisplayAlert("Warning", "The server doesn't respond", "OK");
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith("1"))
                    await Navigation.PushAsync(AllSections);
                if (ex.Message.StartsWith("3"))
                    await Navigation.PushAsync(new LoadingDataPage());
            }
            AInd.IsEnabled = false;
            AInd.IsRunning = false;
            ContinueButton.IsEnabled = true;
        }

        private async Task<List<Section>> LoadSections()
        {
            List<Section> contents = new List<Section>();
            if (!Application.Current.Properties.ContainsKey("UpdateTime") || (Application.Current.Properties.ContainsKey("UpdateTime") &&
                (DateTime)Application.Current.Properties["UpdateTime"] < DateTime.MaxValue))
            {
                throw new Exception("3");
            }
            else
            {
                contents = (App.Database.SectionDatabase.GetItems<Section>()).ToList().FindAll(s => s.Parent_s == "null");
            }
            API api = new API();
            bool flag = false;
            while (!flag)
            {
                try
                {
                    contents = await api.getCompleteSectionsList(AppResources.LangResources.Language);
                    flag = true;
                }
                catch (Newtonsoft.Json.JsonReaderException)
                {
                    throw new TaskCanceledException();
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null && (ex.InnerException.Message.StartsWith("A task") || ex.InnerException.Message.EndsWith("request")))
                    {
                        throw new TaskCanceledException();
                    }
                }
            }

          
            return contents;
        }
    }
}