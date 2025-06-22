using ApiParking.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiParking.DTOs.User
{
    public class CreateUserDTO 
    {
        [Required(ErrorMessage= "Please fill out all required fields.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please fill out all required fields.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please fill out all required fields.")]
        public string PasswordHash { get; set; }
        [Required(ErrorMessage = "Please fill out all required fields.")]
        public UserRole Role { get; set; }
    }
}
