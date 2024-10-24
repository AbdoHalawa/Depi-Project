using System.ComponentModel.DataAnnotations.Schema;

namespace ELearningPlatform.Models
{
    public class Instructor_Courses
    {
        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }
    }
}
