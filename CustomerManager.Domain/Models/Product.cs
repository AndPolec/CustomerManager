namespace CustomerManager.Domain.Models
{
    public class Product : AuditableModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
    }
}