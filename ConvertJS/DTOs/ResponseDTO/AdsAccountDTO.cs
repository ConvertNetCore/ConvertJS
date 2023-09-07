using ConvertJS.Infras.Enums;

namespace ConvertJS.DTOs.ResponseDTO
{
    public class AdsAccountDTO
    {
        public string Status { get; set; }

        public string AccountName { get; set; }

        public string Id { get; set; }

        public double Balance { get; set; }

        public string Type { get; set; }

        public int ThreashHold { get; set; }

        public double Limit { get; set; }

        public double AmountSpent { get; set; }

        public string IDBM { get; set; }

        public int NumberUser { get; set; }

        public string Currency { get; set; }
        
        public List<UserDTO> Users { get; set; }
    }
}
