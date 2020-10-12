using System;
using System.Collections.Generic;
using MyNiubizApp.ViewModels;
using MyNiubizApp.Views;
using Xamarin.Forms;

namespace MyNiubizApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CreditCardPage), typeof(CreditCardPage));
        }

    }
}
