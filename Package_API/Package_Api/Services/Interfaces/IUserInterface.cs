namespace Package_Api.Services.Interfaces
{
    public interface IUserService
    {
        User ValidateUser(string username, string password);  // Method to validate user credentials
    }
}
