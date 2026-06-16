using Microsoft.AspNetCore.Mvc;
using TmsApi.Services;

namespace TmsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllCourses());
        }

        [HttpPost]
        public IActionResult Add(string code, string title, int capacity)
        {
            _service.AddCourse(code, title, capacity);
            return Ok("Course added successfully.");
        }
    }
}
