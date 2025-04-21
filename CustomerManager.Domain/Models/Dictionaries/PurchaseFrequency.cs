using CustomerManager.Domain.Common.BaseTypes;
using CustomerManager.Domain.Models.Dictionaries.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Dictionaries
{
    public class PurchaseFrequency: AuditableEntity
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public int MultiplierInDays { get; private set; }

        public PurchaseFrequency(string name, int multiplierInDays, string createdBy )
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidPurchaseFrequencyException("Purchase frequency name cannot be empty.");

            if (multiplierInDays <= 0)
                throw new InvalidPurchaseFrequencyException("Multiplier in days must be greater than zero.");

            if (string.IsNullOrWhiteSpace(createdBy))
                throw new InvalidPurchaseFrequencyException("CreatedBy is required.");

            Name = name;
            MultiplierInDays = multiplierInDays;
            SetCreated(createdBy);
        }

        public void UpdateName(string newName, string updatedBy)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new InvalidPurchaseFrequencyException("Purchase frequency name cannot be empty.");

            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidPurchaseFrequencyException("UpdatedBy is required.");

            Name = newName;
            Touch(updatedBy);
        }

        public void UpdateMultiplierInDays(int newMultiplierInDays, string updatedBy)
        {
            if (newMultiplierInDays <= 0)
                throw new InvalidPurchaseFrequencyException("Multiplier in days must be greater than zero.");

            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidPurchaseFrequencyException("UpdatedBy is required.");

            MultiplierInDays = newMultiplierInDays;
            Touch(updatedBy);
        }
    }
}
