using ELearningPlatform.Models;
using ELearningPlatform.Repositery;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    public class CourseController : Controller
    {
        ICourseRepositery courseRepositery;
        public CourseController(ICourseRepositery courseRepositery) {
            this.courseRepositery = courseRepositery;
        }
        public IActionResult Index()
        {
            List<Course> courses = courseRepositery.GetAllCourses();
            return View(courses);
        }
        public IActionResult AddCourse(Course course)
        {
            if (string.IsNullOrWhiteSpace(course.Crs_Name))
            {
                ModelState.AddModelError("Crs_Name", "Course name is required.");
                return View(course);
            }

            courseRepositery.AddCourse(course);
            return RedirectToAction("Index");
        }




        public IActionResult GetCoursesByStudent()
        {
            List<Course> courses = courseRepositery.GetAllCourses();
            return View(courses);
        }




        public IActionResult ViewCoursesByStudent(int id)
        {
            ViewBag.StudentId = id;
            var courses = courseRepositery.GetAllCourses();
            return View(courses);
        }
        public IActionResult ViewCourseByStudent(int id)
        {
            var course = courseRepositery.GetCourseById(id);
            return View(course);
        }
        public IActionResult RegisterCourse(int StudentId,int CourseId)
        {
            var course = courseRepositery.GetCourseById(CourseId);
            ViewBag.StudentId = StudentId;
            return View(course);
        }
        [HttpPost]
        public IActionResult RegisterCourse(int StudentId, int CourseId , string codename)
        {
            courseRepositery.RegisterCourse(StudentId, CourseId, codename);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateCourse(int id)
        {
            var course = courseRepositery.GetCourseById(id);
            return View(course);
        }
        [HttpPost]
        public IActionResult UpdateCourse(int id , Course course)
        {
            courseRepositery.UpdateCourse(id, course);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCourse(int id) {  courseRepositery.DeleteCourse(id); return RedirectToAction("Index"); }
    }
}
