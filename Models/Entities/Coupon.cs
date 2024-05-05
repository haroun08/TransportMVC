using System.ComponentModel.DataAnnotations;

public class Coupon
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Code is required")]
    public string Code { get; set; }

    [Required(ErrorMessage = "Discount amount is required")]
    [Range(0, double.MaxValue, ErrorMessage = "Discount amount must be a positive number")]
    public decimal DiscountAmount { get; set; }

    [Required(ErrorMessage = "Expiration date is required")]
    public DateTime ExpirationDate { get; set; }

    public List<Package>? ApplicablePackages { get; set; }

    public DateTime CreatedAt { get; set; }

    public Coupon()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }
}