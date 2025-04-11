using CustomerManager.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Customer.Exceptions
{
    public class InvalidAddressException: DomainException
    {
        public InvalidAddressException(string? message): base(message)
        {
            
        }
    }
}
