﻿using CustomerManager.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Product.Exceptions
{
    public class InvalidProductCategoryException: DomainException
    {
        public InvalidProductCategoryException(string? message) : base(message)
        {
        }
    }
}
