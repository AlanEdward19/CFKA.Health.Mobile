namespace MyCheddarsPal.Models;

public class UserResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int UserType { get; set; }
    public UserResponse? Trainer { get; set; }
}