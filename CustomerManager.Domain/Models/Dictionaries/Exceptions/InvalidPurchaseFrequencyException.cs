using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Dictionaries.Exceptions
{
    public class InvalidPurchaseFrequencyException: Exception
    {
        public InvalidPurchaseFrequencyException(string? message): base(message)
        {

        }
    }
}
