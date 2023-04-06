using GraphQL.Business.Services.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Business.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponseModel>> GetAllCategories();
    }
}
