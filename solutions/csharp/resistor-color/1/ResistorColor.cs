public static class ResistorColor
{
    private static readonly string[] colorCodes =
    {
        "black",
        "brown",
        "red",
        "orange",
        "yellow",
        "green",
        "blue",
        "violet",
        "grey",
        "white"
    };

    public static int ColorCode(string color)
    {
        return Array.IndexOf(colorCodes, color);
    }

    public static string[] Colors()
    {
        return colorCodes;
    }
}
