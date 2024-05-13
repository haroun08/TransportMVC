using System;
using System.ComponentModel.DataAnnotations;

public class WishForm
{
    [Key]
    public Guid Id { get; set; }

    public string? Destination { get; set; }

    [DataType(DataType.Date)]
    public DateTime? DepartureDate { get; set; }

    [RegularExpression(@"^\d+\s+(month(s)?|day(s)?)$", ErrorMessage = "Duration must start with digits followed by 'month(s)' or 'day(s)'")]
    [MaxLength(50)]
    public string? Duration { get; set; }

    public decimal? Budget { get; set; }

    public string? Interests { get; set; }

    public string? AdditionalNotes { get; set; }

    [Required]
    public DateTime SubmissionDate { get; set; }

    [Required(ErrorMessage = "Category is required")]
    public Category Category { get; set; }

    public User? CreatedBy { get; set; }

    
    public WishForm()
    {
        Id = Guid.NewGuid();
        SubmissionDate = DateTime.UtcNow;
    }
}
