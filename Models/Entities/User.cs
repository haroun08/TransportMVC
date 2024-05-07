using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

public class User : IdentityUser
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public override string Email { get; set; }

    [Required(ErrorMessage = "Created at date is required")]
    public DateTime CreatedAt { get; set; }

    [Required(ErrorMessage = "Last modified at date is required")]
    public DateTime LastModifiedAt { get; set; }

    public List<Review>? Reviews { get; set; }
    public List<Review>? ModifiedReviews { get; set; }

    public List<Notification>? ReceivedNotifications { get; set; }
    public List<Notification>? SentNotifications { get; set; }
    public List<Notification>? ModifiedNotifications { get; set; }
    

    public List<Booking>? Bookings { get; set; }
    public List<Booking>? ModifiedBookings { get; set; }

    public List<Package>? Packages { get; set; }
    public List<Package>? ModifiedPackages { get; set; }

    public List<Destination>? Destinations { get; set; }
    public List<Destination>? ModifiedDestinations { get; set; }

    public List<Coupon>? Coupons { get; set; }
    public List<Coupon>? ModifiedCoupons { get; set; }

    

    public User()
    {
        CreatedAt = DateTime.UtcNow;
        LastModifiedAt = DateTime.UtcNow;
    }
}
