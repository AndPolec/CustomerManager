using CustomerManager.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Customer
{
    public class CustomerActivity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string? CreatedBy { get; private set; }

        public CustomerActivity(string name, string? description = null, string? createdBy = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidCustomerActivityException("Activity name cannot be empty.");

            Name = name;
            Description = description;
            CreatedAt = DateTime.UtcNow;
            CreatedBy = createdBy;
        }

        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new InvalidCustomerActivityException("Activity name cannot be empty.");

            Name = newName;
        }

        public void UpdateDescription(string? newDescription)
        {
            Description = newDescription;
        }

        internal void SetId(int id)
        {
            if (id <= 0)
                throw new InvalidCustomerActivityException("ID must be greater than 0.");
            Id = id;
        }
    }
}
