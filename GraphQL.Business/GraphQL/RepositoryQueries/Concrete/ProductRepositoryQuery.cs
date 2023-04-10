using GraphQL.Business.GraphQL.RepositoryQueries.Abstract;
using GraphQL.Business.GraphQL.ResponseModels;
using GraphQL.Core.UoW;
using GraphQL.DataAcess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Business.GraphQL.RepositoryQueries.Concrete
{
    public class ProductRepositoryQuery : IProductRepositoryQuery
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductRepositoryQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<ProductQueryResponseModel> GetProducts()
           => (from product in _unitOfWork.Repository<IProductRepository>().Query()
               join category in _unitOfWork.Repository<ICategoryRepository>().Query() on product.CategoryId equals category.Id
               into ct
               from category in ct.DefaultIfEmpty()

               select new ProductQueryResponseModel
               {
                   Code = product.Code,
                   Name = product.Name,
                   Description = product.Description,
                   CategoryId = product.CategoryId,
                   ListingPrice = product.ListingPrice,
                   Price = product.Price,
                   CategoryName = category.Name
               });
    }
}
