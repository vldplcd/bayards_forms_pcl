using BayardsSafetyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BayardsSafetyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
            SearchCommand = new Command(() => { SearchCommandExecute(); });
        }
        public ICommand SearchCommand { get; set; }
        private string _searchedText;
        public string SearchedText
        {
            get { return _searchedText; }
            set { _searchedText = value; SearchCommandExecute(); }
        }
        List<Risk> foundRisks;
        List<Section> foundSections;
        private void SearchCommandExecute()
        {
            foundRisks = new List<Risk> { new Risk { Name = "R1", Id_r = "r1" }, new Risk { Name = "R2", Id_r = "r1" }, new Risk { Name = "R3", Id_r = "r1" } };
            foundSections = new List<Section> { new Section { Name = "S1", Id_s = "s1" }, new Section { Name = "S2", Id_s = "s1" }, new Section { Name = "S3", Id_s = "s1" } };
            sectView.ItemsSource = foundSections.FindAll(i=>i.Name.ToLower().Contains(SearchedText.ToLower()));
            riskView.ItemsSource = foundRisks.FindAll(i => i.Name.ToLower().Contains(SearchedText.ToLower()));
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

        private void RiskButton_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            IsLoading = true;
            API api = new API();
            bool flag = false;
            IsLoading = true;
            //while (!flag)
            //{
            //    if (_risks == null)
            //        _risks = new List<RiskDetails>();

            //    try
            //    {
            //        if (_risks.Count == 0)
            //        {
            //            foreach (var r in _contents.Risks)
            //            {
            //                var rToDisp = api.getRiskContent(r.Id_r, AppResources.LangResources.Language).Result;
            //                _risks.Add(new RiskDetails(rToDisp));
            //            }
            //        }
            //        flag = true;
            //        Navigation.PushAsync(new RisksCarousel(_risks, ((Risk)e.SelectedItem).Id_r, Title));
            //    }
            //    catch (Exception ex)
            //    {
            //        //DisplayAlert("Error", ex.Message, "Ok");
            //    }
            Navigation.PushAsync(new RiskDetails(((Risk)e.SelectedItem)));
            //}


        }
        private void sectView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            IsLoading = true;
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            Navigation.PushAsync(new Risks(((Section)e.SelectedItem).Id_s, ((Section)e.SelectedItem).Name));
        }

        private void searchcustomer_TextChanged(object sender, TextChangedEventArgs e)
        {
            foundRisks = new List<Risk> { new Risk { Name = "R1", Id_r = "r1" }, new Risk { Name = "R2", Id_r = "r1" }, new Risk { Name = "R3", Id_r = "r1" } };
            foundSections = new List<Section> { new Section { Name = "S1", Id_s = "s1" }, new Section { Name = "S2", Id_s = "s1" }, new Section { Name = "S3", Id_s = "s1" } };
            var a = foundSections.FindAll(i => i.Name.ToLower().Contains(searchcustomer.Text.ToLower()));
            sectView.ItemsSource = foundSections.FindAll(i => i.Name.ToLower().Contains(searchcustomer.Text.ToLower()));
            riskView.ItemsSource = foundRisks.FindAll(i => i.Name.ToLower().Contains(searchcustomer.Text.ToLower()));
        }
    }
}
