using System;
using System.Collections.Generic;

namespace CustomerManager.Infrastructure.Persistence.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Sku { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int CategoryId { get; set; }

    public int BaseUnitId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual UnitOfMeasure BaseUnit { get; set; } = null!;

    public virtual ProductCategory Category { get; set; } = null!;

    public virtual ICollection<CustomerProduct> CustomerProducts { get; set; } = new List<CustomerProduct>();

    public virtual ICollection<ProductUnit> ProductUnits { get; set; } = new List<ProductUnit>();

    public virtual ICollection<SalesCallProduct> SalesCallProducts { get; set; } = new List<SalesCallProduct>();

    public virtual ICollection<ProductTag> Tags { get; set; } = new List<ProductTag>();
}
