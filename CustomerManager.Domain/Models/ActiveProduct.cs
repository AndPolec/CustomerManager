using CustomerManager.Domain.Enums;

namespace CustomerManager.Domain.Models
{
    public class ActiveProduct
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Unit Unit { get; set; }
        public int ReorderPeriod { get; set; }
    }
}