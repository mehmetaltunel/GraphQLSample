using GraphQL.DataAcess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Business.Student
{
    public class StudentQuery
    {
        private readonly DataContext _dbContext;
        public StudentQuery(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<DataAcess.Entities.Student> Students => _dbContext.Students.AsQueryable();
    }
}
