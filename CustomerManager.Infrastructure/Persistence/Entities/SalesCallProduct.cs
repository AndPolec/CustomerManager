using System;
using System.Collections.Generic;

namespace CustomerManager.Infrastructure.Persistence.Entities;

public partial class SalesCallProduct
{
    public int Id { get; set; }

    public int SalesCallId { get; set; }

    public int ProductId { get; set; }

    public int UnitOfMeasureId { get; set; }

    public int SalesDecisionStatusId { get; set; }

    public decimal? EstimatedQuantity { get; set; }

    public int? PurchaseFrequencyId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public DateOnly? FollowUpDate { get; set; }

    public string? FollowUpNote { get; set; }

    public string? Note { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual PurchaseFrequency? PurchaseFrequency { get; set; }

    public virtual SalesCall SalesCall { get; set; } = null!;

    public virtual SalesCallProductDecisionStatus SalesDecisionStatus { get; set; } = null!;

    public virtual UnitOfMeasure UnitOfMeasure { get; set; } = null!;
}
