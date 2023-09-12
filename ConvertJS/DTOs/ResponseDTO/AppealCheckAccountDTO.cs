using ConvertJS.Infras.Enums;

namespace ConvertJS.DTOs.ResponseDTO
{
    public class AppealCheckAccountDTO
    {
        public string ID { get; set; }
        public AccountStatus Status { get; set; }
        public string AccountName { get; set; }
    }
}
