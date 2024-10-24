using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearningPlatform.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [PersonalData]
        public string Gender { get; set; }

        [PersonalData]
        public string? Street { get; set; }

        [PersonalData]
        public string? City { get; set; }

        [PersonalData]
        public string? Country { get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        public int? ApplicationUser_Id { get; set; }
        public ApplicationUser? User { get; set; }
        public List<Instructor_Courses> Crs_Instructor { get; set; } = new List<Instructor_Courses>();

    }
}