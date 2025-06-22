using ApiParking.Models;

namespace ApiParking.DTOs.User
{
    public class CreateUserDTO 
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int PasswordHash { get; set; }
        public UserRole Role { get; set; }
    }
}
