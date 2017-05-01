using System.Globalization;

namespace BayardsSafetyApp.AppResources
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
        void SetLocale(CultureInfo ci);
    }
}