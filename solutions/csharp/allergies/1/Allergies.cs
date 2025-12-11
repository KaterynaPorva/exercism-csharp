public enum Allergen
{
    Eggs,
    Peanuts,
    Shellfish,
    Strawberries,
    Tomatoes,
    Chocolate,
    Pollen,
    Cats
}

public class Allergies
{
    private readonly int _mask;

    public Allergies(int mask)
    {
        _mask = mask;
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        int value = 1 << (int)allergen;   // отримуємо 2^n
        return (_mask & value) != 0;      // перевіряємо відповідний біт
    }

    public Allergen[] List()
    {
        var list = new List<Allergen>();

        foreach (Allergen a in Enum.GetValues(typeof(Allergen)))
        {
            if (IsAllergicTo(a))
            {
                list.Add(a);
            }
        }

        return list.ToArray();
    }
}