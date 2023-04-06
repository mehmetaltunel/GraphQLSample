using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Business.GraphQL.ResponseModels
{
    public class ProductQueryResponseModel
    {
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public float? ListingPrice { get; set; }
        public string? CategoryName { get; set; }
    }
}
