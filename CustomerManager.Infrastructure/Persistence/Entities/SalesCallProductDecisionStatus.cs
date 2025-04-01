using System;
using System.Collections.Generic;

namespace CustomerManager.Infrastructure.Persistence.Entities;

public partial class SalesCallProductDecisionStatus
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public virtual ICollection<SalesCallProduct> SalesCallProducts { get; set; } = new List<SalesCallProduct>();
}
