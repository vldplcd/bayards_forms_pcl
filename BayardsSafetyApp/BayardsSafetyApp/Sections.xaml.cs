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
            IsLoading = false;
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

        protected override Boolean OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return true;
        }
        private void SectionButton_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            IsLoading = true;
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            Navigation.PushAsync(new Risks(((Section)e.SelectedItem).Id_s, ((Section)e.SelectedItem).Name));
        }

        private void Sections_OnAppearing(object sender, EventArgs e)
        {
            API api = new API();
            bool flag = false;
            while (!flag)
            {
                try
                {
                    Contents = api.getCompleteSectionsList(AppResources.LangResources.Language).Result;
                    sectView.ItemsSource = _contents;
                    flag = true;
                }
                catch (Exception ex)
                {
                    //DisplayAlert("Error", ex.Message, "Ok");
                }
            }
            
         }


    }
}
