using System.ComponentModel.DataAnnotations;

public enum UserRole
{
    Admin,
    User
}

public class User
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "User name is required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }

    [Phone(ErrorMessage = "Invalid phone number")]
    public string Phone { get; set; }

    public UserRole Role { get; set; } 

    [Required]
    public DateTime CreatedAt { get; set; } 

    [Required]
    public DateTime LastModifiedAt { get; set; }

    public User()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        LastModifiedAt = CreatedAt;
        Role = UserRole.User;
    }
}
