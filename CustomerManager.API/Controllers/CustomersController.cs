using CustomerManager.Application.DTOs.Customer;
using CustomerManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerForListDTO>>> GetAll(string? searchString, int pageSize = 30, int pageNumber = 1)
        {
            var result = await _customerService.GetAllCustomersForListAsync(1, searchString ?? String.Empty, pageSize, pageNumber);
            return Ok(result);
        }

        
    }
}
