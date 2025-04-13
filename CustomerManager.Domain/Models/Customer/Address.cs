using CustomerManager.Domain.Models.Customer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Customer
{
    public class Address
    {
        public int Id { get; private set; }
        public string Street { get; private set; }
        public string BuildingNumber { get; private set; } 
        public string? FlatNumber { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; } 
        public string Country { get; private set; } 
        public DateTime CreatedAt { get; private set; }
        public string? CreatedBy { get; private set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; private set; }

        internal Address(
           string street,
           string buildingNumber,
           string city,
           string zipCode,
           string country,
           string? flatNumber = null,
           string? createdBy = null)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new InvalidAddressException("Street is required.");
            if (string.IsNullOrWhiteSpace(buildingNumber))
                throw new InvalidAddressException("Building number is required.");
            if (string.IsNullOrWhiteSpace(city))
                throw new InvalidAddressException("City is required.");
            if (string.IsNullOrWhiteSpace(zipCode))
                throw new InvalidAddressException("Zip code is required.");
            if (string.IsNullOrWhiteSpace(country))
                throw new InvalidAddressException("Country is required.");

            Street = street;
            BuildingNumber = buildingNumber;
            FlatNumber = flatNumber;
            City = city;
            ZipCode = zipCode;
            Country = country;
            CreatedAt = DateTime.UtcNow;
            CreatedBy = createdBy;
        }

        internal void Update(
            string street,
            string buildingNumber,
            string city,
            string zipCode,
            string country,
            string? flatNumber = null,
            string? updatedBy = null)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new InvalidAddressException("Street is required.");
            if (string.IsNullOrWhiteSpace(buildingNumber))
                throw new InvalidAddressException("Building number is required.");
            if (string.IsNullOrWhiteSpace(city))
                throw new InvalidAddressException("City is required.");
            if (string.IsNullOrWhiteSpace(zipCode))
                throw new InvalidAddressException("Zip code is required.");
            if (string.IsNullOrWhiteSpace(country))
                throw new InvalidAddressException("Country is required.");

            Street = street;
            BuildingNumber = buildingNumber;
            FlatNumber = flatNumber;
            City = city;
            ZipCode = zipCode;
            Country = country;
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = updatedBy;
        }

        internal void SetId(int id)
        {
            if (id <= 0)
                throw new InvalidAddressException("ID must be greater than 0.");

            Id = id;
        }
    }
}
