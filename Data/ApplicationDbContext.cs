using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TransportMVC.Data
{
    public class ApplicationDbContext: IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Review configurations
        modelBuilder.Entity<Review>()
            .HasOne(r => r.AssociatedPackage)
            .WithMany(p => p.Reviews)
            .IsRequired();

        modelBuilder.Entity<Review>()
            .HasOne(r => r.CreatedBy)
            .WithMany(u => u.Reviews);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.LastModifiedBy)
            .WithMany(u => u.ModifiedReviews);


        // Notification configurations
        modelBuilder.Entity<Notification>()
            .HasOne(n => n.Receiver)
            .WithMany(u => u.ReceivedNotifications)
            .HasForeignKey(n => n.ReceiverId)
            .IsRequired();

        modelBuilder.Entity<Notification>()
            .HasOne(n => n.CreatedBy)
            .WithMany(u => u.SentNotifications);

        modelBuilder.Entity<Notification>()
            .HasOne(n => n.LastModifiedBy)
            .WithMany(u => u.ModifiedNotifications);


        // Booking configurations
        modelBuilder.Entity<Booking>()
            .HasOne(b => b.AssociatedPackage)
            .WithMany(p => p.Bookings)
            .IsRequired();

        modelBuilder.Entity<Booking>()
            .HasOne(b => b.CreatedBy)
            .WithMany(u => u.Bookings);

        modelBuilder.Entity<Booking>()
            .HasOne(b => b.LastModifiedBy)
            .WithMany(u => u.ModifiedBookings);

        // Coupon configurations
         modelBuilder.Entity<Coupon>()
            .HasOne(c => c.CreatedBy)                     
            .WithMany(u => u.Coupons);

         modelBuilder.Entity<Coupon>()
            .HasMany(c => c.Packages)                     
            .WithMany(u => u.Coupons);  

        // Destination configurations
        modelBuilder.Entity<Destination>()
            .HasOne(d => d.CreatedBy)                     
            .WithMany(u => u.Destinations);



        // Package configurations
        modelBuilder.Entity<Package>()
            .HasOne(p => p.CreatedBy)                    
            .WithMany(u => u.Packages); 

        modelBuilder.Entity<Package>()
            .HasOne(p => p.Destination)                    
            .WithMany(u => u.Packages);

         modelBuilder.Entity<Package>()
            .HasIndex(e => e.Name)
            .IsUnique();

    }

        public DbSet<Destination> Destinations { get; set; } = default!;
        public DbSet<Package> Packages { get; set; } = default!;
        public DbSet<Booking> Bookings { get; set; } = default!;
        public DbSet<Coordinator> Coordinators { get; set; } = default!;
        public DbSet<Coupon> Coupons { get; set; } = default!;
        public DbSet<Notification> Notifications { get; set; } = default!;
        public DbSet<Review> Reviews { get; set; } = default!;
        public DbSet<WishForm> WishForms { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;


        
    }
}
