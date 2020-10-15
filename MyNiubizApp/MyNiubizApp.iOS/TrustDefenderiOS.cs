using System;

using Foundation;
using MyNiubizApp.iOS;
using TrustDefenderiOS;
using Visanet;

[assembly: Xamarin.Forms.Dependency(typeof(TrustDefenderIos))]
namespace MyNiubizApp.iOS
{
    public class TrustDefenderIos : ITrustDefender
    {
        int count = 1;
        THMTrustDefender profile;
        String CSOrgIDProd = "k8vif92e";
        String session = "28308866ed2094f901f972694d2774aca2d3ff2b102617e3d122e2b9724f0df5";
        THMProfileHandle p;
        public void InitProfiling(string token)
        {
            profile = THMTrustDefender.SharedInstance();
            var configKeys = new[]
               {
                    Constants.THMOrgID
                };

            var configObjects = new NSObject[]
            {
                    new NSString(CSOrgIDProd)
            };


            var config = new NSDictionary<NSString, NSObject>(configKeys, configObjects);
            var profileKeys = new[]
            {
                    Constants.THMSessionID
                };

            var profileObjects = new NSObject[]
            {
                    new NSString(token)
            };
            profile.Configure(config: config);
            var profileRequest = new NSDictionary<NSString, NSObject>(profileKeys, profileObjects);
            p = profile.DoProfileRequest(profileRequest);
            System.Console.WriteLine("session");
            System.Console.WriteLine(p.SessionID);
        }

        public string response()
        {
            return p.SessionID;
        }
    }
}