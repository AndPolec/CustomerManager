using CustomerManager.Domain.Common.BaseTypes;
using CustomerManager.Domain.Models.Product.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Product
{
    public class ProductCategory: AuditableEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
      
        public ProductCategory(string name, string? description, string createdBy)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidProductCategoryException("Category name cannot be empty.");

            if (string.IsNullOrWhiteSpace(createdBy))
                throw new InvalidProductCategoryException("CreatedBy is required.");

            Name = name;
            Description = description;
            SetCreated(createdBy);
        }

        public void UpdateName(string name, string createdBy)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidProductCategoryException("Category name cannot be empty.");

            if (string.IsNullOrWhiteSpace(createdBy))
                throw new InvalidProductCategoryException("CreatedBy is required.");

            Name = name;
            Touch(createdBy);
        }

        public void UpdateDescription(string? description, string createdBy)
        {
            if (string.IsNullOrWhiteSpace(createdBy))
                throw new InvalidProductCategoryException("CreatedBy is required.");    

            Description = description;
            Touch(createdBy);
        }

        internal void SetId(int id)
        {
            if (id <= 0)
                throw new InvalidProductCategoryException("ID must be greater than zero.");

            Id = id;
        }
    }
}
