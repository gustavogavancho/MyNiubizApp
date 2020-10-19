using MyNiubizApp.Models;
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
    }
}
