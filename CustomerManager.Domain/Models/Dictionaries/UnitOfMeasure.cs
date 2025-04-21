using CustomerManager.Domain.Common.BaseTypes;
using CustomerManager.Domain.Models.Dictionaries.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Dictionaries
{
    public class UnitOfMeasure: AuditableEntity
    {
        public int Id { get; private set; }
        public string Symbol { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }

        public UnitOfMeasure(string symbol, string name, string? createdBy, string? description = null)
        {
            if (string.IsNullOrWhiteSpace(symbol))
                throw new InvalidUnitOfMeasureException("Unit of measure symbol cannot be empty.");

            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidUnitOfMeasureException("Unit of measure name cannot be empty.");

            if (string.IsNullOrWhiteSpace(createdBy))
                throw new InvalidUnitOfMeasureException("CreatedBy is required.");

            Symbol = symbol;
            Name = name;
            Description = description;
            SetCreated(createdBy);
        }

        public void UpdateName(string newName, string updateBy)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new InvalidUnitOfMeasureException("Unit of measure name cannot be empty.");

            if (string.IsNullOrWhiteSpace(updateBy))
                throw new InvalidUnitOfMeasureException("UpdatedBy is required.");

            Name = newName;
            Touch(updateBy);
        }

        public void UpdateSymbol(string newSymbol, string updateBy)
        {
            if (string.IsNullOrWhiteSpace(newSymbol))
                throw new InvalidUnitOfMeasureException("Unit of measure symbol cannot be empty.");

            if (string.IsNullOrWhiteSpace(updateBy))
                throw new InvalidUnitOfMeasureException("UpdatedBy is required.");

            Symbol = newSymbol;
            Touch(updateBy);
        }

        public void UpdateDescription(string? newDescription, string updateBy)
        {
            if (string.IsNullOrWhiteSpace(updateBy))
                throw new InvalidUnitOfMeasureException("UpdatedBy is required.");

            Description = newDescription;
            Touch(updateBy);
        }

        internal void SetId(int id)
        {
            if (id <= 0)
                throw new InvalidUnitOfMeasureException("ID must be greater than zero.");

            Id = id;
        }
    }
}
