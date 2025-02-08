namespace dotnet_authentication.Models;

public class UserWithRoles
{
    public User User { get; set; }
    public List<string> Roles { get; set; }
}