﻿using CustomerManager.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Customer.Exceptions
{
    public class CustomerNoteAccessDeniedException: DomainException
    {
        public CustomerNoteAccessDeniedException(string? message) : base(message)
        {
        }
    }
}
