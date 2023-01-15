using System.Collections.Generic;
using CleanArchitecture.Domain.Validation;

namespace CleanArchitecture.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public string Name { get; private set; }

        /* EF Relation */
        public ICollection<Product> Products { get; set; }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;

            ValidateDomain(name);
        }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");

            Name = name;
        }
    }
}
