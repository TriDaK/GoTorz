namespace Package_Api.Models.Login
{
    // This is a sort of DTO for login requests
    // Used specifically for the login process
    sealed public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
