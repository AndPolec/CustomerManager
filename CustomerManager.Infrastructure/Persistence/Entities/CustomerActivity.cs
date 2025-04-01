using System;
using System.Collections.Generic;

namespace CustomerManager.Infrastructure.Persistence.Entities;

public partial class CustomerActivity
{
    public int Id { get; set; }

    public string ActivityName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
