using MyNiubizApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyNiubizApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreditCardPage : ContentPage
    {
        CreditCardPageViewModel _viewModel;
        public CreditCardPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CreditCardPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (App.configuration.Response != null)
            {
                DisplayAlert("Response", App.configuration.Response, "Ok");
            }
            else
            {
                DisplayAlert("Reponse", "Not ok", "Ok");
            }
        }
    }
}