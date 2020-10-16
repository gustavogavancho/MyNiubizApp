using MyNiubizApp.Views;
using System;
using Visanet.Controllers;
using Visanet.Views;
using Xamarin.Forms;

namespace MyNiubizApp.ViewModels
{
    public class ComprasViewModel : BaseViewModel
    {
        public Command ComprarCommand { get; }
        public Command LevantarFormularioCommand { get; }

        ConfigurationController _configuration;

        public ComprasViewModel(ConfigurationController configuration)
        {
            Title = "Compras";
            _configuration = configuration;
            ComprarCommand = new Command(OnComprar);
            LevantarFormularioCommand = new Command(OnLevantarFormulario);
        }

        private async void OnLevantarFormulario(object obj)
        {
            //await Application.Current.MainPage.Navigation.PushAsync(new FormCreditCard(App.configuration));
            await Shell.Current.Navigation.PushAsync(new FormCreditCard(_configuration));
        }

        private async void OnComprar(object obj)
        {
            await Shell.Current.GoToAsync(nameof(CreditCardPage));
        }
    }
}
