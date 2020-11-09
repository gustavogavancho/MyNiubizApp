using MyNiubizApp.Services;
using MyNiubizApp.ViewModels;
using Newtonsoft.Json;
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
            BindingContext = _viewModel = new ComprasViewModel(_configurarVisanet);
        }

        protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                if (_configurarVisanet.Configuration.Response != null)
                {
                    DisplayAlert("Response", _configurarVisanet.Configuration.Response, "Ok");
                    dynamic json = JsonConvert.DeserializeObject(_configurarVisanet.Configuration.Response);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
