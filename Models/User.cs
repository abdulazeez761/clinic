using Psychologist.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Psychologist.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Common ID for both Doctor and Patient

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = Roles.Admin; // Role should have a default

        [StringLength(100)]
        public string Pseudonym { get; set; } // For Patient anonymity or display name for Doctor

        [Required]
        [EmailAddress]
        public string Email { get; set; } // Required for both roles

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } // Encrypted before saving

        [DataType(DataType.PhoneNumber)]
        public string EncryptedPhoneNumber { get; set; } // Optional for both roles

        // Common Properties
        [StringLength(255)]
        public string ProfilePicturePath { get; set; } // Path to profile picture

        [StringLength(255)]
        public string LanguagesSpoken { get; set; }

        [Required]
        public string AccountStatus { get; set; } = Constants.AccountStatus.Active; // Defaults to Active

        // Doctor-Specific Properties
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        [StringLength(255)]
        public string CertificatePath { get; set; } // Path to certification document

        [StringLength(255)]
        public string Resume { get; set; } // Path to resume document

        [Range(18, 100)]
        public int? Age { get; set; } // Assuming a reasonable range for doctors

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(255)]
        public string University { get; set; }

        [StringLength(255)]
        public string Degree { get; set; }

        [StringLength(255)]
        public string Specialization { get; set; }

        [Range(0, 50)]
        public int? YearsOfExperience { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string LicenseNumber { get; set; }

        [Range(0.01, 10000.00)]
        public decimal? ConsultationFeePerHour { get; set; } // Nullable for Patients

        [StringLength(500)]
        public string AvailabilitySchedule { get; set; }

        [Range(1, 100)]
        public int? AppointmentLimitPerDay { get; set; }

        [Required]
        [StringLength(20)]
        public string Availability { get; set; } = Constants.Availability.Available;

        [Range(0, 5)]
        public double? Rating { get; set; }

        public Department Department { get; set; }
        public ICollection<Appointment> AppointmentsAsDoctor { get; set; }
        public ICollection<Appointment> AppointmentsAsPatient { get; set; }

        public ICollection<Payment> PaymentsAsDoctor { get; set; }
        public ICollection<Payment> PaymentsAsPatient { get; set; }
        public ICollection<Rating> RatingsAsDoctor { get; set; }
        public ICollection<Rating> RatingsAsPatient { get; set; }
        public ICollection<Review> ReviewsAsDoctor { get; set; }
        public ICollection<Review> ReviewsAsPatient { get; set; }
    }
}