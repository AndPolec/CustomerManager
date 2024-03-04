using CustomerManager.Application.DTOs.Customer;
using CustomerManager.Domain.Models;

namespace CustomerManager.Application.Mappers
{
    public interface ICustomerMapper
    {
        List<CustomerForListDTO> MapToCustomerForListDTO(List<Customer> customers);
    }
}