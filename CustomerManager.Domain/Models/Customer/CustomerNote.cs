using CustomerManager.Domain.Common.BaseTypes;
using CustomerManager.Domain.Models.Customer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.Customer
{
    public class CustomerNote: AuditableEntity
    {
        public int Id { get; private set; }
        public string Note { get; private set; }
       
        internal CustomerNote(string note, string createdBy)
        {
            if (String.IsNullOrWhiteSpace(note))
                throw new InvalidCustomerNoteException("Note cannot be empty.");

            if (String.IsNullOrWhiteSpace(createdBy))
                throw new InvalidCustomerNoteException("CreatedBy is required.");

            Note = note;
            SetCreated(createdBy);
        }

        internal void Update(string note, string updatedBy)
        {
            if (String.IsNullOrWhiteSpace(note))
                throw new InvalidCustomerNoteException("Note cannot be empty.");

            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new InvalidCustomerNoteException("UpdatedBy is required.");

            if (!string.Equals(updatedBy,CreatedBy, StringComparison.Ordinal))
                throw new CustomerNoteAccessDeniedException("Only the author can update this note.");

            Note = note;
            Touch(updatedBy);
        }

        internal void SetId(int id)
        {
            if (id <= 0)
                throw new InvalidCustomerNoteException("ID must be greater than 0.");
            Id = id;
        }
    }
}
