using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerManager.Domain.Enums;

namespace CustomerManager.Domain.Models
{
    public class User : AuditableModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType UserType { get; set; }
        public List<Customer>? Customers { get; set; }
        public List<SalesCall>? SalesCalls { get; set; }
    }
}
