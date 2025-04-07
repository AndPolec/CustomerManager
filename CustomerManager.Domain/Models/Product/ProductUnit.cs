using CustomerManager.Domain.Models.Dictionaries;
using CustomerManager.Domain.Models.Product.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Product
{
    public class ProductUnit
    {
        public int Id { get; private set; }

        public int ProductId { get; private set; }

        public int UnitId { get; private set; }

        public decimal ConversionFactor { get; private set; }

        public bool IsDefault { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public string? CreatedBy { get; private set; }

        public ProductUnit(int productId, int unitId, decimal conversionFactor, bool isDefault = false, string? createdBy = null)
        {
            if (conversionFactor <= 0)
                throw new InvalidProductUnitException("Conversion factor must be greater than zero.");

            ProductId = productId;
            UnitId = unitId;
            ConversionFactor = conversionFactor;
            IsDefault = isDefault;
            CreatedAt = DateTime.UtcNow;
            CreatedBy = createdBy;
        }

        public void SetDefault(bool isDefault)
        {
            IsDefault = isDefault;
        }

        public void UpdateConversionFactor(decimal newFactor)
        {
            if (newFactor <= 0)
                throw new InvalidProductUnitException("Conversion factor must be greater than zero.");

            ConversionFactor = newFactor;
        }
    }
}
