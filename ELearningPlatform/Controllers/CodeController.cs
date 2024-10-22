using ELearningPlatform.Models;
using ELearningPlatform.Repositery;
using Microsoft.AspNetCore.Mvc;

namespace ELearningPlatform.Controllers
{
    public class CodeController : Controller
    {
        ICodeRepositery codeRepositery;
        public CodeController(ICodeRepositery codeRepositery) {
            this.codeRepositery = codeRepositery;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetCourseById(int id)
        {
            var code = codeRepositery.GetCodeById(id);
            return Ok(new { codeId = code.Id });
        }
    }
}
