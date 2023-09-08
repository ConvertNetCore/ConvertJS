using ConvertJS.Infras.Enums;
using System.Security;

namespace ConvertJS.DTOs.ResponseDTO
{
    public class BusinessDTO
    {
        public BMStatus Status { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Role { get; set; }

        public string Limit { get; set; }

        public string Verified { get; set; }

        public DateTime Created { get; set; }

        public string IDBM { get; set; }

        public int NumberAdmin { get; set; }

        public int HiddenAdmin { get; set; }

        public int NumberPixel { get; set; }

        public int NumberAccount { get; set; }

        public string Quantity { get; set; }

        public List<UserDTO> Admins {get;set;}
        public List<UserDTO> Accounts { get; set; }
        public List<BMPixel> Pixels { get; set; }
    }
    public class BMPixel
    {
    }
}
