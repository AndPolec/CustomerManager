using System;
using System.Collections.Generic;

namespace CustomerManager.Infrastructure.Persistence.Entities;

public partial class Customer
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? CompanyName { get; set; }

    public int CustomerTypeId { get; set; }

    public int CustomerPotentialId { get; set; }

    public int CustomerActivityId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<ContactPerson> ContactPeople { get; set; } = new List<ContactPerson>();

    public virtual CustomerActivity CustomerActivity { get; set; } = null!;

    public virtual ICollection<CustomerNote> CustomerNotes { get; set; } = new List<CustomerNote>();

    public virtual CustomerPotential CustomerPotential { get; set; } = null!;

    public virtual ICollection<CustomerProduct> CustomerProducts { get; set; } = new List<CustomerProduct>();

    public virtual CustomerType CustomerType { get; set; } = null!;

    public virtual ICollection<SalesCall> SalesCalls { get; set; } = new List<SalesCall>();
}
