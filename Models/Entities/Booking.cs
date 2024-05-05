using System;
using System.ComponentModel.DataAnnotations;

public enum BookingState
{
    Pending,
    Confirmed,
    Cancelled
}

public class Booking 
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Associated package is required")]
    public Package AssociatedPackage { get; set; }

    [Required(ErrorMessage = "State is required")]
    public BookingState State { get; set; }

    [Required(ErrorMessage = "Number of travellers is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Number of travellers must be at least 1")]
    public int NumberOfTravellers { get; set; }

    [Required]
    public DateTime BookingDate { get; set; }

    [Required]
    public bool IsPaid { get; set; }

    [Required(ErrorMessage = "Payment method is required")]
    public string PaymentMethod { get; set; }

    [Required]
    public User Owner { get; set; }


    [Required]
    public User LastModifiedBy { get; set; }

    [Required]
    public DateTime LastModifiedAt { get; set; }

    public Booking()
    {
        Id = Guid.NewGuid();
        BookingDate = DateTime.UtcNow;
        LastModifiedAt = BookingDate;
        State = BookingState.Pending;
    }
}
