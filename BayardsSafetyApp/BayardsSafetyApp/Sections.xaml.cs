using System;
using System.Collections.Generic;
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
            var Collection = new List<string> { "1", "2", "3" };
            for (int i = 0; i < 30; i++)
            {
                Collection.Add("Section " + i.ToString());
            }
            BindingContext = Collection;
            Title = "Contents";

        }

        private void SectionButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Risks(((Button)sender).CommandParameter.ToString()));
        }
    }
}
