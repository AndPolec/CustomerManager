using CustomerManager.Application.DTOs.Customer;
using CustomerManager.Application.Interfaces;
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

        public CustomerService(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<List<CustomerForListDTO>> GetAllCustomersForListAsync(int customerOwnerId, string searchString, int pageSize, int pageNumber)
        {
            var customers = await _customerRepo.GetAllAsync(customerOwnerId, searchString, pageSize, pageNumber);
            var customersDTO = new List<CustomerForListDTO>();
            foreach (var customer in customers)
            {
                var customerDTO = new CustomerForListDTO()
                {
                    Id = customer.Id,
                    Email = customer.Email,
                    Name = customer.Name,
                    PhoneNumber = customer.PhoneNumber,
                    Address = new AddressDTO()
                    {
                        Id = customer.Address.Id,
                        BuildingNumber = customer.Address.BuildingNumber,
                        FlatNumber = customer.Address.FlatNumber,
                        Street = customer.Address.Street,
                        City = customer.Address.City,
                        ZipCode = customer.Address.ZipCode
                    }
                };
                customersDTO.Add(customerDTO);
            }

            return customersDTO;
        }
    }
}
