using ELearningPlatform.Models;
using ELearningPlatform.Repositery;
using Microsoft.AspNetCore.Mvc;

namespace ELearningPlatform.Controllers
{
    public class VideoController : Controller
    {
        ICourseRepositery courseRepositery;
        IVideoRepositery videoRepositery;
        public VideoController(ICourseRepositery courseRepositery, IVideoRepositery videoRepositery)
        {
            this.courseRepositery = courseRepositery;
            this.videoRepositery = videoRepositery;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddVideoToCourse(int id)
        {
            Course course = courseRepositery.GetCourseById(id);

            var videoModel = new Lecture_Videos
            {
                LectureId = course.Id
            };

            return View(videoModel);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult AddVideoToCourse(int id, string title, IFormFile VideoFile)
        {
            if (VideoFile != null && VideoFile.Length > 0)
            {
                try
                {
                    // Call repository method to save the video
                    videoRepositery.AddVideoToLecture(id, VideoFile, title);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewData["FileError"] = "An error occurred while uploading the video: " + ex.Message;
                }
            }
            else
            {
                ViewData["FileError"] = "Please select a valid video file.";
            }

            return View();
        }
        public IActionResult GetVideoById(int id)
        {
            var video = videoRepositery.GetVideoById(id);
            if (video != null)
            {
                return File(video.VideoData, "video/mp4"); // Assuming VideoData is a byte array containing video content
            }
            return NotFound();
        }
        public IActionResult DeleteVideoById(int id)
        {
            videoRepositery.DeleteVideo(id);
            return RedirectToAction("index");
        }
    }
}
