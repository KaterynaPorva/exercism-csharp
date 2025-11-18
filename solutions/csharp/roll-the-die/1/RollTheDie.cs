using System;

public class Player
{
    private static readonly Random Rng = new Random();

    public int RollDie()
    {
        return Rng.Next(1, 19); 
    }

    public double GenerateSpellStrength()
    {
        return Rng.NextDouble() * 100.0;
    }
}