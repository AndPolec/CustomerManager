using CustomerManager.Domain.Interfaces;
using CustomerManager.Domain.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IConfiguration _config;

        public CustomerRepository(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<(List<Customer> Customers, int TotalCustomersFound)> GetAllAsync(int customerOwnerId, string searchString, int pageSize, int pageNumber)
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString("Default"));

            var customers = await db.QueryAsync<Customer, Address, Customer>(
                sql: "dbo.spCustomer_GetAll",
                map: (customer, address) => { customer.Address = address; return customer; },
                param: new { CustomerOwnerId = customerOwnerId, SearchString = searchString, PageSize = pageSize, PageNumber = pageNumber },
                commandType: CommandType.StoredProcedure);

            var totalCustomersFound = await db.QuerySingleAsync<int>(
                sql: "dbo.spCustomer_GetTotalCountForSearch",
                param: new { CustomerOwnerId = customerOwnerId, SearchString = searchString },
                commandType: CommandType.StoredProcedure);

            return (customers.ToList(), totalCustomersFound);
        } 
    }
}
