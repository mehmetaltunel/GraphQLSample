using GraphQL.Core.Repositories;
using GraphQL.DataAcess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.DataAcess.Repositories.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
    }
}
