﻿using CustomerManager.Domain.Common.Validators;
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

        public UserProfile(
            string firstName, 
            string lastName, 
            string? email = null, 
            string? phoneNumber = null, 
            bool? isActive = true, 
            JobTitle? jobTitle = null, 
            string? createdBy = null)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new InvalidUserProfileException("First name is required.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new InvalidUserProfileException("Last name is required.");

            if (email != null)
                email = EmailValidator.CleanAndValidate(email,() => new InvalidUserProfileException("Invalid email format."));
            
            if (phoneNumber != null)
                phoneNumber = PhoneNumberValidator.CleanAndValidate(phoneNumber, () => new InvalidUserProfileException("Invalid phone number format."));
            
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
                email = EmailValidator.CleanAndValidate(email, () => new InvalidUserProfileException("Invalid email format."));
            }

            if (phoneNumber != null)
            {
                phoneNumber = PhoneNumberValidator.CleanAndValidate(phoneNumber, () => new InvalidUserProfileException("Invalid phone number format."));
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

        internal void SetId(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
                throw new InvalidUserProfileException("ID is invalid.");

            Id = id;
        }
    }
}
