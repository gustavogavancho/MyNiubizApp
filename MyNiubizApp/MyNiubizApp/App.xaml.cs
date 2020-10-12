using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyNiubizApp.Views;
using Visanet.Controllers;

namespace MyNiubizApp
{
    public partial class App : Application
    {
        public static ConfigurationController configuration = new ConfigurationController();
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();

            //Environment
            configuration.Environment.Protocol = "https://";
            configuration.Environment.Host = "apitestenv.vnforapps.com/";

            //Session
            configuration.Session.amount = 10;
            configuration.Session.merchantId = "341198210";

            //Credentials
            configuration.Credential.User = "integraciones.visanet@necomplus.com";
            configuration.Credential.Password = "d5e7nk$M";

            //SSL Certificate
            configuration.BackendPublicKey = "";

            //Secutiry
            configuration.Security.accessToken = "aprcZ2lhbmNhZ2FsbGFyZG9AZ21haWwuY29tOkF2MyR0cnV6";

            //Antifraud
            configuration.Ecommerce.antifraud.merchantDefineData.Add("MDD8", "TempMDD8");
            configuration.Ecommerce.antifraud.merchantDefineData.Add("MDD50", "TempMDD50");
            configuration.Ecommerce.antifraud.merchantDefineData.Add("MDD40", "TempMDD40");
            configuration.Ecommerce.antifraud.merchantDefineData.Add("MDD20", "TempMDD20"); 
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
