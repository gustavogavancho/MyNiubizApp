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
        public Command LevantarFormularioPruebaCommand { get; }
        public Command LevantarFormularioPrueba2Command { get; }
        public Command LevantarFormularioPrueba3Command { get; }
        public Command LevantarFormularioPrueba4Command { get; }
        public Command LevantarFormularioPrueba5Command { get; }

        ConfigurarVisanet _configuration;

        public ComprasViewModel(ConfigurarVisanet configuration)
        {
            Title = "Compras";
            _configuration = configuration;
            ComprarCommand = new Command(OnComprar);
            LevantarFormularioCommand = new Command(OnLevantarFormulario);
            LevantarFormularioPruebaCommand = new Command(OnLevantarFormularioPrueba);
            LevantarFormularioPrueba2Command = new Command(OnLevantarFormularioPrueba2);
            LevantarFormularioPrueba3Command = new Command(OnLevantarFormularioPrueba3);
            LevantarFormularioPrueba4Command = new Command(OnLevantarFormularioPrueba4);
            LevantarFormularioPrueba5Command = new Command(OnLevantarFormularioPrueba5);
        }

        private async void OnLevantarFormularioPrueba5(object obj)
        {
            _configuration.SettearValores();
            //await Application.Current.MainPage.Navigation.PushAsync(new FormCreditCard(App.configuration));
            await Shell.Current.Navigation.PushAsync(new PopupLoading());
        }

        private async void OnLevantarFormularioPrueba4(object obj)
        {
            _configuration.SettearValores();
            //await Application.Current.MainPage.Navigation.PushAsync(new FormCreditCard(App.configuration));
            await Shell.Current.Navigation.PushAsync(new Page3());
        }

        private async void OnLevantarFormularioPrueba3(object obj)
        {
            _configuration.SettearValores();
            //await Application.Current.MainPage.Navigation.PushAsync(new FormCreditCard(App.configuration));
            await Shell.Current.Navigation.PushAsync(new Page2());
        }

        private async void OnLevantarFormularioPrueba2(object obj)
        {
            _configuration.SettearValores();
            //await Application.Current.MainPage.Navigation.PushAsync(new FormCreditCard(App.configuration));
            await Shell.Current.Navigation.PushAsync(new ModalCvv());
        }

        private async void OnLevantarFormularioPrueba(object obj)
        {
            _configuration.SettearValores();
            //await Application.Current.MainPage.Navigation.PushAsync(new FormCreditCard(App.configuration));
            await Shell.Current.Navigation.PushAsync(new FormularioDatosUsuario());
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
