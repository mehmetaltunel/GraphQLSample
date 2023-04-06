using GraphQL.Core.Repositories;
using GraphQL.DataAcess.Context;
using GraphQL.DataAcess.Entities;
using GraphQL.DataAcess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.DataAcess.Repositories.Concrete
{
    public class CategoryRepository : Repository<Category, DataContext>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }
    }
}
