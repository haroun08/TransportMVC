using System;
using System.ComponentModel.DataAnnotations;

public class Review
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Associated Package is required")]
    public Package AssociatedPackage { get; set; }

    [Required]
    public User User { get; set; }

    [MaxLength(1000, ErrorMessage = "Text cannot exceed 1000 characters")]
    public string? Text { get; set; }

    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
    public int Rating { get; set; }

    [Required]
    public DateTime Date { get; set; }

    public Review()
    {
        Id = Guid.NewGuid();
        Date = DateTime.UtcNow;
    }
}