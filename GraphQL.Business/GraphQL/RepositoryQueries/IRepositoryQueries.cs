using GraphQL.Business.GraphQL.ResponseModels;

namespace GraphQL.Business.GraphQL.RepositoryQueries
{
    public interface IRepositoryQueries
    {
        IQueryable<CategoryQueryResponseModel> GetCategories();
    }
}
