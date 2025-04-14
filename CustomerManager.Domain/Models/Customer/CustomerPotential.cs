using CustomerManager.Domain.Models.Customer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Customer
{
    public class CustomerPotential
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string? Description { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public string? CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public string? UpdatedBy { get; private set; }

        public CustomerPotential(string name, string? description = null, string? createdBy = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidCustomerPotentialException("Potential name cannot be empty.");

            Name = name;
            Description = description;
            CreatedAt = DateTime.UtcNow;
            CreatedBy = createdBy;
        }

        public void UpdateName(string newName, string? updatedBy = null)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new InvalidCustomerPotentialException("Potential name cannot be empty.");

            Name = newName;
            Touch(updatedBy);
        }

        public void UpdateDescription(string? newDescription, string? updatedBy = null)
        {
            Description = newDescription;
            Touch(updatedBy);
        }

        public void SetId(int id)
        {
            if (id <= 0)
                throw new InvalidCustomerPotentialException("ID must be greater than 0.");

            Id = id;
        }

        private void Touch(string? updatedBy)
        {
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = updatedBy;
        }
    }
}
