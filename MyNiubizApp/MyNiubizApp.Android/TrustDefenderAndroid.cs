using Android.App;
using MyNiubizApp.Droid;
using Threatmetrix.TrustDefender;
using Visanet;

[assembly: Xamarin.Forms.Dependency(typeof(TrustDefenderAndroid))]
namespace MyNiubizApp.Droid
{
    public class TrustDefenderAndroid : Java.Lang.Object, IEndNotifier, ITrustDefender
    {

        public int CYBERSOURCE_TIMEOUT = 3000;

        public string CYBERSOURCE_ORGID_TEST = "1snn5n9w";

        public string CYBERSOURCE_ORGID_PROD = "k8vif92e";
        private readonly bool isTesting = true;

        string result;


        public void InitProfiling(string token)
        {
            Config config = new Config()
                  .SetTimeout(CYBERSOURCE_TIMEOUT, Java.Util.Concurrent.TimeUnit.Seconds)
                  .SetRegisterForLocationServices(false)
                  .SetContext(Application.Context)
                  .SetOrgId(isTesting ? CYBERSOURCE_ORGID_TEST : CYBERSOURCE_ORGID_PROD);
            TrustDefenderMain profile = TrustDefenderMain.Instance;
            profile.Init(config);
            ProfilingOptions options = new ProfilingOptions().SetSessionID(token);
            profile.DoProfileRequest(options, this);
        }

        public void Complete(Profile.Result result)
        {

            //   statusText.Text = result.Status.Desc;
            if (result.Status == THMStatusCode.ThmOk)
            {
                this.result = (string)result.SessionID;

            }
            else
            {
                this.result = null;

            }
            Android.Util.Log.Debug("TrustDefender Status", (string)result.Status);
            Android.Util.Log.Debug("TrustDefender SessionID", (string)result.SessionID);
        }
    }
}