using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

public class User : IdentityUser
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public override string Email { get; set; }

    [Required(ErrorMessage = "Created at date is required")]
    public DateTime CreatedAt { get; set; }

    [Required(ErrorMessage = "Last modified at date is required")]
    public DateTime LastModifiedAt { get; set; }

    public User()
    {
        CreatedAt = DateTime.UtcNow;
        LastModifiedAt = DateTime.UtcNow;
    }
}
