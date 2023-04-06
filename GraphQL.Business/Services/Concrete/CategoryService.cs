using GraphQL.Business.Services.Abstract;
using GraphQL.Business.Services.ResponseModels;
using GraphQL.DataAcess.Context;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Business.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _dbContext;

        public CategoryService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CategoryResponseModel>> GetAllCategories()
        {
            var resp = await _dbContext.Categories.ToListAsync();
            return resp.Select(x => new CategoryResponseModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            });
        }

    }
}
