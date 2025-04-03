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
    public class UserProfile
    {
        public string Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string? Email { get; private set; }

        public string? PhoneNumber { get; private set; }

        public bool IsActive { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public string? CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public string? UpdatedBy { get; private set; }

        public  JobTitle? JobTitle { get; private set; }

        public UserProfile(string id, string firstName, string lastName, string? email = null, 
            string? phoneNumber = null, bool? isActive = true, JobTitle? jobTitle = null, string? createdBy = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new InvalidUserProfileException("User ID is required.");

            if (string.IsNullOrWhiteSpace(firstName))
                throw new InvalidUserProfileException("First name is required.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new InvalidUserProfileException("Last name is required.");

            if (email != null)
                Email = CleanAndValidateEmail(email);
            

            if (phoneNumber != null)
                phoneNumber = CleanAndValidatePhoneNumber(phoneNumber);
            

            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            IsActive = isActive ?? true;
            CreatedAt = DateTime.UtcNow;
            CreatedBy = createdBy;
            JobTitle = jobTitle;
        }

        

        public void UpdateName(string firstName, string lastName, string? updatedBy = null)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new InvalidUserProfileException("First name cannot be empty.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new InvalidUserProfileException("Last name cannot be empty.");

            FirstName = firstName;
            LastName = lastName;
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = updatedBy;
        }

        public void UpdateContact(string? email, string? phoneNumber, string? updatedBy = null)
        {
            if (email != null)
            {
                Email = CleanAndValidateEmail(email);
            }

            if (phoneNumber != null)
            {
                phoneNumber = CleanAndValidatePhoneNumber(phoneNumber);
            }

            Email = email;
            PhoneNumber = phoneNumber;
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = updatedBy;
        }

        public void UpdateJobTitle(JobTitle jobTitle, string? updatedBy = null)
        {
            if (jobTitle == null)
            {
                throw new InvalidUserProfileException("Job title cannot be null.");
            }

            JobTitle = jobTitle;
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = updatedBy;
        }

        public void Deactivate(string? updatedBy = null)
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = updatedBy;
        }

        public void Activate(string? updatedBy = null)
        {
            IsActive = true;
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = updatedBy;
        }

        private string CleanAndValidateEmail(string email)
        {
            var trimmed = email.Trim();

            try
            {
                var mailAddress = new MailAddress(trimmed);
                if (mailAddress.Address != trimmed)
                    throw new InvalidUserProfileException("Invalid email format.");

                return trimmed;
            }
            catch
            {
                throw new InvalidUserProfileException("Invalid email format.");
            }
        }

        private string CleanAndValidatePhoneNumber(string phoneNumber)
        {
            var cleaned = phoneNumber.Replace(" ", "").Replace("-", "");

            if (!IsValidPhoneNumber(cleaned))
                throw new InvalidUserProfileException("Invalid phone number.");

            return cleaned;
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^\+?[1-9]\d{6,14}$");
        }
    }
}
