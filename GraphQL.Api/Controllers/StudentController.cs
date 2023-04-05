using GraphQL.Business.Student;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            return Ok(await _studentService.GetAllStudents());
        }
    }
}
