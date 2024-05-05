using Microsoft.EntityFrameworkCore;

namespace TransportMVC.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<User> Users {  get; set; }
        public DbSet<Destination> Destinations { get; set; } = default!;
        public DbSet<Package> Packages { get; set; } = default!;
        public DbSet<Booking> Bookings { get; set; } = default!;
        public DbSet<Coordinator> Coordinators { get; set; } = default!;
        public DbSet<Coupon> Coupons { get; set; } = default!;
        public DbSet<Notification> Notifications { get; set; } = default!;
        public DbSet<Review> Reviews { get; set; } = default!;
        public DbSet<WishForm> WishForms { get; set; } = default!;


        
    }
}
