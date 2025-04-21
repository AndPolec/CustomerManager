using CustomerManager.Domain.Common.BaseTypes;
using CustomerManager.Domain.Common.Validators;
using CustomerManager.Domain.Models.Customer.Exceptions;
using CustomerManager.Domain.Models.UserProfile.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Customer
{
    public class ContactPerson: AuditableEntity
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string? PhoneNumber { get; private set; }
        public string? Email { get; private set; }
        public int? RoleId { get; private set; }
        
        internal ContactPerson(
            string firstName,
            string lastName,
            string createdBy,
            string? email = null,
            string? phoneNumber = null,
            int? roleId = null)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new InvalidContactPersonException("First name is required.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new InvalidContactPersonException("Last name is required.");

            if (string.IsNullOrWhiteSpace(createdBy))
                throw new InvalidContactPersonException("CreatedBy is required.");

            if (email != null)
                email = EmailValidator.CleanAndValidate(email, () => new InvalidContactPersonException("Invalid email format."));

            if (phoneNumber != null)
                phoneNumber = PhoneNumberValidator.CleanAndValidate(phoneNumber, () => new InvalidContactPersonException("Invalid phone number format."));

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            RoleId = roleId;
            SetCreated(createdBy);
        }

        internal void UpdateContactInfo(string? email, string? phoneNumber, string updatedBy)
        {
            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidContactPersonException("UpdatedBy is required.");

            if (email != null)
                email = EmailValidator.CleanAndValidate(email, () => new InvalidContactPersonException("Invalid email format."));

            if (phoneNumber != null)
                phoneNumber = PhoneNumberValidator.CleanAndValidate(phoneNumber, () => new InvalidContactPersonException("Invalid phone number format."));

            Email = email;
            PhoneNumber = phoneNumber;
            Touch(updatedBy);
        }

        internal void UpdateName(string firstName, string lastName, string updatedBy)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new InvalidContactPersonException("First name is required.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new InvalidContactPersonException("Last name is required.");

            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidContactPersonException("UpdatedBy is required.");

            FirstName = firstName;
            LastName = lastName;
            Touch(updatedBy);
        }

        internal void UpdateRole(int roleId, string updatedBy)
        {
            if (roleId <= 0)
                throw new InvalidContactPersonException("Role ID is invalid.");

            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidContactPersonException("UpdatedBy is required.");

            RoleId = roleId;
            Touch(updatedBy);
        }

        internal void SetId(int id)
        {
            if (id <= 0)
                throw new InvalidContactPersonException("ID must be greater than 0.");
            Id = id;
        }
    }
}