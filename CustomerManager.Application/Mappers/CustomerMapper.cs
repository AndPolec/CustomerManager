using CustomerManager.Application.DTOs.Customer;
using CustomerManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Application.Mappers
{
    public class CustomerMapper : ICustomerMapper
    {
        public List<CustomerForListDTO> MapToCustomerForListDTO(List<Customer> customers)
        {
            var customerDTOs = new List<CustomerForListDTO>();
            foreach (var customer in customers)
            {
                var customerDTO = new CustomerForListDTO()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                    ClientType = customer.ClientType.ToString(),
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
                customerDTOs.Add(customerDTO);
            }

            return customerDTOs;
        }
    }
}
