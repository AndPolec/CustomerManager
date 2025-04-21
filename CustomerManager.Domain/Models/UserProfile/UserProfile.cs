using CustomerManager.Domain.Common.BaseTypes;
using CustomerManager.Domain.Common.Validators;
using CustomerManager.Domain.Models.Product.Exceptions;
using CustomerManager.Domain.Models.UserProfile.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.UserProfile
{
    public class UserProfile: AuditableEntity
    {
        public string Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string? Email { get; private set; }
        public string? PhoneNumber { get; private set; }
        public bool IsActive { get; private set; }
        public  JobTitle? JobTitle { get; private set; }

        public UserProfile(
            string firstName, 
            string lastName,
            string createdBy,
            string? email, 
            string? phoneNumber, 
            bool isActive = true, 
            JobTitle? jobTitle = null)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new InvalidUserProfileException("First name is required.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new InvalidUserProfileException("Last name is required.");

            if (string.IsNullOrWhiteSpace(createdBy))
                throw new InvalidUserProfileException("CreatedBy is required.");

            if (email != null)
                email = EmailValidator.CleanAndValidate(email,() => new InvalidUserProfileException("Invalid email format."));
            
            if (phoneNumber != null)
                phoneNumber = PhoneNumberValidator.CleanAndValidate(phoneNumber, () => new InvalidUserProfileException("Invalid phone number format."));
            
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            IsActive = isActive;
            JobTitle = jobTitle;
            SetCreated(createdBy);
        }

        public void UpdateName(string firstName, string lastName, string updatedBy)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new InvalidUserProfileException("First name cannot be empty.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new InvalidUserProfileException("Last name cannot be empty.");

            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidUserProfileException("UpdatedBy is required.");

            FirstName = firstName;
            LastName = lastName;
            Touch(updatedBy);
        }

        public void UpdateContact(string? email, string? phoneNumber, string updatedBy)
        {
            if (email != null)
                email = EmailValidator.CleanAndValidate(email, () => new InvalidUserProfileException("Invalid email format."));

            if (phoneNumber != null)
                phoneNumber = PhoneNumberValidator.CleanAndValidate(phoneNumber, () => new InvalidUserProfileException("Invalid phone number format."));

            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidUserProfileException("UpdatedBy is required.");

            Email = email;
            PhoneNumber = phoneNumber;
            Touch(updatedBy);
        }

        public void UpdateJobTitle(JobTitle jobTitle, string updatedBy)
        {
            if (jobTitle == null)
                throw new InvalidUserProfileException("Job title cannot be null.");

            JobTitle = jobTitle;
            Touch(updatedBy);
        }

        public void Deactivate(string updatedBy)
        {
            IsActive = false;
            Touch(updatedBy);
        }

        public void Activate(string updatedBy)
        {
            IsActive = true;
            Touch(updatedBy);
        }

        internal void SetId(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
                throw new InvalidUserProfileException("ID is invalid.");

            Id = id;
        }
    }
}
