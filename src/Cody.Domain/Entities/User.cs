namespace Cody.Domain.Entities;

public class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string PasswordHash { get; set; }
    public long RoleId { get; set; }

    //public Role Role { get; set; }
}