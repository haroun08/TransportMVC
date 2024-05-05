using System.ComponentModel.DataAnnotations;

public enum TransportOption
{
    Airplane,
    Train,
    Bus,
    Car,
    Ship
}

public class Package
{
    [Key]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Destination is required")]
    public Destination Destination { get; set; }
    
    [Required(ErrorMessage = "Start Date is required")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    
    [Required(ErrorMessage = "Budget is required")]
    public decimal Budget { get; set; }
    
    [Required(ErrorMessage = "Duration is required")]
    [RegularExpression(@"^\d+\s+(month(s)?|day(s)?)$", ErrorMessage = "Duration must start with digits followed by 'month(s)' or 'day(s)'")]
    [MaxLength(50)]
    public string Duration { get; set; }
    
    public List<string>? Services { get; set; }
    
    [Required(ErrorMessage = "Transport option is required")]
    public TransportOption TransportOption { get; set; }
    
    [Required(ErrorMessage = "Transport company is required")]
    public string TransportCompany { get; set; }
    
    [Required(ErrorMessage = "Category is required")]
    public string Category { get; set; }
    
    
    public User CreatedBy { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; }
    
    
    public User LastModifiedBy { get; set; }
    
    [Required]
    public DateTime LastModifiedAt { get; set; }

    public Package()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        LastModifiedAt = CreatedAt;
    }
}
