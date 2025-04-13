using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Common.Validators
{
    internal class PhoneNumberValidator
    {
        internal static string CleanAndValidate(string phoneNumber, Func<Exception> onInvalid)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw onInvalid();

            var cleaned = phoneNumber.Replace(" ", "").Replace("-", "");

            if (!IsValid(cleaned))
                throw onInvalid();

            return cleaned;
        }

        internal static bool IsValid(string phone)
        {
            return Regex.IsMatch(phone, @"^\+?[1-9]\d{6,14}$");
        }
    }
}
