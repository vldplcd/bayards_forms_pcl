using System;
using Xamarin.Forms.Xaml;

namespace BayardsSafetyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RiskDetails
    {
        public string RiskId { get; set; }
        public RiskDetails(string riskId, string riskName)
        {
            InitializeComponent();
            Header.Text = riskName;
            RiskId = riskId;

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
