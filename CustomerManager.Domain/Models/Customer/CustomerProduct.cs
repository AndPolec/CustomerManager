using CustomerManager.Domain.Models.Customer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Customer
{
    public class CustomerProduct
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int UnitOfMeasureId { get; private set; }
        public decimal Quantity { get; private set; }
        public int PurchaseFrequencyId { get; private set; }
        public DateOnly StartDate { get; private set; }
        public DateOnly? EndDate { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string? CreatedBy { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public string? UpdatedBy { get; private set; }

        internal CustomerProduct(
            int productId,
            int unitOfMeasureId,
            decimal quantity,
            int purchaseFrequencyId,
            DateOnly startDate,
            DateOnly? endDate = null,
            bool isActive = true,
            string? createdBy = null)
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

            ProductId = productId;
            UnitOfMeasureId = unitOfMeasureId;
            Quantity = quantity;
            PurchaseFrequencyId = purchaseFrequencyId;
            StartDate = startDate;
            EndDate = endDate;
            IsActive = isActive;
            CreatedAt = DateTime.UtcNow;
            CreatedBy = createdBy;
        }

        internal void UpdateQuantity(decimal quantity, string? updatedBy = null)
        {
            if (quantity <= 0)
                throw new InvalidCustomerProductException("Quantity must be greater than 0.");

            Quantity = quantity;
            Touch(updatedBy);
        }

        internal void UpdateUnitOfMeasure(int unitOfMeasureId, string? updatedBy = null)
        {
            if (unitOfMeasureId <= 0)
                throw new InvalidCustomerProductException("Unit of Measure ID must be greater than 0.");

            UnitOfMeasureId = unitOfMeasureId;
            Touch(updatedBy);
        }

        internal void UpdatePurchaseFrequency(int frequencyId, string? updatedBy = null)
        {
            if (frequencyId <= 0)
                throw new InvalidCustomerProductException("Purchase Frequency ID must be greater than 0.");

            PurchaseFrequencyId = frequencyId;
            Touch(updatedBy);
        }

        internal void SetEndDate(DateOnly? endDate, string? updatedBy = null)
        {
            if (endDate.HasValue && endDate.Value < StartDate)
                throw new InvalidCustomerProductException("End date cannot be before start date.");

            EndDate = endDate;
            Touch(updatedBy);
        }

        internal void Deactivate(string? updatedBy = null)
        {
            IsActive = false;
            Touch(updatedBy);
        }

        internal void Activate(string? updatedBy = null)
        {
            IsActive = true;
            Touch(updatedBy);
        }

        internal void SetId(int id)
        {
            if (id <= 0)
                throw new InvalidCustomerProductException("ID must be greater than 0.");
            Id = id;
        }

        private void Touch(string? updatedBy)
        {
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = updatedBy;
        }

    }
}
