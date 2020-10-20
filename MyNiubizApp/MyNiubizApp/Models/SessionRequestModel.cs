namespace MyNiubizApp.Models
{
    public class SessionRequestModel
    {
        public string channel { get; set; }
        public int amount { get; set; }
        public Antifraud antifraud { get; set; }
    }

    public class MerchantDefineData
    {
        public string MDD15 { get; set; }
        public string MDD20 { get; set; }
        public string MDD33 { get; set; }
    }

    public class Antifraud
    {
        public string clientIp { get; set; }
        public MerchantDefineData merchantDefineData { get; set; }
    }
}
