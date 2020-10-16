using Visanet.Controllers;
using Visanet.Models;

namespace MyNiubizApp.Services
{
    public class ConfigurarVisanet
    {
        public ConfigurationController Configuration { get; set; } = new ConfigurationController();

        public void SettearValores()
        {
            //Credenciales
            //Configuration.Credential.User = "integraciones.visanet@necomplus.com";
            //Configuration.Credential.Password = "d5e7nk$M";
            //Solo access tokey y keys

            //Environment
            //Configuration.Environment.Protocol = "https://";
            //Configuration.Environment.Host = "apitestenv.vnforapps.com/";

            //Session
            Configuration.Session.amount = 1000;
            Configuration.Session.merchantId = "341198210";

            //Transaction
            Configuration.Transaction.order.purchaseNumber = "1016677700";
            Configuration.Transaction.customer.firstName = "Nombre";
            Configuration.Transaction.customer.lastName = "Apellido";
            Configuration.Transaction.customer.email = "mail@gmail.com";

            //User Interface
            Configuration.UserInterface.pageColor = "White";
            Configuration.UserInterface.entryBorderColor = System.Drawing.Color.LightGray;
            Configuration.UserInterface.logo = "logo.png";
            Configuration.UserInterface.logoHeight = 85;
            Configuration.UserInterface.logoWidth = 85;
            Configuration.UserInterface.logoTop = 40;
            Configuration.UserInterface.nombreEnable = true;
            Configuration.UserInterface.apellidoEnable = true;
            Configuration.UserInterface.correoEnable = true;
            Configuration.UserInterface.pageColor = "White";
            Configuration.UserInterface.buttonPaymentAmountCurrency = "PEN";
            Configuration.UserInterface.buttonPaymentAmount = true;
            Configuration.UserInterface.nombreComercio = "Ripley";
            Configuration.UserInterface.buttonPaymentColor = "Blue";
            Configuration.UserInterface.buttonPaymentTextColor = "White";
            Configuration.UserInterface.buttonPaymentText = "PAGAR ";
            Configuration.UserInterface.buttonPaymentAmountText += Configuration.Session.amount.ToString("c");
            Configuration.UserInterface.buttonPaymentTextComplete = $"{Configuration.UserInterface.buttonPaymentText} {Configuration.UserInterface.buttonPaymentAmountText}";

            //Config varios
            Configuration.AntiFraude.clientIp = "10.0.2.15";//quitar           
            Configuration.Session.antifraud = Configuration.AntiFraude;//quitar           
            Configuration.Transaction.channel = Configuration.Session.channel;//quitar
            Configuration.Transaction.clientIp = Configuration.AntiFraude.clientIp;//quitar
            Configuration.Transaction.order.productId = "";//quitar
            Configuration.Transaction.order.currency = "PEN";//quitar se setea de un api
            Configuration.Transaction.order.installment = "0";//quitar
            Configuration.BillingAddress.city = "Mountain View";//quitar
            Configuration.BillingAddress.country = "US";//quitar
            Configuration.BillingAddress.postalCode = "94043";//quitar
            Configuration.BillingAddress.state = "CA";//quitar
            Configuration.BillingAddress.street1 = "1295 Charleston Road";
            Configuration.AntiFraude.billingAddress = Configuration.BillingAddress;//quitar
            Configuration.Transaction.order.billingAddress =
            Configuration.BillingAddress;//quitar
            Configuration.Transaction.card.verify = 0;
            Configuration.Transaction.card.alias = "";
            Configuration.Transaction.card.tokenId = "";
            Configuration.Transaction.card.alias = "";
            Configuration.Transaction.customer.phoneNumber = "";
            Configuration.Transaction.customer.documentType = 0;
            Configuration.Transaction.customer.documentNumber = "";
            Configuration.Transaction.alias.aliasId = "";
            Configuration.Transaction.alias.aliasName = "";
            Configuration.Transaction.alias.cvv2 = "123";
            Configuration.Transaction.alias.requestCVV2 = 1;
            Configuration.Transaction.alias.userToken = "mail@hotmail.com";
            Configuration.Ecommerce.terminalId = "1";
            Configuration.Ecommerce.channel = Configuration.Session.channel;
            Configuration.Ecommerce.terminalUnattended = 0;
            Configuration.Ecommerce.captureType = "manual";
            Configuration.Ecommerce.countable = 1;
            Configuration.Ecommerce.antifraud = Configuration.AntiFraude;
            Configuration.Ecommerce.order = Configuration.Transaction.order;
            Configuration.Ecommerce.cardHolder.documentNumber = "";
            Configuration.Ecommerce.cardHolder.documentType = 0;

            var getResponse = ApiServices.AuthorizeCredential();
            Configuration.Security.accessToken = getResponse.accessToken;
            foreach (var item in getResponse.keys)
            {
                Keys key = new Keys
                {
                    token = item.token,
                    baseKey = item.baseKey,
                    iv = item.iv,
                };
                Configuration.Security.keys.Add(key);
            }
        }
    }
}
