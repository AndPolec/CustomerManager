using CustomerManager.Domain.Common.BaseTypes;
using CustomerManager.Domain.Models.Product.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Product
{
    public class ProductTag: AuditableEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string? CreatedBy { get; private set; }

        public ProductTag(string name, string createdBy, string? description = null)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new InvalidProductTagException("Tag name cannot be empty.");

            if (String.IsNullOrWhiteSpace(createdBy))
                throw new InvalidProductTagException("CreatedBy is required.");

            Name = name;
            Description = description;
            SetCreated(createdBy);
        }

        public void UpdateName(string name, string createdBy)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new InvalidProductTagException("Tag name cannot be empty.");

            if (String.IsNullOrWhiteSpace(createdBy))
                throw new InvalidProductTagException("CreatedBy is required.");

            Name = name;
            Touch(createdBy);
        }

        public void UpdateDescription(string? newDescription, string createdBy)
        {
            if (String.IsNullOrWhiteSpace(createdBy))
                throw new InvalidProductTagException("CreatedBy is required.");

            Description = newDescription;
            Touch(createdBy);
        }

        internal void SetId(int id)
        {
            if (id <= 0)
                throw new InvalidProductTagException("ID must be greater than zero.");

            Id = id;
        }
    }
}
