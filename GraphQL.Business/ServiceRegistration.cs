﻿using GraphQL.Business.GraphQL.Query;
using GraphQL.Business.GraphQL.RepositoryQueries.Abstract;
using GraphQL.Business.GraphQL.RepositoryQueries.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Business
{
    public static class ServiceRegistration
    {
        public static void BusinessRegister(this IServiceCollection services)
        {
            services.AddScoped<GraphQuery>();
            services.AddGraphQLServer()
                    .AddQueryType<GraphQuery>()
                    .AddSorting()
                    .AddFiltering()
                    ;

            services.AddScoped<ICategoryRepositoryQuery, CategoryRepositoryQuery>();
            services.AddScoped<IProductRepositoryQuery, ProductRepositoryQuery>();

        }
    }
}
