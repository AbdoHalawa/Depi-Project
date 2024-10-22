using ELearningPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ELearningPlatform.Repositery
{
    public class CourseRepositery : ICourseRepositery
    {
        ELearningContext context;
        IWebHostEnvironment env;
        public CourseRepositery(ELearningContext _context, IWebHostEnvironment env)
        {
            context = _context;
            this.env = env;
        }
        public List<Course> GetAllCourses()
        {
            return context.Courses.Include(c=>c.Crs_Students).ToList();
        }
        public void AddCourse(Course course)
        {
            if (course != null)
            {
                if (course.Crs_Cover != null)
                {
                    string ImageFolder = Path.Combine(env.WebRootPath, "img");
                    string ImagePath = Path.Combine(ImageFolder, course.Crs_Cover.FileName);
                    course.Crs_Cover.CopyTo(new FileStream(ImagePath, FileMode.Create));
                    course.Crs_Cover_Path = course.Crs_Cover.FileName;
                }
                context.Courses.Add(course);
                context.SaveChanges();
            }
        }

        public void AddCoverPhotoToCourse()
        {
            throw new NotImplementedException();
        }


        public void DeleteCourse(int id)
        {
            Course course = context.Courses.FirstOrDefault(c => c.Id == id);
            context.Courses.Remove(course);
            context.SaveChanges();
        }

        public Course GetCourseById(int id)
        {
            return context.Courses.Include(c => c.Crs_Lectures).Include(c => c.Crs_Codes).Include(c => c.Crs_Students).FirstOrDefault(c => c.Id == id);
        }

        public void UpdateCourse(int id, Course course)
        {
            throw new NotImplementedException();
        }

        public void UpdateCoverPhotoToCourse()
        {
            throw new NotImplementedException();
        }




        public void RegisterCourse(int StudentId, int CourseId, string codename)
        {

            var student = context.Students.FirstOrDefault(s => s.Id == StudentId);
            var course = context.Courses.FirstOrDefault(c => c.Id == CourseId);
            var code = context.Codes.FirstOrDefault(c => c.Code == codename);


            Course_Students courseStudent = new Course_Students
            {
                Student_ID = StudentId,
                Course_ID = CourseId,
                Code_ID = code.Id,
                Student = student,  // Use entity reference
                Course = course,    // Use entity reference
                Code = code
            };

            context.Course_Students.Add(courseStudent);
            context.SaveChanges();
        }
    }
}

