using GraphQL.Business.GraphQL.RepositoryQueries;
using GraphQL.Business.GraphQL.ResponseModels;

namespace GraphQL.Business.GraphQL.Queries
{
    public class CategoryQuery
    {
        private readonly IRepositoryQueries _customQueries;
        public CategoryQuery(IRepositoryQueries customQueries)
        {
            _customQueries = customQueries;
        }

        public IQueryable<CategoryQueryResponseModel> Categories => _customQueries.GetCategories();

    }
}
