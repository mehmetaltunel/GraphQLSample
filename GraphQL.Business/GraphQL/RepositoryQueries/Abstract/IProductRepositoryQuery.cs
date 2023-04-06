using GraphQL.Business.GraphQL.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Business.GraphQL.RepositoryQueries.Abstract
{
    public interface IProductRepositoryQuery
    {
        IQueryable<ProductQueryResponseModel> GetProducts();
    }
}
