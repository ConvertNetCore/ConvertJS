namespace ConvertJS.DTOs.ResponseDTO
{
    public class CampaignsDTO
    {
        public string Id { get; set; }
        public bool Status { get; set; }
        public string Delivery { get; set; }
        public string BidStrategy { get; set; }
        public string Budget { get; set; }
        public DateTime LastSignificantEdut { get; set; }
        public string Result { get; set; }
        public int Reach { get; set; }
        public double Frequency { get; set; }
        public int Impressions { get; set; }
        public double AmountSpent { get; set; }
        public string Currency { get; set; }
        public int Clicks { get; set; }
        public string Value { get; set; }
    }
}
