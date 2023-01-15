using System.Collections.Generic;

namespace CleanArchitecture.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /* EF Relation */
        public ICollection<Product> Products { get; set; }
    }
}
