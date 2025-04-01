using System;
using System.Collections.Generic;

namespace CustomerManager.Infrastructure.Persistence.Entities;

public partial class ProductCategory
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
