using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Application.DTOs.Customer
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string? FlatNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
    }
}
