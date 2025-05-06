namespace Package_Api.Models.Login
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // Hashed!!
        public string Email { get; set; }
        public UserRole Role { get; set; } 
    }
}
