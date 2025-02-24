using Microsoft.EntityFrameworkCore;
using PrestigePathway.DataAccessLayer.Abstractions;
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
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<ServiceOption> ServiceOptions { get; set; }
        public DbSet<ServicePartner> ServicePartners { get; set; }
        public DbSet<ServiceDetail> ServiceDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure enums as strings
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(b => b.Status)
                    .HasConversion<string>();
                entity.Property(b => b.CreatedOnUtc)
                    .HasDefaultValueSql("GETUTCDATE()");
            });
            
            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(c => c.ClientType)
                    .HasConversion<string>();
                entity.HasIndex(c => c.Email)
                    .IsUnique();
                entity.Property(c => c.Email)
                    .IsRequired();
                entity.Property(c => c.CreatedOnUtc)
                    .HasDefaultValueSql("GETUTCDATE()");
                // Configure default values
                entity.Property(c => c.RegistrationDate)
                    .HasDefaultValueSql("GETUTCDATE()");
            });
            
            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(l => l.CreatedOnUtc)
                    .HasDefaultValueSql("GETUTCDATE()");
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.Property(p => p.CreatedOnUtc)
                    .HasDefaultValueSql("GETUTCDATE()");
            });
            
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(p => p.PaymentMethod)
                    .HasConversion<string>();
                entity.HasIndex(p => p.TransactionID).IsUnique();
                entity.Property(p => p.CreatedOnUtc).HasDefaultValueSql("GETUTCDATE()");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.Property(p => p.CreatedOnUtc)
                    .HasDefaultValueSql("GETUTCDATE()");
            });
            
            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(s => s.Category)
                    .HasConversion<string>();
                entity.Property(s => s.CreatedOnUtc)
                    .HasDefaultValueSql("GETUTCDATE()");
                entity.Property(s => s.IsActive)
                    .HasDefaultValue(true);
            });
            
            modelBuilder.Entity<ServiceDetail>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();
                entity.HasOne(e => e.ServicePartner)
                    .WithMany(e => e.ServiceDetails)
                    .HasForeignKey(e => e.ServicePartnerID);
                entity.HasOne(e => e.ServiceType)
                    .WithMany(e => e.ServiceDetails)
                    .HasForeignKey(e => e.ServiceTypeID)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.ServiceOption)
                    .WithMany(e => e.ServiceDetails)
                    .HasForeignKey(e => e.ServiceOptionID)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.Property(sd => sd.CreatedOnUtc)
                    .HasDefaultValueSql("GETUTCDATE()");
            });
            
            modelBuilder.Entity<ServiceLocation>(entity =>
            {
                entity.HasKey(sl => new { sl.ServiceID, sl.LocationID });
                entity.Property(sl => sl.CreatedOnUtc).HasDefaultValueSql("GETUTCDATE()");
            });
            
            modelBuilder.Entity<ServiceOption>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.OptionName)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.HasOne(e => e.ServiceType)
                    .WithMany(e => e.ServiceOptions)
                    .HasForeignKey(e => e.ServiceTypeID)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.Property(so => so.CreatedOnUtc).HasDefaultValueSql("GETUTCDATE()");
            });
            
            modelBuilder.Entity<ServicePartner>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.PartnerName)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.HasOne(e => e.ServiceType)
                    .WithMany(e => e.ServicePartners)
                    .HasForeignKey(e => e.ServiceTypeID)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.ServiceOption)
                    .WithMany(e => e.ServicePartners)
                    .HasForeignKey(e => e.ServiceOptionID)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.Property(sp => sp.CreatedOnUtc).HasDefaultValueSql("GETUTCDATE()");
            });

            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.CreatedOnUtc)
                    .HasDefaultValueSql("GETUTCDATE()");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(s => s.CreatedOnUtc).HasDefaultValueSql("GETUTCDATE()");
            });
            
            modelBuilder.Entity<StaffAssistant>(entity =>
            {
                // Configure relationships
                entity.HasKey(sa => new { sa.StaffID, sa.BookingID });
                entity.Property(sa => sa.CreatedOnUtc).HasDefaultValueSql("GETUTCDATE()");
            });
            
            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.Property(t => t.CreatedOnUtc)
                    .HasDefaultValueSql("GETUTCDATE()");
            });
            
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(u => u.Username)
                    .IsUnique();
                entity.Property(u => u.CreatedOnUtc).HasDefaultValueSql("GETUTCDATE()");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(ur => new { ur.UserID, ur.RoleID });
                entity.HasOne(ur => ur.Role)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(ur => ur.RoleID);
                entity.Property(ur => ur.CreatedOnUtc).HasDefaultValueSql("GETUTCDATE()");
            });
            
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Overrides SaveChanges to set CreatedOnUtc and ModifiedOnUtc properties.
        /// </summary>
        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        /// <summary>
        /// Overrides SaveChangesAsync to set CreatedOnUtc and ModifiedOnUtc properties.
        /// </summary>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Updates the CreatedOnUtc and ModifiedOnUtc timestamps before saving changes.
        /// </summary>
        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries<IEntityTracker>();

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.ModifiedOnUtc = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedOnUtc = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }

                //if (entry.State == EntityState.Added)
                //{
                //    entry.Entity.CreatedOnUtc = DateTime.UtcNow;
                //}

                //if (entry.State == EntityState.Modified)
                //{
                //    entry.Entity.ModifiedOnUtc = DateTime.UtcNow;
                //}
            }
        }
    }
}
