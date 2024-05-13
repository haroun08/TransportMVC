using System;
using System.ComponentModel.DataAnnotations;

public enum BookingState
{
    Pending,
    Confirmed,
    Cancelled
}

public enum PaymentMethod
{
    Cash,
    CreditCard,
    PayPal,
    BankTransfer
    
}

public class Booking 
{
    [Key]
    public Guid Id { get; set; }

    public Package? AssociatedPackage { get; set; }

    [Required(ErrorMessage = "Associated package is required")]
    public Guid AssociatedPackageId { get; set; }

    [Required(ErrorMessage = "State is required")]
    public BookingState State { get; set; }

    [Required(ErrorMessage = "Number of travellers is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Number of travellers must be at least 1")]
    public int NumberOfTravellers { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public bool IsPaid { get; set; }

    [Required(ErrorMessage = "Payment method is required")]
    public PaymentMethod PaymentMethod { get; set; }

    [Required]
    public DateTime LastModifiedAt { get; set; }

    public User? CreatedBy { get; set; }

    public User? LastModifiedBy { get; set; }

    public string? CouponCode { get; set; }

    public decimal? TotalAmount { get; set; } 

    public Booking()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        LastModifiedAt = CreatedAt;
        State = BookingState.Pending;
    }
}
