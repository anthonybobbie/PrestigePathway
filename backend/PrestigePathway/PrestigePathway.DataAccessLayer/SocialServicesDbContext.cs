using Microsoft.EntityFrameworkCore;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.DataAccessLayer
{


    public class SocialServicesDbContext : DbContext
    {
        public SocialServicesDbContext(DbContextOptions<SocialServicesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<StaffAssistant> StaffAssistant { get; set; }
        public DbSet<ServiceLocation> ServiceLocations { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure enums as strings
            modelBuilder.Entity<Client>()
                .Property(c => c.ClientType)
                .HasConversion<string>();

            modelBuilder.Entity<Service>()
                .Property(s => s.Category)
                .HasConversion<string>();

            modelBuilder.Entity<Booking>()
                .Property(b => b.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentMethod)
                .HasConversion<string>();

            // Configure relationships
            modelBuilder.Entity<StaffAssistant>()
                .HasKey(sa => new { sa.StaffID, sa.BookingID });

            modelBuilder.Entity<ServiceLocation>()
                .HasKey(sl => new { sl.ServiceID, sl.LocationID });

            // Configure indexes
            modelBuilder.Entity<Client>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Payment>()
                .HasIndex(p => p.TransactionID)
                .IsUnique();

            // Configure default values
            modelBuilder.Entity<Client>()
                .Property(c => c.RegistrationDate)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Service>()
                .Property(s => s.IsActive)
                .HasDefaultValue(true);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
        }
    }
}
