using System;
using System.Collections.Generic;
using BayardsSafetyApp.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BayardsSafetyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sections : ContentPage
    {
        public Sections()
        {

            InitializeComponent();
 
            Title = "Contents";

        }

        List<Section> _contents;
        public List<Section> Contents
        {
            get { return _contents; }
            set
            {
                _contents = value;
                OnPropertyChanged();
            }
        }

        

        private void SectionButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Risks(((Button)sender).CommandParameter.ToString()));
        }

        private void Sections_OnAppearing(object sender, EventArgs e)
        {
            API api = new API();
            try
            {
                
                Contents = api.getCompleteSectionsList("eng").Result;
                Label1.Text = Contents[0].Name;
            }
            catch (Exception ex)
            {
               DisplayAlert("Error", ex.Message, "Ok");
            }
         }
    }
}
