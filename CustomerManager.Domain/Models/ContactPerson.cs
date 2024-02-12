namespace CustomerManager.Domain.Models
{
    public class ContactPerson : AuditableModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ContactRole Role { get; set; }
        public int CustomerId { get; set; }
    }
}