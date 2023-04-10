using GraphQL.Business.GraphQL.RepositoryQueries;
using GraphQL.Business.GraphQL.RepositoryQueries.Abstract;
using GraphQL.Business.GraphQL.ResponseModels;

namespace GraphQL.Business.GraphQL.Query
{
    public class GraphQuery
    {
        private readonly ICategoryRepositoryQuery _categoryQueries;
        private readonly IProductRepositoryQuery _productQueries;
        public GraphQuery(ICategoryRepositoryQuery categoryQueries, IProductRepositoryQuery productQueries)
        {
            _categoryQueries = categoryQueries;
            _productQueries = productQueries;
        }

        [UseFiltering]
        [UseSorting]
        //[UsePaging]
        public IQueryable<CategoryQueryResponseModel> Categories => _categoryQueries.GetCategories();

        [UseFiltering]
        [UseSorting]
        //[UsePaging]
        public IQueryable<ProductQueryResponseModel> Products => _productQueries.GetProducts();

    }
}
