using CustomerManager.Domain.Common.Validators;
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
        public string? PhoneNumber { get; private set; }
        public string Name { get; private set; }
        public bool IsActive { get; private set; }
        public string AssignedUserId { get; private set; }
        public int CustomerTypeId { get; private set; }
        public int CustomerPotentialId { get; private set; }
        public int CustomerActivityId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string CreatedBy { get; private set; }
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
            string createdBy,
            string? email = null,
            string? phone = null)
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
            if (string.IsNullOrWhiteSpace(createdBy))
                throw new InvalidCustomerException("CreatedBy is required.");

            Name = name;
            Email = email;
            PhoneNumber = phone;
            AssignedUserId = assignedUserId;
            CustomerTypeId = customerTypeId;
            CustomerPotentialId = customerPotentialId;
            CustomerActivityId = customerActivityId;
            CreatedBy = createdBy;
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
        }

        public void UpdateName(string name, string updatedBy)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidCustomerException("Name is required.");
            Name = name;
            Touch(updatedBy);
        }

        public void UpdateContact(string? email, string? phoneNumber, string updatedBy)
        {
            if (email != null)
            {
                email = EmailValidator.CleanAndValidate(email, () => new InvalidCustomerException("Invalid email format."));
            }

            if (phoneNumber != null)
            {
                phoneNumber = PhoneNumberValidator.CleanAndValidate(phoneNumber, () => new InvalidCustomerException("Invalid phone number format."));
            }

            Email = email;
            PhoneNumber = phoneNumber;
            Touch(updatedBy);
        }

        public void UpdateAssignedUser(string userId, string updatedBy)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new InvalidCustomerException("Assigned user ID is required.");

            AssignedUserId = userId;
            Touch(updatedBy);
        }

        public void UpdateType(int typeId, string updatedBy)
        {
            if (typeId <= 0)
                throw new InvalidCustomerException("Customer type ID must be greater than 0.");

            CustomerTypeId = typeId;
            Touch(updatedBy);
        }

        public void UpdatePotential(int potentialId, string updatedBy)
        {
            if (potentialId <= 0)
                throw new InvalidCustomerException("Customer potential ID must be greater than 0.");

            CustomerPotentialId = potentialId;
            Touch(updatedBy);
        }

        public void UpdateActivity(int activityId, string updatedBy)
        {
            if (activityId <= 0)
                throw new InvalidCustomerException("Customer activity ID must be greater than 0.");

            CustomerActivityId = activityId;
            Touch(updatedBy);
        }

        public void UpdateDetails(
            string name,
            string? email,
            string? phoneNumber,
            int typeId,
            int potentialId,
            int activityId,
            string updatedBy)
        {
            UpdateName(name, updatedBy);
            UpdateContact(email,phoneNumber,updatedBy);
            UpdateType(typeId, updatedBy);
            UpdatePotential(potentialId, updatedBy);
            UpdateActivity(activityId, updatedBy);
        }

        public void Activate(string updatedBy)
        {
            IsActive = true;
            Touch(updatedBy);
        }

        public void Deactivate(string updatedBy)
        {
            IsActive = false;
            Touch(updatedBy);
        }

        private void Touch(string updatedBy)
        {
            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidCustomerException("UpdatedBy is required.");
            UpdatedBy = updatedBy;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
