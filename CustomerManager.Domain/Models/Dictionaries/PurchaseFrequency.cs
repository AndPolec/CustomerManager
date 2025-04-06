using CustomerManager.Domain.Models.Dictionaries.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Dictionaries
{
    public class PurchaseFrequency
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public int MultiplierInDays { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public string? CreatedBy { get; private set; }

        public PurchaseFrequency(int id, string name, int multiplierInDays, string? createdBy = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidPurchaseFrequencyException("Purchase frequency name cannot be empty.");

            if (multiplierInDays <= 0)
                throw new InvalidPurchaseFrequencyException("Multiplier in days must be greater than zero.");

            Id = id;
            Name = name;
            MultiplierInDays = multiplierInDays;
            CreatedAt = DateTime.UtcNow;
            CreatedBy = createdBy;
        }

        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new InvalidPurchaseFrequencyException("Purchase frequency name cannot be empty.");

            Name = newName;
        }

        public void UpdateMultiplierInDays(int newMultiplierInDays)
        {
            if (newMultiplierInDays <= 0)
                throw new InvalidPurchaseFrequencyException("Multiplier in days must be greater than zero.");

            MultiplierInDays = newMultiplierInDays;
        }
    }
}
