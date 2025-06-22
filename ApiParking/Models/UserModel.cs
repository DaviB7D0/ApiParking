namespace ApiParking.Models
{
    public class UserModel
    {
        
         public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }

        public int PasswordHash { get; set; }

        public UserRole Role{ get; set; }
    }
    public enum UserRole
    {
        Admin = 1,
        VehicleRegistrars= 2

    }
}
