using MyNiubizApp.Views;
using System;
using Visanet.Views;
using Xamarin.Forms;

namespace MyNiubizApp.ViewModels
{
    public class ComprasViewModel : BaseViewModel
    {
        public Command ComprarCommand { get; }
        public Command LevantarFormularioCommand { get; }

        public ComprasViewModel()
        {
            Title = "Compras";
            ComprarCommand = new Command(OnComprar);
            LevantarFormularioCommand = new Command(OnLevantarFormulario);
        }

        private async void OnLevantarFormulario(object obj)
        {
            //await Application.Current.MainPage.Navigation.PushAsync(new FormCreditCard(App.configuration));
            await Shell.Current.Navigation.PushAsync(new FormCreditCard(App.configuration));
        }

        private async void OnComprar(object obj)
        {
            await Shell.Current.GoToAsync(nameof(CreditCardPage));
        }
    }
}
