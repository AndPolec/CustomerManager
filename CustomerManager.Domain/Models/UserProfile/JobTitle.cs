using CustomerManager.Domain.Models.UserProfile.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.UserProfile
{
    public class JobTitle
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string? CreatedBy { get; private set; }

        public JobTitle(int id, string name, string? description = null, string? createdBy = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidJobTitleException("Job title name cannot be empty.");
            }

            Id = id;
            Name = name;
            Description = description;
            CreatedAt = DateTime.UtcNow;
            CreatedBy = createdBy;
        }

        public void UpdateDescription(string? newDescription)
        {
            Description = newDescription;
        }
    }
}
