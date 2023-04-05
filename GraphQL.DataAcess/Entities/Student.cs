using GraphQL.Core.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.DataAcess.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string Roll { get; set; }
    }
}
