namespace PrestigePathway.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public enum ClientType
    {
        Expatriate,
        Local
    }

    public enum ServiceCategory
    {
        Relocation,
        Concierge,
        Legal,
        Cultural,
        Health,
        Events
    }

    public enum BookingStatus
    {
        Pending,
        Confirmed,
        Completed,
        Cancelled
    }

    public enum PaymentMethod
    {
        Cash,
        MobileMoney,
        CreditCard,
        BankTransfer
    }

    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        public ClientType ClientType { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        public string Notes { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }

    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceID { get; set; }

        [Required]
        [StringLength(100)]
        public string ServiceName { get; set; }

        public string Description { get; set; }

        [Required]
        public ServiceCategory Category { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public int? DurationHours { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<Booking> Bookings { get; set; }
        public ICollection<ServiceLocation> ServiceLocations { get; set; }
    }

    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingID { get; set; }

        [ForeignKey("Client")]
        public int ClientID { get; set; }

        [ForeignKey("Service")]
        public int ServiceID { get; set; }

        public DateTime BookingDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [Required]
        public BookingStatus Status { get; set; } = BookingStatus.Pending;

        public string Notes { get; set; }

        public Client Client { get; set; }
        public Service Service { get; set; }
        public Payment Payment { get; set; }
        public ICollection<StaffAssignment> StaffAssignments { get; set; }
    }

    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentID { get; set; }

        [ForeignKey("Booking")]
        public int BookingID { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        [StringLength(100)]
        public string TransactionID { get; set; }

        public string Status { get; set; } = "Pending";

        public Booking Booking { get; set; }
    }

    // Add other classes (Staff, Partner, Location, etc.) following similar patterns
}
