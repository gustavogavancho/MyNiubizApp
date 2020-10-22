using System;
using System.Collections.Generic;
using System.Linq;
using Visanet.Controllers;
using Visanet.Models;

namespace MyNiubizApp.Services
{
    public class ConfigurarVisanet
    {
        public ConfigurationController Configuration { get; set; } = new ConfigurationController();

        public void SettearValores()
        {
            try
            {
                //Credenciales
                Configuration.Credential = new Credential();
                //Configuration.Credential.User = "integraciones.visanet@necomplus.com";
                //Configuration.Credential.Password = "d5e7nk$M";
                //Solo access tokey y keys

                //Environment
                Configuration.Environment = new Visanet.Models.Environment();
                Configuration.Environment.Protocol = "https://";
                Configuration.Environment.Host = "apitestenv.vnforapps.com/";

                var getResponse = ApiServices.AuthorizeCredential();

                Configuration.Security = new Security();
                Configuration.Security.keys = new List<Keys>();
                Configuration.Security.accessToken = $"{getResponse.accessToken}";
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

                //var getResponse2 = ApiServices.AuthorizeSession(341198214, Configuration.Security.accessToken);

                Configuration.Session = new Session();
                Configuration.Session.amount = 100.00;
                Configuration.Session.merchantId = "341198214";
                Configuration.Session.channel = "mobile";
                //Configuration.Session.sessionKey = getResponse2.sessionKey;
                //Configuration.Session.expirationTime = getResponse2.expirationTime.ToString();

                Configuration.Transaction = new Transaction();
                //Transaction
                Configuration.Transaction.order = new Order();
                Configuration.Transaction.channel = Configuration.Session.channel;
                Configuration.Transaction.order.purchaseNumber = "1016677700";
                Configuration.Transaction.order.currency = "PEN";
                Configuration.Transaction.customer = new Customer();
                Configuration.Transaction.customer.firstName = "Nombre";
                Configuration.Transaction.customer.lastName = "Apellido";
                Configuration.Transaction.customer.email = "mail@gmail.com";

                //User Interface
                Configuration.UserInterface = new UserInterface();
                Configuration.UserInterface.pageColor = "White";
                Configuration.UserInterface.entryBorderColor = System.Drawing.Color.LightGray;
                Configuration.UserInterface.logo = "logo.png";
                Configuration.UserInterface.logoHeight = 85;
                Configuration.UserInterface.logoWidth = 85;
                Configuration.UserInterface.logoTop = 40;
                Configuration.UserInterface.nombreEnable = true;
                Configuration.UserInterface.apellidoEnable = true;
                Configuration.UserInterface.correoEnable = true;
                Configuration.UserInterface.buttonPaymentAmount = true;
                Configuration.UserInterface.nombreComercio = "Swiftline";
                Configuration.UserInterface.buttonPaymentColor = "Black";
                Configuration.UserInterface.buttonPaymentTextColor = "White";
                Configuration.UserInterface.buttonPaymentText = "PAGAR ";
                Configuration.UserInterface.buttonPaymentAmountText += Configuration.Session.amount;
                Configuration.UserInterface.buttonPaymentTextComplete = $"{Configuration.UserInterface.buttonPaymentText} {Configuration.UserInterface.buttonPaymentAmountText}";

                Configuration.BillingAddress = new BillingAddress();
                Configuration.Ecommerce = new Ecommerce();
                Configuration.Ecommerce.antifraud = new AntiFraude();

                Configuration.Ecommerce.antifraud.merchantDefineData = new Dictionary<string, string>();
                Configuration.Ecommerce.antifraud.merchantDefineData.Add("MDD8", "TempMDD8");
                Configuration.Ecommerce.antifraud.merchantDefineData.Add("MDD50", "TempMDD50");
                Configuration.Ecommerce.antifraud.merchantDefineData.Add("MDD40", "TempMDD40");
                Configuration.Ecommerce.antifraud.merchantDefineData.Add("MDD20", "TempMDD20");

                Configuration.Ecommerce.cardHolder = new CardHolder();
                Configuration.Transaction.card = new Card();

                Configuration.Transaction.card.verify = 0;
                Configuration.Transaction.card.alias = "";
                Configuration.Transaction.card.tokenId = "";
                Configuration.Transaction.card.alias = "";

                Configuration.Transaction.customer = new Customer();
                Configuration.Transaction.customer.phoneNumber = "";
                Configuration.Transaction.customer.documentType = 0;
                Configuration.Transaction.customer.documentNumber = "";

                Configuration.Transaction.alias = new Alias();
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

                Configuration.BackendPublicKey = "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
