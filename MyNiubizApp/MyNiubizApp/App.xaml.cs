using Xamarin.Forms;
using Visanet.Controllers;
using System.Net.Http;
using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using MyNiubizApp.Models;

[assembly: ExportFont("Montserrat-Regular.ttf")]
namespace MyNiubizApp
{
    public partial class App : Application
    {
        public static ConfigurationController configuration;
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
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
