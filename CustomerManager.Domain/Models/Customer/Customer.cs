using CustomerManager.Domain.Models.Customer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Customer
{
    public class Customer
    {
        public int Id { get; private set; }
        public string? Email { get; private set; }
        public string? Phone { get; private set; }
        public string Name { get; private set; }
        public bool IsActive { get; private set; }
        public string AssignedUserId { get; private set; }
        public int CustomerTypeId { get; private set; }
        public int CustomerPotentialId { get; private set; }
        public int CustomerActivityId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string? CreatedBy { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public string? UpdatedBy { get; private set; }

        private readonly List<Address> _addresses = new();
        public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();

        private readonly List<ContactPerson> _contactPersons = new();
        public IReadOnlyCollection<ContactPerson> ContactPersons => _contactPersons.AsReadOnly();

        private readonly List<CustomerNote> _notes = new();
        public IReadOnlyCollection<CustomerNote> Notes => _notes.AsReadOnly();

        private readonly List<CustomerProduct> _products = new();
        public IReadOnlyCollection<CustomerProduct> Products => _products.AsReadOnly();

        public Customer(
           string name,
           string assignedUserId,
           int customerTypeId,
           int customerPotentialId,
           int customerActivityId,
           string? email = null,
           string? phone = null,
           string? createdBy = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidCustomerException("Customer name is required.");
            if (string.IsNullOrWhiteSpace(assignedUserId))
                throw new InvalidCustomerException("Assigned user ID is required.");
            if (customerTypeId <= 0)
                throw new InvalidCustomerException("Customer type ID must be greater than 0.");
            if (customerPotentialId <= 0)
                throw new InvalidCustomerException("Customer potential ID must be greater than 0.");
            if (customerActivityId <= 0)
                throw new InvalidCustomerException("Customer activity ID must be greater than 0.");

            Name = name;
            Email = email;
            Phone = phone;
            AssignedUserId = assignedUserId;
            CustomerTypeId = customerTypeId;
            CustomerPotentialId = customerPotentialId;
            CustomerActivityId = customerActivityId;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
            CreatedBy = createdBy;
        }

        public void UpdateAssignedUser(string userId, string? updatedBy = null)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new InvalidCustomerException("Assigned user ID cannot be empty.");

            AssignedUserId = userId;
            Touch(updatedBy);
        }

        public void UpdateName(string name, string? updatedBy = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidCustomerException("Name cannot be empty.");
            Name = name.Trim();
            Touch(updatedBy);
        }

        public void UpdateEmail(string? email, string? updatedBy = null)
        {
            Email = email?.Trim();
            Touch(updatedBy);
        }

        public void UpdatePhone(string? phone, string? updatedBy = null)
        {
            Phone = phone?.Trim();
            Touch(updatedBy);
        }

        public void UpdateType(int typeId, string? updatedBy = null)
        {
            if (typeId <= 0)
                throw new InvalidCustomerException("Customer type ID must be greater than 0.");
            CustomerTypeId = typeId;
            Touch(updatedBy);
        }

        public void UpdatePotential(int potentialId, string? updatedBy = null)
        {
            if (potentialId <= 0)
                throw new InvalidCustomerException("Customer potential ID must be greater than 0.");
            CustomerPotentialId = potentialId;
            Touch(updatedBy);
        }

        public void UpdateActivity(int activityId, string? updatedBy = null)
        {
            if (activityId <= 0)
                throw new InvalidCustomerException("Customer activity ID must be greater than 0.");
            CustomerActivityId = activityId;
            Touch(updatedBy);
        }

        public void Activate(string? updatedBy = null)
        {
            IsActive = true;
            Touch(updatedBy);
        }

        public void Deactivate(string? updatedBy = null)
        {
            IsActive = false;
            Touch(updatedBy);
        }

        private void Touch(string? updatedBy)
        {
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = updatedBy;
        }
    }
}
