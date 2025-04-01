using System;
using System.Collections.Generic;

namespace CustomerManager.Infrastructure.Persistence.Entities;

public partial class CustomerNote
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string? Note { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
