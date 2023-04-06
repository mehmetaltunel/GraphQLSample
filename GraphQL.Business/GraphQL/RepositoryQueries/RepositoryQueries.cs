using GraphQL.Business.GraphQL.ResponseModels;
using GraphQL.Core.UoW;
using GraphQL.DataAcess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Business.GraphQL.RepositoryQueries
{
    public class RepositoryQueries : IRepositoryQueries
    {
        private readonly IUnitOfWork _unitOfWork;

        public RepositoryQueries(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<CategoryQueryResponseModel> GetCategories()
            => _unitOfWork.Repository<ICategoryRepository>().Query().Select(x => new CategoryQueryResponseModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            });
    }
}
