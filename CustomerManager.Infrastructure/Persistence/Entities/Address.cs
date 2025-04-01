using System;
using System.Collections.Generic;

namespace CustomerManager.Infrastructure.Persistence.Entities;

public partial class Address
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string Street { get; set; } = null!;

    public string BuildingNumber { get; set; } = null!;

    public string? FlatNumber { get; set; }

    public string City { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
