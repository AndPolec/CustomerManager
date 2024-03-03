using CustomerManager.Application.DTOs.Customer;

namespace CustomerManager.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerForListDTO>> GetAllCustomersForListAsync(int customerOwnerId, string searchString, int pageSize, int pageNumber);
    }
}