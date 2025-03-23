using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApplication1.Model
{
    public class HospitalRegistration
    {
        [Key]
        public int PatientID { get; set; }
        // public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string DoctorAssigned { get; set; }
        public string Role { get; set; }
        //public string DateOfJoining { get; set; }

        public string Address { get; set; }


    }

    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        public int Experience { get; set; }

        public string ContactNumber { get; set; }
        public string Email { get; set; }
    }

    public class PateintInfo
    {
        public int PatientID { get; set; }
        public string DoctorName { get; set; }
        public string VisitedDate { get; set; }
        public string Prescription { get; set; }
        public string LabReports { get; set; }

    }
    public class UserLogin
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

}

