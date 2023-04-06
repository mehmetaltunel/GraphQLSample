using GraphQL.Core.UoW;
using GraphQL.DataAcess.Context;
using GraphQL.DataAcess.Repositories.Abstract;
using GraphQL.DataAcess.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.DataAcess
{
    public static class ServiceRegistration
    {
        public static void DataAccessRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(x =>
            {
                x.UseNpgsql(configuration.GetConnectionString("DbContext"))
                    .LogTo(x => Debug.WriteLine(x));
                x.UseLazyLoadingProxies(false);
                x.EnableSensitiveDataLogging();
            });
            services.TryAddScoped(typeof(IUnitOfWork), typeof(UnitOfWork<DataContext>));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
