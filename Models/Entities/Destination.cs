using System;
using System.ComponentModel.DataAnnotations;

public class Destination
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    public string Name { get; set; }

    [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
    public string Description { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public User? CreatedBy { get; set; }

    public User? LastModifiedBy { get; set; }

    [Required]
    public DateTime LastModifiedAt { get; set; }

    public string ImageUrl { get; set; }

     public List<Package>? Packages { get; set; }



    public Destination()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        LastModifiedAt = CreatedAt;
        // Generate a random number between 64 and 166
        Random random = new Random();
        int randomNumber = random.Next(64, 166);
        // Construct the image URL with the random number
       ImageUrl = $"https://picsum.photos/id/{randomNumber}/450/550";

    }
    
}
