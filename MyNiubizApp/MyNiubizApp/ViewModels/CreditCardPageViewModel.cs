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
            Title = "Compra";
            TestCommand = new Command(OnTest);
        }

        private void OnTest(object obj)
        {
        }
    }
}
