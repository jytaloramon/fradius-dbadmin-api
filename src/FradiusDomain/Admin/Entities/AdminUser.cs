namespace FradiusDomain.Admin.Entities;

public class AdminUser
{
    public int Id { get; set; }

    public string FirstName { get; set; } = "";

    public string LastName { get; set; } = "";

    public string Username { get; set; } = "";

    public string Email { get; set; } = "";

    public string Password { get; set; } = "";

    public string? ProfileImage { get; set; }
    
    public DateTime CreateAt { get; set; }
    
    public DateTime UpdateAt { get; set; }
    
    public bool IsActive { get; set; }
}