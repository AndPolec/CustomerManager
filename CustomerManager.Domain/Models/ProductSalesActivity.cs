using CustomerManager.Domain.Enums;

namespace CustomerManager.Domain.Models
{
    public class ProductSalesActivity
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public SalesActivityType SalesActivity { get; set; }
        public SalesActivityResult SalesActivityResult { get; set; }
        public int? Quantity { get; set; }
        public UnitOfMeasure? UOM { get; set; }
        public PurchaseFrequency? PurchaseFrequency { get; set; }
    }
}