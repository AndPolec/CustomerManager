using CustomerManager.Domain.Models.Product.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Product
{
    public class ProductCategory
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string? CreatedBy { get; private set; }

        public ProductCategory(int id, string name, string? description, string? createdBy = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidProductCategoryException("Category name cannot be empty.");

            Id = id;
            Name = name;
            Description = description;
            CreatedAt = DateTime.UtcNow;
            CreatedBy = createdBy;
        }

        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidProductCategoryException("Category name cannot be empty.");
            Name = name;
        }

        public void UpdateDescription(string? description)
        {
            Description = description;
        }
    }
}
