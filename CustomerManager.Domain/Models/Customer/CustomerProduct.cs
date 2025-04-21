using CustomerManager.Domain.Common.BaseTypes;
using CustomerManager.Domain.Models.Customer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Customer
{
    public class CustomerProduct: AuditableEntity
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int UnitOfMeasureId { get; private set; }
        public decimal Quantity { get; private set; }
        public int PurchaseFrequencyId { get; private set; }
        public DateOnly StartDate { get; private set; }
        public DateOnly? EndDate { get; private set; }
        public bool IsActive { get; private set; }
        
        internal CustomerProduct(
            int productId,
            int unitOfMeasureId,
            decimal quantity,
            int purchaseFrequencyId,
            string? createdBy,
            DateOnly startDate,
            DateOnly? endDate = null,
            bool isActive = true)
        {
            if (productId <= 0)
                throw new InvalidCustomerProductException("Product ID must be greater than 0.");

            if (unitOfMeasureId <= 0)
                throw new InvalidCustomerProductException("Unit of Measure ID must be greater than 0.");

            if (quantity <= 0)
                throw new InvalidCustomerProductException("Quantity must be greater than 0.");

            if (purchaseFrequencyId <= 0)
                throw new InvalidCustomerProductException("Purchase Frequency ID must be greater than 0.");

            if (endDate.HasValue && endDate < startDate)
                throw new InvalidCustomerProductException("End date cannot be before start date.");

            if (string.IsNullOrWhiteSpace(createdBy))
                throw new InvalidCustomerProductException("CreatedBy is required.");

            ProductId = productId;
            UnitOfMeasureId = unitOfMeasureId;
            Quantity = quantity;
            PurchaseFrequencyId = purchaseFrequencyId;
            StartDate = startDate;
            EndDate = endDate;
            IsActive = isActive;
            Touch(createdBy);
        }

        internal void UpdateQuantity(decimal quantity, string updatedBy)
        {
            if (quantity <= 0)
                throw new InvalidCustomerProductException("Quantity must be greater than 0.");

            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidCustomerProductException("UpdatedBy is required.");

            Quantity = quantity;
            Touch(updatedBy);
        }

        internal void UpdateUnitOfMeasure(int unitOfMeasureId, string updatedBy)
        {
            if (unitOfMeasureId <= 0)
                throw new InvalidCustomerProductException("Unit of Measure ID must be greater than 0.");

            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidCustomerProductException("UpdatedBy is required.");

            UnitOfMeasureId = unitOfMeasureId;
            Touch(updatedBy);
        }

        internal void UpdatePurchaseFrequency(int frequencyId, string updatedBy)
        {
            if (frequencyId <= 0)
                throw new InvalidCustomerProductException("Purchase Frequency ID must be greater than 0.");

            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidCustomerProductException("UpdatedBy is required.");

            PurchaseFrequencyId = frequencyId;
            Touch(updatedBy);
        }

        internal void SetEndDate(DateOnly? endDate, string updatedBy)
        {
            if (endDate.HasValue && endDate.Value < StartDate)
                throw new InvalidCustomerProductException("End date cannot be before start date.");

            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidCustomerProductException("UpdatedBy is required.");

            EndDate = endDate;
            Touch(updatedBy);
        }

        internal void Deactivate(string updatedBy)
        {
            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidCustomerProductException("UpdatedBy is required.");

            IsActive = false;
            Touch(updatedBy);
        }

        internal void Activate(string updatedBy)
        {
            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidCustomerProductException("UpdatedBy is required.");

            IsActive = true;
            Touch(updatedBy);
        }

        internal void SetId(int id)
        {
            if (id <= 0)
                throw new InvalidCustomerProductException("ID must be greater than 0.");
            Id = id;
        }
    }
}
