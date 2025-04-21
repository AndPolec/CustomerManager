using CustomerManager.Domain.Common.BaseTypes;
using CustomerManager.Domain.Models.Product.Exceptions;
using CustomerManager.Domain.Models.UserProfile.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.UserProfile
{
    public class JobTitle: AuditableEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }

        public JobTitle(string name, string createdBy, string? description = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidJobTitleException("Job title name cannot be empty.");

            if (string.IsNullOrWhiteSpace(createdBy))
                throw new InvalidJobTitleException("UpdatedBy is required.");

            Name = name;
            Description = description;
            SetCreated(createdBy);
        }

        public void UpdateDescription(string? newDescription, string updatedBy)
        {
            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidJobTitleException("UpdatedBy is required.");

            Description = newDescription;
            Touch(updatedBy);
        }

        internal void SetId(int id)
        {
            if (id <= 0)
                throw new InvalidJobTitleException("ID must be greater than zero.");

            Id = id;
        }
    }
}
