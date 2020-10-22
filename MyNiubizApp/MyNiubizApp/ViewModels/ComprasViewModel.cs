using MyNiubizApp.Services;
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

        ConfigurarVisanet _configuration;

        public ComprasViewModel(ConfigurarVisanet configuration)
        {
            Title = "Compras";
            _configuration = configuration;
            ComprarCommand = new Command(OnComprar);
            LevantarFormularioCommand = new Command(OnLevantarFormulario);
        }

        private async void OnLevantarFormulario(object obj)
        {
            _configuration.SettearValores();
            //await Application.Current.MainPage.Navigation.PushAsync(new FormCreditCard(App.configuration));
            await Shell.Current.Navigation.PushAsync(new FormCreditCard(_configuration.Configuration));
        }

        private async void OnComprar(object obj)
        {
            await Shell.Current.GoToAsync(nameof(CreditCardPage));
        }
    }
}
