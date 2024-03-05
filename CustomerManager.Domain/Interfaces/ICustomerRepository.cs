using CustomerManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<(List<Customer> Customers, int TotalCustomersFound)> GetAllAsync(int customerOwnerId, string searchString, int pageSize, int pageNumber);
    }
}
