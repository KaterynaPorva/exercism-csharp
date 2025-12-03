public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        string cleaned = number.Replace("-", "");

        if (cleaned.Length != 10)
            return false;

        int sum = 0;

        for (int i = 0; i < 10; i++)
        {
            char c = cleaned[i];
            int value;

            if (i == 9 && c == 'X')
            {
                value = 10;
            }
            else if (char.IsDigit(c))
            {
                value = c - '0';
            }
            else
            {
                return false;
            }

            sum += value * (10 - i);
        }

        return sum % 11 == 0;
    }
}
