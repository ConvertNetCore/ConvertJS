using ConvertJS.Infras.Enums;

namespace ConvertJS.DTOs.ResponseDTO
{
    public class AppealCheckBMDTO
    {
        public string Id { get; set; }
        public BMStatus Status { get; set; }
        public string BMName { get; set; }
    }
}
