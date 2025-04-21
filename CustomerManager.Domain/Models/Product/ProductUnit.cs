using CustomerManager.Domain.Common.BaseTypes;
using CustomerManager.Domain.Models.Dictionaries;
using CustomerManager.Domain.Models.Product.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Product
{
    public class ProductUnit: AuditableEntity
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int UnitId { get; private set; }
        public decimal ConversionFactor { get; private set; }
        public bool IsDefault { get; private set; }

        internal ProductUnit(int productId, int unitId, decimal conversionFactor, string createdBy, bool isDefault = false)
        {
            if (conversionFactor <= 0)
                throw new InvalidProductUnitException("Conversion factor must be greater than zero.");

            if (string.IsNullOrWhiteSpace(createdBy))
                throw new InvalidProductUnitException("CreatedBy is required.");

            ProductId = productId;
            UnitId = unitId;
            ConversionFactor = conversionFactor;
            IsDefault = isDefault;
            SetCreated(createdBy);
        }

        internal void SetDefault(bool isDefault,string updatedBy)
        {
            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidProductUnitException("UpdatedBy is required.");

            IsDefault = isDefault;
            Touch(updatedBy);
        }

        internal void UpdateConversionFactor(decimal newFactor, string updatedBy)
        {
            if (newFactor <= 0)
                throw new InvalidProductUnitException("Conversion factor must be greater than zero.");

            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidProductUnitException("UpdatedBy is required.");

            ConversionFactor = newFactor;
            Touch(updatedBy);
        }
    }
}
