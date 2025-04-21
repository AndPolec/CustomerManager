using CustomerManager.Domain.Common.BaseTypes;
using CustomerManager.Domain.Models.Customer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Customer
{
    public class Address: AuditableEntity
    {
        public int Id { get; private set; }
        public string Street { get; private set; }
        public string BuildingNumber { get; private set; }
        public string? FlatNumber { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string Country { get; private set; }

        internal Address(
           string street,
           string buildingNumber,
           string city,
           string zipCode,
           string country,
           string createdBy,
           string? flatNumber = null)
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

            if (string.IsNullOrWhiteSpace(createdBy))
                throw new InvalidAddressException("CreatedBy is required.");

            Street = street;
            BuildingNumber = buildingNumber;
            FlatNumber = flatNumber;
            City = city;
            ZipCode = zipCode;
            Country = country;
            SetCreated(createdBy);
        }

        internal void Update(
            string street,
            string buildingNumber,
            string city,
            string zipCode,
            string country,
            string updatedBy,
            string? flatNumber = null)
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

            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidAddressException("UpdatedBy is required.");

            Street = street;
            BuildingNumber = buildingNumber;
            FlatNumber = flatNumber;
            City = city;
            ZipCode = zipCode;
            Country = country;
            Touch(updatedBy);
        }

        internal void SetId(int id)
        {
            if (id <= 0)
                throw new InvalidAddressException("ID must be greater than 0.");

            Id = id;
        }
    }
}
