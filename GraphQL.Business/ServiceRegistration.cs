using GraphQL.Business.Student;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Business
{
    public static class ServiceRegistration
    {
        public static void BusinessRegister(this IServiceCollection services)
        {
            services.AddScoped<StudentQuery>();
            services.AddGraphQLServer().AddQueryType<StudentQuery>();
            services.AddScoped<IStudentService, StudentService>();
        }
    }
}
