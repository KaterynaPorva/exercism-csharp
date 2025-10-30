using System;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        if (operation == null)
            throw new ArgumentNullException(nameof(operation));

        if (operation == "")
            throw new ArgumentException("Operation cannot be empty.", nameof(operation));

        try
        {
            int result;

            switch (operation)
            {
                case "+":
                    result = operand1 + operand2;
                    break;

                case "*":
                    result = operand1 * operand2;
                    break;

                case "/":
                    if (operand2 == 0)
                        return "Division by zero is not allowed.";
                    result = operand1 / operand2;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), "Invalid operation symbol.");
            }

            return $"{operand1} {operation} {operand2} = {result}";
        }
        catch (DivideByZeroException)
        {
            return "Division by zero is not allowed.";
        }
    }
}
