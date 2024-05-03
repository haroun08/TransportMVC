using Microsoft.EntityFrameworkCore;

namespace TransportMVC.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<User> Users {  get; set; }
        public DbSet<User_Manager> User_Manager {  get; set; }
        public DbSet<Destination> Destination { get; set; } = default!;
        public DbSet<Package> Package { get; set; } = default!;
        public DbSet<Reservation> Reservation { get; set; } = default!;
        public DbSet<Coordinator> Coordinator { get; set; } = default!;
        
    }
}
