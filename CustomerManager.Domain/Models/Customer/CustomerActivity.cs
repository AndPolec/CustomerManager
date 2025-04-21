using CustomerManager.Domain.Common.BaseTypes;
using CustomerManager.Domain.Models.Customer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Customer
{
    public class CustomerActivity: AuditableEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        
        public CustomerActivity(string name, string createdBy, string? description = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidCustomerActivityException("Activity name cannot be empty.");

            if (string.IsNullOrWhiteSpace(createdBy))
                throw new InvalidCustomerActivityException("CreateBy is required.");

            Name = name;
            Description = description;
            SetCreated(createdBy);
        }

        public void UpdateName(string newName, string updatedBy)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new InvalidCustomerActivityException("Activity name cannot be empty.");

            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidCustomerActivityException("UpdatedBy is required.");

            Name = newName;
            Touch(updatedBy);
        }

        public void UpdateDescription(string? newDescription, string updatedBy)
        {
            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidCustomerActivityException("UpdatedBy is required.");

            Description = newDescription;
            Touch(updatedBy);
        }

        internal void SetId(int id)
        {
            if (id <= 0)
                throw new InvalidCustomerActivityException("ID must be greater than 0.");
            Id = id;
        }
    }
}
