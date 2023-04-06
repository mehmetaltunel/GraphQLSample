using GraphQL.Business.GraphQL.RepositoryQueries.Abstract;
using GraphQL.Business.GraphQL.ResponseModels;
using GraphQL.Core.UoW;
using GraphQL.DataAcess.Repositories.Abstract;

namespace GraphQL.Business.GraphQL.RepositoryQueries.Concrete
{
    public class CategoryRepositoryQuery : ICategoryRepositoryQuery
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryRepositoryQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<CategoryQueryResponseModel> GetCategories()
            => (from category in _unitOfWork.Repository<ICategoryRepository>().Query()
                let products = (from product in _unitOfWork.Repository<IProductRepository>().Query()
                                where product.CategoryId == category.Id
                                select product
                                ).ToList()
                select new CategoryQueryResponseModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    Products = products.Select(x => new ProductQueryResponseModel
                    {
                        Code = x.Code,
                        Name = x.Name,
                        Description = x.Description,
                        CategoryId = x.CategoryId,
                        ListingPrice = x.ListingPrice,
                        Price = x.Price,
                        CategoryName = category.Name
                    }).ToList()
                });

       
    }
}
