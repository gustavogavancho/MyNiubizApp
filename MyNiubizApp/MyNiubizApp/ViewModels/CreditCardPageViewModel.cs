using System.ComponentModel;

namespace MyNiubizApp.ViewModels
{
    public class CreditCardPageViewModel : BaseViewModel
    {
        public string CardNumber { get; set; }
        public string CardCvv { get; set; }
        public string CardExpirationDate { get; set; }

        public CreditCardPageViewModel()
        {
            Title = "Pagar compra";
        }
    }
}
