using GraphQL.Business.GraphQL.Queries;
using GraphQL.Business.GraphQL.RepositoryQueries;
using GraphQL.Business.Services.Abstract;
using GraphQL.Business.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Business
{
    public static class ServiceRegistration
    {
        public static void BusinessRegister(this IServiceCollection services)
        {
            services.AddScoped<CategoryQuery>();
            services.AddScoped<IRepositoryQueries, RepositoryQueries>();
            services.AddGraphQLServer().AddQueryType<CategoryQuery>();
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
