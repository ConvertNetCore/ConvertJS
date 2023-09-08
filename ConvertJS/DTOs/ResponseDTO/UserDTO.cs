using ConvertJS.Infras.Enums;

namespace ConvertJS.DTOs.ResponseDTO
{
    public class UserDTO
    {
        public Role Role { get; set; }
        
        public string Name { get; set; }

        public string UserId { get; set; }
    }
}
