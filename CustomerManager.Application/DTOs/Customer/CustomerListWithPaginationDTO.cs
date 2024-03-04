using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Application.DTOs.Customer
{
    public class CustomerListWithPaginationDTO
    {
        public List<CustomerForListDTO> Customers { get; set; }
        public string SearchString { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalCustomers { get; set; }
    }
}
