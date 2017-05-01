using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BayardsSafetyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Risks : ContentPage
    {
        List<RiskDetails> _risks;
        public Risks(string sectionId)
        {
            InitializeComponent();
            _risks = new List<RiskDetails>();
            var Collection = new List<string>();
            RiskDetails rToBeAdded;
            for (int i = 0; i < 4; i++)
            {
                Collection.Add(sectionId + " Risk " + i.ToString());
                rToBeAdded = new RiskDetails(sectionId + " Risk " + i.ToString(), sectionId + " Risk " + i.ToString());
                _risks.Add(rToBeAdded);
            }
            BindingContext = Collection;
            Title = sectionId;
        }

        private void RiskButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RisksCarousel(_risks, ((Button)sender).CommandParameter.ToString(), Title));
        }

        private void Page_Appeared(object sender, EventArgs e)
        {

        }
    }
}
