using GraphQL.DataAcess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Business.Student
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _dbContext;

        public StudentService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<StudentResponseModel>> GetAllStudents()
        {
            var resp = await _dbContext.Students.ToListAsync();
            return resp.Select(x => new StudentResponseModel
            {
                Id = x.Id,
                Name = x.Name,
                Roll = x.Roll,
            });
        }
    }
}
