using GraphQL.Core.Entitiy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.DataAcess.Entities
{
    public class Product : BaseEntity
    {
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public float? ListingPrice { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
    }
}
