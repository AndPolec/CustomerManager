using System;
using System.Collections.Generic;

namespace CustomerManager.Infrastructure.Persistence.Entities;

public partial class ContactPerson
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public int CustomerId { get; set; }

    public int? RoleId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ContactPersonRole? Role { get; set; }

    public virtual ICollection<SalesCall> SalesCalls { get; set; } = new List<SalesCall>();
}
