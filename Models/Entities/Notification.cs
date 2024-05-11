using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Notification
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Receiver is required")]
    [ForeignKey("ReceiverId")]
    public string ReceiverId { get; set; }  

    [Required(ErrorMessage = "Content is required")]
    [MaxLength(250, ErrorMessage = "Description cannot exceed 250 characters")]
    public string Content { get; set; }

    [Required(ErrorMessage = "Sent date is required")]
    public DateTime SentDate { get; set; }

    [Required(ErrorMessage = "Last modified date is required")]
    public DateTime LastModifiedAt { get; set; }

    public User? Receiver { get; set; }
    public User? CreatedBy { get; set; }
    public User? LastModifiedBy { get; set; }

    public Notification()
    {
        Id = Guid.NewGuid();
        SentDate = DateTime.UtcNow;
        LastModifiedAt = SentDate;
    }
}
