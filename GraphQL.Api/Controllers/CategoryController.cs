using GraphQL.Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            return Ok(await _categoryService.GetAllCategories());
        }
    }
}
