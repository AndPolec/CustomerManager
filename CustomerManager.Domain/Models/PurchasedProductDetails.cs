using CustomerManager.Domain.Enums;

namespace CustomerManager.Domain.Models
{
    public class PurchasedProductDetails : AuditableModel
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public UnitOfMeasure UOM { get; set; }
        public PurchaseFrequency PurchaseFrequency { get; set; }
        public DateTime StartPurchaseDate { get; set; }
        public DateTime EndPurchaseDate { get; set; }
        public bool IsActive { get; set; }
        public int CustomerSalesDataId { get; set; }
    }
}