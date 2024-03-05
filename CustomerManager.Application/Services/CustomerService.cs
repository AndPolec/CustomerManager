using CustomerManager.Application.DTOs.Customer;
using CustomerManager.Application.Interfaces;
using CustomerManager.Application.Mappers;
using CustomerManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly ICustomerMapper _customerMapper;

        public CustomerService(ICustomerRepository customerRepo, ICustomerMapper customerMapper)
        {
            _customerRepo = customerRepo;
            _customerMapper = customerMapper;
        }

        public async Task<CustomerListDTO> GetAllCustomersForListAsync(int customerOwnerId, string searchString, int pageSize, int pageNumber)
        {
            var result = await _customerRepo.GetAllAsync(customerOwnerId, searchString, pageSize, pageNumber);
            var customerListDto = new CustomerListDTO()
            {
                Customers = _customerMapper.MapToCustomerForListDTO(result.Customers),
                SearchString = searchString,
                PageSize = pageSize,
                PageNumber = pageNumber,
                TotalPages = (int)Math.Ceiling((double)result.TotalCustomersFound/pageSize),
                TotalCustomersFound = result.TotalCustomersFound
            };

            return customerListDto;
        }
    }
}
