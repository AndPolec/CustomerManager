using CustomerManager.Application.DTOs.Customer;

namespace CustomerManager.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerListDTO> GetAllCustomersForListAsync(int customerOwnerId, string searchString, int pageSize, int pageNumber);
    }
}