using System;
using System.Linq;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        var digits = new string(phoneNumber.Where(char.IsDigit).ToArray());

        if (digits.Length == 11 && digits[0] == '1')
        {
            digits = digits.Substring(1);
        }

        if (digits.Length != 10)
        {
            throw new ArgumentException("Invalid number of digits");
        }

        if (digits[0] == '0' || digits[0] == '1')
        {
            throw new ArgumentException("Invalid area code");
        }

        if (digits[3] == '0' || digits[3] == '1')
        {
            throw new ArgumentException("Invalid exchange code");
        }

        return digits;
    }
}