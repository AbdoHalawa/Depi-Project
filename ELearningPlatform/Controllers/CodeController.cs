using ELearningPlatform.Models;
using ELearningPlatform.Repositery;
using Microsoft.AspNetCore.Mvc;

namespace ELearningPlatform.Controllers
{
    public class CodeController : Controller
    {
        ICodeRepositery codeRepositery;
        ICourseRepositery courseRepositery;
        public CodeController(ICodeRepositery codeRepositery, ICourseRepositery courseRepositery) {
            this.codeRepositery = codeRepositery;
            this.courseRepositery = courseRepositery;
        }
        public IActionResult Index()
        {
            var codes = codeRepositery.GetAllCodes();
            return View();
        }
        public IActionResult GetCourseById(int id)
        {
            var code = codeRepositery.GetCodeById(id);
            return Ok(new { codeId = code.Id });
        }
        // GET: Display the AddCode form
        public IActionResult AddCode()
        {
            // Ensure the repository returns a valid list of courses
            var courses = courseRepositery.GetAllCourses();
            if (courses == null || !courses.Any())
            {
                // Handle the scenario where no courses are found
                ViewBag.Courses = new List<Course>(); // Empty list instead of null
            }
            else
            {
                ViewBag.Courses = courses;
            }

            return View();
        }

        // POST: Handle the form submission
        [HttpPost]
        public IActionResult AddCode(Course_Codes code)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Save the code data to the database
                    codeRepositery.AddCode(code);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Pass the error message to the view
                    ViewBag.ErrorMessage = $"Error saving code: {ex.Message}";
                }
            }

            // Ensure ViewBag.Courses is populated again if ModelState is invalid
            var courses = courseRepositery.GetAllCourses();
            ViewBag.Courses = courses ?? new List<Course>(); // Empty list instead of null

            return View(code);
        }



    }
}
