using ConvertJS.Infras.Enums;

namespace ConvertJS.DTOs.ResponseDTO
{
    public class AppealCheckPageDTO
    {
        public string Id { get; set; }
        public PageStatus Status { get; set; }
        public string PageName { get; set; }
    }
}
