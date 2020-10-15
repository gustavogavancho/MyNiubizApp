using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyNiubizApp.Views;
using Visanet.Controllers;
using Visanet.Views;
using System.Globalization;

[assembly: ExportFont("Montserrat-Regular.ttf")]
namespace MyNiubizApp
{
    public partial class App : Application
    {
        public static ConfigurationController configuration;
        public App()
        {
            try
            {
                configuration = new ConfigurationController();
                 InitializeComponent();
                //MainPage = new AppShell();

                //Environment
                configuration.Environment.Protocol = "https://";
                configuration.Environment.Host = "apitestenv.vnforapps.com/";

                //Session
                configuration.Session.amount = 1000;
                configuration.Session.merchantId = "341198210";

                //Transaction
                configuration.Transaction.order.purchaseNumber = "1016677700";
                configuration.Transaction.customer.firstName = "Nombre";
                configuration.Transaction.customer.lastName = "Apellido";
                configuration.Transaction.customer.email = "mail@gmail.com";     
                
                //User Interface
                configuration.UserInterface.pageColor = "White";
                configuration.UserInterface.entryBorderColor = System.Drawing.Color.LightGray;
                configuration.UserInterface.logo = "logo.png";
                configuration.UserInterface.logoHeight = 85;
                configuration.UserInterface.logoWidth = 85;
                configuration.UserInterface.logoTop = 40;
                configuration.UserInterface.nombreEnable = true;
                configuration.UserInterface.apellidoEnable = true;
                configuration.UserInterface.correoEnable = true;
                configuration.UserInterface.pageColor = "White";
                configuration.UserInterface.buttonPaymentAmountCurrency = "PEN";
                configuration.UserInterface.buttonPaymentAmount = true;
                configuration.UserInterface.nombreComercio = "Ripley";
                configuration.UserInterface.buttonPaymentColor = "Blue"; 
                configuration.UserInterface.buttonPaymentTextColor = "White"; 
                configuration.UserInterface.buttonPaymentText = "PAGAR "; 
                configuration.UserInterface.buttonPaymentAmountText += configuration.Session.amount.ToString("c");
                configuration.UserInterface.buttonPaymentTextComplete = $"{configuration.UserInterface.buttonPaymentText} {configuration.UserInterface.buttonPaymentAmountText}";


                //Config varios
                configuration.AntiFraude.clientIp = "10.0.2.15";//quitar           
                configuration.Session.antifraud = configuration.AntiFraude;//quitar           
                configuration.Transaction.channel = configuration.Session.channel;//quitar
                configuration.Transaction.clientIp = configuration.AntiFraude.clientIp;//quitar
                configuration.Transaction.order.productId = "";//quitar
                configuration.Transaction.order.currency = "PEN";//quitar se setea de un api
                configuration.Transaction.order.installment = "0";//quitar
                configuration.BillingAddress.city = "Mountain View";//quitar
                configuration.BillingAddress.country = "US";//quitar
                configuration.BillingAddress.postalCode = "94043";//quitar
                configuration.BillingAddress.state = "CA";//quitar
                configuration.BillingAddress.street1 = "1295 Charleston Road";
                configuration.AntiFraude.billingAddress = configuration.BillingAddress;//quitar
                configuration.Transaction.order.billingAddress =
                configuration.BillingAddress;//quitar
                configuration.Transaction.card.verify = 0;
                configuration.Transaction.card.alias = "";
                configuration.Transaction.card.tokenId = "";
                configuration.Transaction.card.alias = "";
                configuration.Transaction.customer.phoneNumber = "";
                configuration.Transaction.customer.documentType = 0;
                configuration.Transaction.customer.documentNumber = "";
                configuration.Transaction.alias.aliasId = "";
                configuration.Transaction.alias.aliasName = "";
                configuration.Transaction.alias.cvv2 = "123";
                configuration.Transaction.alias.requestCVV2 = 1;
                configuration.Transaction.alias.userToken = "mail@hotmail.com";
                configuration.Ecommerce.terminalId = "1";
                configuration.Ecommerce.channel = configuration.Session.channel;
                configuration.Ecommerce.terminalUnattended = 0;
                configuration.Ecommerce.captureType = "manual";
                configuration.Ecommerce.countable = 1;
                configuration.Ecommerce.antifraud = configuration.AntiFraude;
                configuration.Ecommerce.order = configuration.Transaction.order;
                configuration.Ecommerce.cardHolder.documentNumber = "";
                configuration.Ecommerce.cardHolder.documentType = 0;
                configuration.Security.accessToken = "eZ2lhbmNhZ2FsebGFyZG9AZ2e1haWwuY29tOkF2fMyR0cnV6";

                MainPage = new NavigationPage(new FormCreditCard(configuration));
            }
            catch (Exception ex)
            {
                throw ex;
            }

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
