using CustomerManager.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.UserProfile.Exceptions
{
    public class InvalidUserProfileException: DomainException
    {
        public InvalidUserProfileException(string? message) : base(message)
        {
        }
    }
}
