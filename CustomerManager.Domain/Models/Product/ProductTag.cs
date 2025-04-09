using CustomerManager.Domain.Models.Product.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Product
{
    public class ProductTag
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string? CreatedBy { get; private set; }

        public ProductTag(string name, string? description = null, string? createdBy = null)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new InvalidProductTagException("Tag name cannot be empty.");

            Name = name;
            Description = description;
            CreatedBy = createdBy;
            CreatedAt = DateTime.UtcNow;
        }

        public void UpdateName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new InvalidProductTagException("Tag name cannot be empty.");
            Name = name;
        }

        public void UpdateDescription(string? newDescription)
        {
            Description = newDescription;
        }

        internal void SetId(int id)
        {
            if (id <= 0)
                throw new InvalidProductTagException("ID must be greater than zero.");

            Id = id;
        }
    }
}
