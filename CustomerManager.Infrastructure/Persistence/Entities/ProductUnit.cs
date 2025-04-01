using System;
using System.Collections.Generic;

namespace CustomerManager.Infrastructure.Persistence.Entities;

public partial class ProductUnit
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int UnitId { get; set; }

    public decimal ConversionFactor { get; set; }

    public bool IsDefault { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual UnitOfMeasure Unit { get; set; } = null!;
}
