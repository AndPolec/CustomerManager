using System;
using System.Collections.Generic;

namespace CustomerManager.Infrastructure.Persistence.Entities;

public partial class PurchaseFrequency
{
    public int Id { get; set; }

    public string FrequencyName { get; set; } = null!;

    public int MultiplierInDays { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public virtual ICollection<CustomerProduct> CustomerProducts { get; set; } = new List<CustomerProduct>();

    public virtual ICollection<SalesCallProduct> SalesCallProducts { get; set; } = new List<SalesCallProduct>();
}
