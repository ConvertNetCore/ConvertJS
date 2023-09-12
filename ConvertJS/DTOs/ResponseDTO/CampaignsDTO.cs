using ConvertJS.Infras.Enums;

namespace ConvertJS.DTOs.ResponseDTO
{
    public class CampaignsDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Delivery { get; set; }
        public string BidStrategy { get; set; }
        public string Budget { get; set; }
        public DateTime LastSignificantEdut { get; set; }
        public string Result { get; set; }
        public string Reach { get; set; }
        public string Frequency { get; set; }
        public string Impressions { get; set; }
        public string AmountSpent { get; set; }
        public string Currency { get; set; }
        public string Clicks { get; set; }
        public string Value { get; set; }
    }
}
