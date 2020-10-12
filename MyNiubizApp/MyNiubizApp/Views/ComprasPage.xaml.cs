using MyNiubizApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyNiubizApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComprasPage : ContentPage
    {
        ComprasViewModel _viewModel;
        public ComprasPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ComprasViewModel();
        }
    }
}