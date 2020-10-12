using MyNiubizApp.Views;
using System;
using Xamarin.Forms;

namespace MyNiubizApp.ViewModels
{
    public class ComprasViewModel : BaseViewModel
    {
        public Command ComprarCommand { get; }

        public ComprasViewModel()
        {
            Title = "Compras";
            ComprarCommand = new Command(OnComprar);
        }

        private async void OnComprar(object obj)
        {
            await Shell.Current.GoToAsync(nameof(CreditCardPage));
        }
    }
}
