using CustomerManager.Domain.Models.Dictionaries;
using CustomerManager.Domain.Models.Product.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Product
{
    public class Product
    {
        public int Id { get; private set; }
        public string Sku { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public int CategoryId { get; private set; }
        public int BaseUnitId { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string? CreatedBy { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public string? UpdatedBy { get; private set; }

        private readonly List<ProductUnit> _units;
        public IReadOnlyCollection<ProductUnit> Units => _units.AsReadOnly();

        private readonly List<int> _tagsIds;
        public IReadOnlyCollection<int> Tags => _tagsIds.AsReadOnly();

        public Product(int id, string sku, string name,  int categoryId, int baseUnitId, string? description = null, bool isActive = true, string? createdBy = null)
        {
            if(string.IsNullOrWhiteSpace(sku))
                throw new InvalidProductException("SKU cannot be empty.");
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidProductException("Product name cannot be empty.");
            if (categoryId <= 0)
                throw new InvalidProductException("Category ID must be greater than zero.");
            if (baseUnitId <= 0)
                throw new InvalidProductException("Base unit ID must be greater than zero.");

            Id = id;
            Sku = sku;
            Name = name;
            CategoryId = categoryId;
            BaseUnitId = baseUnitId;
            Description = description;
            IsActive = isActive;
            CreatedAt = DateTime.UtcNow;
            CreatedBy = createdBy;
            _units = new();
            _tagsIds = new();
        }

        public void UpdateName(string name, string? updatedBy = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidProductException("Product name cannot be empty.");

            Name = name;
            Touch(updatedBy);
        }

        public void UpdateSku(string sku, string? updatedBy = null)
        {
            if (string.IsNullOrWhiteSpace(sku))
                throw new InvalidProductException("SKU cannot be empty.");

            Sku = sku;
            Touch(updatedBy);
        }

        public void UpdateDescription(string? description, string? updatedBy = null)
        {
            Description = description;
            Touch(updatedBy);
        }

        public void Activate(string? updatedBy = null)
        {
            IsActive = true;
            Touch(updatedBy);
        }

        public void Deactivate(string? updatedBy = null)
        {
            IsActive = false;
            Touch(updatedBy);
        }

        public void UpdateCategory(int categoryId, string? updatedBy = null)
        {
            if (categoryId <= 0)
                throw new InvalidProductException("Category ID must be greater than zero.");

            CategoryId = categoryId;
            Touch(updatedBy);
        }

        public void UpdateBaseUnit(int baseUnitId, string? updatedBy = null)
        {
            if (baseUnitId <= 0)
                throw new InvalidProductException("Base unit ID must be greater than zero.");

            BaseUnitId = baseUnitId;
            Touch(updatedBy);
        }

        public void AddUnit(int productId, int unitId, decimal conversionFactor, bool isDefault = false, string? createdBy = null)
        {
            if (_units.Any(u => u.UnitId == unitId))
                throw new InvalidProductException("Unit already exists on list.");

            if (isDefault && _units.Any(u => u.IsDefault))
                throw new InvalidProductException("A default unit already exists.");

            var unit = new ProductUnit(productId, unitId, conversionFactor, isDefault, createdBy);
            _units.Add(unit);
            Touch(createdBy);
        }

        public void RemoveUnit(int unitId, string? updatedBy = null)
        {
            var unit = _units.FirstOrDefault(u => u.UnitId == unitId);

            if (unit == null)
                throw new InvalidProductException("Unit not found.");

            if (unit.IsDefault)
                throw new InvalidProductException("Cannot remove default unit.");

            _units.Remove(unit);
            Touch(updatedBy);
        }

        public void SetDefaultUnit(int unitId, string? updatedBy = null)
        {
            if (!_units.Any(u => u.UnitId == unitId))
                throw new InvalidProductException("Unit not found.");

            foreach (var u in _units)
                u.SetDefault(u.UnitId == unitId);

            Touch(updatedBy);
        }

        public void AddTag(int tagId)
        {
            if (tagId <= 0)
                throw new InvalidProductException("Tag ID must be greater than zero.");
            if (_tagsIds.Contains(tagId))
                throw new InvalidProductException("Tag already exists.");

            _tagsIds.Add(tagId);
        }

        public void RemoveTag(int tagId)
        {
            if (!_tagsIds.Contains(tagId))
                throw new InvalidProductException("Tag is not in list.");

            _tagsIds.Remove(tagId);
        }

        private void Touch(string? updatedBy)
        {
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = updatedBy;
        }
    }
}
