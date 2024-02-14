namespace CustomerManager.Domain.Models
{
    public class Address : AuditableModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
    }
}