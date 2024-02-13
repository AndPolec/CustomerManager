namespace CustomerManager.Domain.Models
{
    public class AuditableModel
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}