using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Customer
{
    public class ContactPerson
    {
        public int Id { get; private set; }

        public string FirstName { get; private set; } 

        public string LastName { get; private set; }

        public string? PhoneNumber { get; private set; }

        public string? Email { get; private set; }

        public int CustomerId { get; private set; }

        public int? RoleId { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public string? CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public string? UpdatedBy { get; private set; }

        internal ContactPerson()
        {
            
        }
    }
}
