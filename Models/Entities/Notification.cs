using System.ComponentModel.DataAnnotations;

public class Notification
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public User Receiver { get; set; }

    public User CreatedBy { get; set; }

     public User LastModifiedBy { get; set; }

    [Required(ErrorMessage = "Content is required")]
    [MaxLength(250, ErrorMessage = "Description cannot exceed 250 characters")]
    public string Content { get; set; }

    [Required]
    public DateTime SentDate { get; set; }

    [Required]
    public DateTime LastModifiedAt { get; set; }

    public Notification()
    {
        Id = Guid.NewGuid();
        SentDate = DateTime.UtcNow;
        LastModifiedAt = SentDate;
    }
}
