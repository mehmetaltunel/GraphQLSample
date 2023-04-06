using GraphQL.Business.GraphQL.ResponseModels;

namespace GraphQL.Business.GraphQL.RepositoryQueries.Abstract
{
    public interface ICategoryRepositoryQuery
    {
        IQueryable<CategoryQueryResponseModel> GetCategories();
    }
}
