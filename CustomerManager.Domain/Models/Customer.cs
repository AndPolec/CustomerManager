using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerManager.Domain.Enums;

namespace CustomerManager.Domain.Models
{
    public class Customer : AuditableModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<ContactPerson> ContactPersons { get; set; }
        public ClientType ClientType { get; set; }
        public FoodServiceType FoodServiceType { get; set; }
        public CustomerSalesData SalesData { get; set; }
        public List<SalesCall> SalesCalls { get; set; }
        public int AccountManagerId { get; set; }
        public bool IsActive { get; set; }
    }
}
