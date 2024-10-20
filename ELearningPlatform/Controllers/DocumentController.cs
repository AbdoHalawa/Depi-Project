using ELearningPlatform.Models;
using ELearningPlatform.Repositery;
using Microsoft.AspNetCore.Mvc;

namespace ELearningPlatform.Controllers
{
    public class DocumentController : Controller
    {
        ICourseRepositery courseRepositery;
        ILectureRepositery lectureRepositery;
        IDocumentRepositery documentRepositery;
        public DocumentController(ICourseRepositery courseRepositery, ILectureRepositery lectureRepositery, IDocumentRepositery documentRepositery)
        {
            this.courseRepositery = courseRepositery;
            this.lectureRepositery = lectureRepositery;
            this.documentRepositery = documentRepositery;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddDocumentToCourse(int id)
        {
            // Fetch the course using the course repository, if needed
            Course course = courseRepositery.GetCourseById(id);

            // Create a new Course_Videos object and initialize it with the CourseId
            var DocumentModel = new Lecture_Documents
            {
                LectureId = course.Id // Setting the CourseId in the video model
            };

            // Pass the Course_Videos object to the view
            return View(DocumentModel);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult AddDocumentToCourse(int id, Lecture_Documents documents)
        {
            var lecture = lectureRepositery.GetLectureById(id);
            documentRepositery.AddDocumentToLecture(id, documents);
            return RedirectToAction("ViewLecture", new { id = lecture.Id });
        }
        public IActionResult DeleteDocumentById(int id)
        {
            documentRepositery.DeleteDocumentFromLecture(id);
            return RedirectToAction("index");
        }
    }
}
