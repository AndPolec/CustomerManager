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
    public class Product: AuditableEntity
    {
        public int Id { get; private set; }
        public string Sku { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public int CategoryId { get; private set; }
        public int BaseUnitId { get; private set; }
        public bool IsActive { get; private set; }

        private readonly List<ProductUnit> _units;
        public IReadOnlyCollection<ProductUnit> Units => _units.AsReadOnly();

        private readonly List<int> _tagsIds;
        public IReadOnlyCollection<int> Tags => _tagsIds.AsReadOnly();

        public Product(string sku, string name, int categoryId, int baseUnitId, string createdBy, string? description = null, bool isActive = true)
        {
            if(string.IsNullOrWhiteSpace(sku))
                throw new InvalidProductException("SKU cannot be empty.");

            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidProductException("Product name cannot be empty.");

            if (categoryId <= 0)
                throw new InvalidProductException("Category ID must be greater than zero.");

            if (baseUnitId <= 0)
                throw new InvalidProductException("Base unit ID must be greater than zero.");

            if (string.IsNullOrWhiteSpace(createdBy))
                throw new InvalidProductException("CreatedBy is required.");

            Sku = sku;
            Name = name;
            CategoryId = categoryId;
            BaseUnitId = baseUnitId;
            Description = description;
            IsActive = isActive;
            _units = new();
            _tagsIds = new();
            SetCreated(createdBy);
        }

        public void UpdateName(string name, string updatedBy)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidProductException("Product name cannot be empty.");

            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidProductException("UpdatedBy is required.");

            Name = name;
            Touch(updatedBy);
        }

        public void UpdateSku(string sku, string updatedBy)
        {
            if (string.IsNullOrWhiteSpace(sku))
                throw new InvalidProductException("SKU cannot be empty.");

            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidProductException("UpdatedBy is required.");

            Sku = sku;
            Touch(updatedBy);
        }

        public void UpdateDescription(string? description, string updatedBy)
        {
            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidProductException("UpdatedBy is required.");

            Description = description;
            Touch(updatedBy);
        }

        public void Activate(string updatedBy)
        {
            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidProductException("UpdatedBy is required.");

            IsActive = true;
            Touch(updatedBy);
        }

        public void Deactivate(string updatedBy)
        {
            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidProductException("UpdatedBy is required.");

            IsActive = false;
            Touch(updatedBy);
        }

        public void UpdateCategory(int categoryId, string updatedBy)
        {
            if (categoryId <= 0)
                throw new InvalidProductException("Category ID must be greater than zero.");

            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidProductException("UpdatedBy is required.");

            CategoryId = categoryId;
            Touch(updatedBy);
        }

        public void UpdateBaseUnit(int baseUnitId, string updatedBy)
        {
            if (baseUnitId <= 0)
                throw new InvalidProductException("Base unit ID must be greater than zero.");

            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidProductException("UpdatedBy is required.");

            BaseUnitId = baseUnitId;
            Touch(updatedBy);
        }

        public void AddUnit(int productId, int unitId, decimal conversionFactor, string createdBy, bool isDefault = false)
        {
            if (_units.Any(u => u.UnitId == unitId))
                throw new InvalidProductException("Unit already exists on list.");

            if (isDefault && _units.Any(u => u.IsDefault))
                throw new InvalidProductException("A default unit already exists.");

            if (string.IsNullOrWhiteSpace(createdBy))
                throw new InvalidProductException("CreatedBy is required.");

            var unit = new ProductUnit(productId, unitId, conversionFactor, createdBy, isDefault);
            _units.Add(unit);
            Touch(createdBy);
        }

        public void RemoveUnit(int unitId, string updatedBy)
        {
            var unit = _units.FirstOrDefault(u => u.UnitId == unitId);

            if (unit == null)
                throw new InvalidProductException("Unit not found.");

            if (unit.IsDefault)
                throw new InvalidProductException("Cannot remove default unit.");

            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidProductException("UpdatedBy is required.");

            _units.Remove(unit);
            Touch(updatedBy);
        }

        public void SetDefaultUnit(int unitId, string updatedBy)
        {
            if (!_units.Any(u => u.UnitId == unitId))
                throw new InvalidProductException("Unit not found.");

            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidProductException("UpdatedBy is required.");

            foreach (var u in _units)
                u.SetDefault(u.UnitId == unitId, updatedBy);

            Touch(updatedBy);
        }

        public void AddTag(int tagId, string updatedBy)
        {
            if (tagId <= 0)
                throw new InvalidProductException("Tag ID must be greater than zero.");

            if (_tagsIds.Contains(tagId))
                throw new InvalidProductException("Tag already exists.");

            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidProductException("UpdatedBy is required.");

            _tagsIds.Add(tagId);
            Touch(updatedBy);
        }

        public void RemoveTag(int tagId, string updatedBy)
        {
            if (!_tagsIds.Contains(tagId))
                throw new InvalidProductException("Tag is not in list.");

            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidProductException("UpdatedBy is required.");

            _tagsIds.Remove(tagId);
            Touch(updatedBy);
        }

        internal void SetId(int id)
        {
            if (id <= 0)
                throw new InvalidProductException("ID must be greater than zero.");

            Id = id;
        }
    }
}
