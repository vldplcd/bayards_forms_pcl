using BayardsSafetyApp.Entities;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BayardsSafetyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RiskDetails
    {
        public string RiskId { get; set; }
        public RiskDetails(Risk risk)
        {
            InitializeComponent();
            BackgroundColor = Color.FromHex("#efefef");
            Header.Text = risk.Name;
            RiskId = risk.Id_r;
            textDetails.Text = risk.Content;

        }
        private void NextButton_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new RiskDetails(((Button)sender).CommandParameter.ToString(), ((Button)sender).CommandParameter.ToString()));
        }
        private void PrevButton_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new RiskDetails(((Button)sender).CommandParameter.ToString(), ((Button)sender).CommandParameter.ToString()));
        }
    }
}
