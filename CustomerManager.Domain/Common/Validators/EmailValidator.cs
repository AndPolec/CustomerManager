using CustomerManager.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Common.Validators
{
    internal class EmailValidator
    {
        internal static string CleanAndValidate(string email, Func<Exception> onInvalid)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw onInvalid();

            var trimmed = email.Trim();

            if (!IsValid(trimmed))
                throw onInvalid();

            return trimmed;
        }

        private static bool IsValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var trimmed = email.Trim();
                var addr = new MailAddress(trimmed);
                return addr.Address == trimmed;
            }
            catch
            {
                return false;
            }
        }
    }
}
