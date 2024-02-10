namespace CustomerManager.Domain.Models
{
    public class AuditableModel
    {
        public DateTime CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
    }
}