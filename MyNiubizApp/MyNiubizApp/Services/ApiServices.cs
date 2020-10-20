using MyNiubizApp.Models;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyNiubizApp.Services
{
    public class ApiServices
    {
        public static CredentialResponseModel AuthorizeCredential()
        {
            string url = String.Format("https://apitestenv.vnforapps.com/api.security/v2/security/keys");
            HttpWebRequest requestObj = (HttpWebRequest)WebRequest.Create(url);
            requestObj.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("integraciones.visanet@necomplus.com:d5e7nk$M"));
            HttpWebResponse responseObj = null;
            responseObj =  (HttpWebResponse)requestObj.GetResponse();
            string strresult = null;

            using (Stream stream = responseObj.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                strresult = sr.ReadToEnd();
                sr.Close();
            }

            var splashInfo = JsonConvert.DeserializeObject<CredentialResponseModel>(strresult);
            return splashInfo;
        }

        public static SessionResponseModel AuthorizeSession(long merchantId, string accessToken)
        {
            string url = $"https://apitestenv.vnforapps.com/api.ecommerce/v2/ecommerce/token/session/{merchantId}";
            HttpWebRequest requestObj = (HttpWebRequest)WebRequest.Create(url);
            requestObj.Headers["Authorization"] = accessToken;
            SessionRequestModel model = new SessionRequestModel
            {
                channel = "web",
                amount = 1005,
                antifraud = new Antifraud
                {
                    clientIp = "24.252.107.29",
                    merchantDefineData = new MerchantDefineData
                    {
                        MDD15 = "Valor MDD 15",
                        MDD20 = "Valor MDD 20",
                        MDD33 = "Valor MDD 33",
                    }
                }
            };
            string json = JsonConvert.SerializeObject(model);
            requestObj.Method = "POST";
            requestObj.ContentType = "application/json; charset=utf-8";

            using (var streamWriter = new StreamWriter(requestObj.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            HttpWebResponse responseObj = null;
            responseObj = (HttpWebResponse)requestObj.GetResponse();
            string strresult = null;

            using (Stream stream = responseObj.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                strresult = sr.ReadToEnd();
                sr.Close();
            }

            var splashInfo = JsonConvert.DeserializeObject<SessionResponseModel>(strresult);
            return splashInfo;
        }
    }
}
