using ELearningPlatform.Models;
using ELearningPlatform.Repositery;
using Microsoft.AspNetCore.Mvc;

namespace ELearningPlatform.Controllers
{
    public class ExamController : Controller
    {
        ILectureRepositery lectureRepositery;
        IExamRepositery examRepositery;
        public ExamController( ILectureRepositery lectureRepositery, IExamRepositery examRepositery)
        {
            this.lectureRepositery = lectureRepositery;
            this.examRepositery = examRepositery;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddExamToLecture(int id)
        {
            var lecture = lectureRepositery.GetLectureById(id);
            var exam = new Lecture_Exams
            {
                LectureId = lecture.Id
            };
            return View(exam);

        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult AddExamToLecture(int id, Lecture_Exams exam)
        {
            var lecture = lectureRepositery.GetLectureById(id);
            examRepositery.AddExamToLecture(id, exam);
            return RedirectToAction("AddQuestionsToExam", new { id = exam.Id });
        }
        public IActionResult AddQuestionsToExam(int id)
        {
            var exam = examRepositery.GetExamById(id);
            var Questions = new List<Exam_Questions>
            {
                new Exam_Questions { ExamId = exam.Id }
            };
            return View(Questions);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult AddQuestionsToExam(int id, List<Exam_Questions> examQuestions)
        {
            var exam = examRepositery.GetExamById(id);
            examRepositery.AddQuestionsToExam(id, examQuestions);
            return RedirectToAction("index");
        }
        public IActionResult GetExamById(int id)
        {
            var exam = examRepositery.GetExamById(id);
            if (exam.ExamQuestions.Count == 0)
            {
                return RedirectToAction("AddQuestionsToExam", new { id = exam.Id });
            }
            return View(exam);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult UpdateExam(int id, Lecture_Exams exam)
        {
            examRepositery.UpdateExam(id, exam);
            return RedirectToAction("index");
        }
        public IActionResult DeleteExamById(int id)
        {
            examRepositery.DeleteExam(id);
            return RedirectToAction("index");
        }
    }
}
