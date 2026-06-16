using Microsoft.AspNetCore.Mvc;
using TmsApi.Services;

namespace TmsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _service;

        public EnrollmentController(IEnrollmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var enrollments = await _service.GetAllAsync();
            return Ok(enrollments);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string studentName, string courseName)
        {
            await _service.AddEnrollmentAsync(studentName, courseName);
            return Ok("Enrollment added successfully.");
        }
    }
}
