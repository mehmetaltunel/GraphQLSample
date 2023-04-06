using GraphQL.Business.GraphQL.Query;
using GraphQL.Business.GraphQL.RepositoryQueries;
using GraphQL.Business.GraphQL.RepositoryQueries.Abstract;
using GraphQL.Business.GraphQL.RepositoryQueries.Concrete;
using GraphQL.Business.Services.Abstract;
using GraphQL.Business.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Business
{
    public static class ServiceRegistration
    {
        public static void BusinessRegister(this IServiceCollection services)
        {
            services.AddScoped<GraphQuery>();
            services.AddGraphQLServer().AddFiltering().AddQueryType<GraphQuery>();

            services.AddScoped<ICategoryRepositoryQuery, CategoryRepositoryQuery>();
            services.AddScoped<IProductRepositoryQuery, ProductRepositoryQuery>();

            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
