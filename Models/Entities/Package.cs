using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public enum Category {
    BEACH,
    CITY,
    ADVENTURE,
    ROMANTIC,
    FAMILY,
    LUXURY,
    CRUISE
};

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

    [Required(ErrorMessage = "Name is required")]
    [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Start Date is required")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "Budget is required")]
    public decimal Budget { get; set; }

    [Required(ErrorMessage = "Duration is required")]
    [RegularExpression(@"^\d+\s+(month(s)?|day(s)?)$", ErrorMessage = "Duration must start with digits followed by 'month(s)' or 'day(s)'")]
    [MaxLength(50)]
    public string Duration { get; set; }

    public string? Services { get; set; }

    [Required(ErrorMessage = "Transport option is required")]
    public TransportOption TransportOption { get; set; }

    [Required(ErrorMessage = "Transport company is required")]
    public string TransportCompany { get; set; }

    [Required(ErrorMessage = "Category is required")]
    public Category Category { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime LastModifiedAt { get; set; }

    public List<Booking>? Bookings { get; set; }

    public List<Review>? Reviews { get; set; }

    public User? LastModifiedBy { get; set; }

    public User? CreatedBy { get; set; }

    public Guid DestinationId { get; set; }

    public Destination? Destination { get; set; }

    public List<Coupon> Coupons { get; set; } 

    public Coordinator? Coordinator { get; set; }

    [ForeignKey("ReceiverId")]
    public Guid? CoordinatorId { get; set; }

    public Package()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        LastModifiedAt = CreatedAt;
        Coupons = new List<Coupon>(); 
    }
}