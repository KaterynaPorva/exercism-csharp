using System;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    private static void EnsureSameCurrency(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency)
            throw new ArgumentException("Currency mismatch");
    }

    public static bool operator ==(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return a.amount == b.amount;
    }

    public static bool operator !=(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return a.amount != b.amount;
    }

    public override bool Equals(object? obj)
    {
        if (obj is CurrencyAmount other)
        {
            EnsureSameCurrency(this, other);
            return this.amount == other.amount;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(amount, currency);
    }

    public static bool operator >(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return a.amount > b.amount;
    }

    public static bool operator <(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return a.amount < b.amount;
    }

    public static bool operator >=(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return a.amount >= b.amount;
    }

    public static bool operator <=(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return a.amount <= b.amount;
    }

    public static CurrencyAmount operator +(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return new CurrencyAmount(a.amount + b.amount, a.currency);
    }

    public static CurrencyAmount operator -(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return new CurrencyAmount(a.amount - b.amount, a.currency);
    }

    public static CurrencyAmount operator *(CurrencyAmount a, decimal multiplier)
    {
        return new CurrencyAmount(a.amount * multiplier, a.currency);
    }

    public static CurrencyAmount operator /(CurrencyAmount a, decimal divisor)
    {
        return new CurrencyAmount(a.amount / divisor, a.currency);
    }

    public static explicit operator double(CurrencyAmount a)
    {
        return (double)a.amount;
    }

    public static implicit operator decimal(CurrencyAmount a)
    {
        return a.amount;
    }

    public override string ToString()
    {
        return $"{{{amount}, {currency}}}";
    }
}
