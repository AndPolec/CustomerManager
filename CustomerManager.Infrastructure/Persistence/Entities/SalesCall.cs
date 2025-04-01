using System;
using System.Collections.Generic;

namespace CustomerManager.Infrastructure.Persistence.Entities;

public partial class SalesCall
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int? ContactPersonId { get; set; }

    public string UserId { get; set; } = null!;

    public DateTime? ScheduledDate { get; set; }

    public DateTime? VisitDate { get; set; }

    public int ContactTypeId { get; set; }

    public string? Location { get; set; }

    public string? Objective { get; set; }

    public string? Result { get; set; }

    public int StatusId { get; set; }

    public bool IsReminderSent { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual ContactPerson? ContactPerson { get; set; }

    public virtual SalesCallContactType ContactType { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<SalesCallProduct> SalesCallProducts { get; set; } = new List<SalesCallProduct>();

    public virtual SalesCallStatus Status { get; set; } = null!;
}
