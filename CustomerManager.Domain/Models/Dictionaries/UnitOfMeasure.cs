using CustomerManager.Domain.Models.Dictionaries.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Dictionaries
{
    public class UnitOfMeasure
    {
        public int Id { get; private set; }

        public string Symbol { get; private set; }

        public string Name { get; private set; }

        public string? Description { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public string? CreatedBy { get; private set; }

        public UnitOfMeasure(int id, string symbol, string name, string? description = null, string? createdBy = null)
        {
            if (string.IsNullOrWhiteSpace(symbol))
                throw new InvalidUnitOfMeasureException("Unit of measure symbol cannot be empty.");

            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidUnitOfMeasureException("Unit of measure name cannot be empty.");

            Id = id;
            Symbol = symbol;
            Name = name;
            Description = description;
            CreatedAt = DateTime.UtcNow;
            CreatedBy = createdBy;
        }

        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new InvalidUnitOfMeasureException("Unit of measure name cannot be empty.");

            Name = newName;
        }

        public void UpdateSymbol(string newSymbol)
        {
            if (string.IsNullOrWhiteSpace(newSymbol))
                throw new InvalidUnitOfMeasureException("Unit of measure symbol cannot be empty.");

            Symbol = newSymbol;
        }

        public void UpdateDescription(string? newDescription)
        {
            Description = newDescription;
        }
    }
}
