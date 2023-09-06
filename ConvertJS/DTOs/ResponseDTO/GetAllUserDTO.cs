using ConvertJS.Infras.Enums;

namespace ConvertJS.DTOs.ResponseDTO
{
    public class GetAllUserDTO
    {
        public AccountStatus Status { get; set; }

        public string AccountName { get; set; }

        public string Id { get; set; }

        public decimal Balance { get; set; }

        public TypeAccount Type { get; set; }

        public int ThreashHold { get; set; }

        public decimal limit { get; set; }

        public decimal AmountSpent { get; set; }

        public string IDBM { get; set; }

        public int NumberUser { get; set; }

        public string Currency { get; set; }
        
        public List<UserDTO> UserDTOs { get; set; }
    }
}
