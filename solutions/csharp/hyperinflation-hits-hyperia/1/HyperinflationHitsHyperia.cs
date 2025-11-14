using System;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try
        {
            checked
            {
                long result = @base * multiplier;
                return result.ToString();
            }
        }
        catch (OverflowException)
        {
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        float result = @base * multiplier;

        if (float.IsInfinity(result))
            return "*** Too Big ***";

        return result.ToString();
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try
        {
            checked
            {
                decimal result = salaryBase * multiplier;
                return result.ToString();
            }
        }
        catch (OverflowException)
        {
            return "*** Much Too Big ***";
        }
    }
}
