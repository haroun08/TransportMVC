using System.ComponentModel.DataAnnotations;

public class Notification
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public User User { get; set; }

    [Required(ErrorMessage = "Content is required")]
    [MaxLength(250, ErrorMessage = "Description cannot exceed 250 characters")]
    public string Content { get; set; }

    [Required]
    public DateTime SentDate { get; set; }

    public Notification()
    {
        Id = Guid.NewGuid();
        SentDate = DateTime.UtcNow;
    }
}
