using MyNiubizApp.Services;
using MyNiubizApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyNiubizApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComprasPage : ContentPage
    {
        ComprasViewModel _viewModel;
        ConfigurarVisanet _configurarVisanet;
        public ComprasPage()
        {
            InitializeComponent();
            _configurarVisanet = new ConfigurarVisanet();
            _configurarVisanet.SettearValores();
            BindingContext = _viewModel = new ComprasViewModel(_configurarVisanet.Configuration);
        }

        protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                if (_configurarVisanet.Configuration.Response != null)
                {
                    DisplayAlert("Response", _configurarVisanet.Configuration.Response, "Ok");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
