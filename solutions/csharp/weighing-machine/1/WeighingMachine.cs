using System;

public class WeighingMachine
{
    public int Precision { get; }

    private double weight;

    public double Weight
    {
        get => weight;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(Weight), "Weight cannot be negative.");
            weight = value;
        }
    }

    public double TareAdjustment { get; set; } = 5.0;

    public string DisplayWeight
    {
        get
        {
            double displayWeight = weight - TareAdjustment;
            return displayWeight.ToString($"F{Precision}") + " kg";
        }
    }

    public WeighingMachine(int precision)
    {
        Precision = precision;
    }
}
