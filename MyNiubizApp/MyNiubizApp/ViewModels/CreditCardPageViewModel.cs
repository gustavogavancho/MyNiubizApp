using MyNiubizApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyNiubizApp.ViewModels
{
    public class CreditCardPageViewModel : BaseViewModel
    {
        public Command TestCommand { get; }

        public string CardNumber { get; set; }
        public string CardCvv { get; set; }
        public string CardExpirationDate { get; set; }

        public CreditCardPageViewModel()
        {
            Title = "Pagar compra";
            TestCommand = new Command(OnTest);
        }

        private void OnTest(object obj)
        {
            var result5 = App.configuration.GetSecurityAsync();
            var result6 = App.configuration.GetSecurityAsyncWhitAuthorization();
            var result7 = App.configuration.GetSecurityAsyncWhitAuthorizationAll("aW50ZWdyYWNpb25lcy52aXNhbmV0QG5lY29tcGx1cy5jb206ZDVlN25rJE0=");
            var result8 = App.configuration.GetSecurityFromConfiguration();
            var result = App.configuration.CreateSessionAsync();
            var result1 = App.configuration.AuthorizeECommerceAsync();
            var result2 = App.configuration.CreateTransactionTokenAsync();
            var result3 = App.configuration.GetConfigurationMerchant();
            var result4 = App.configuration.GetQueryBin("340000");
            App.configuration.SetTrustDefender();
            //var result9 = App.configuration.LoadFromXaml(nameof(CreditCardPage));
        }
    }
}
