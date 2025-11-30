public static class FoodChain
{
    private static readonly string[] animals =
    {
        "fly",
        "spider",
        "bird",
        "cat",
        "dog",
        "goat",
        "cow",
        "horse"
    };

    private static readonly string[] animalComments =
    {
        "",
        "It wriggled and jiggled and tickled inside her.",
        "How absurd to swallow a bird!",
        "Imagine that, to swallow a cat!",
        "What a hog, to swallow a dog!",
        "Just opened her throat and swallowed a goat!",
        "I don't know how she swallowed a cow!",
        "She's dead, of course!"
    };

    public static string Recite(int verseNumber)
    {
        return Recite(verseNumber, verseNumber);
    }

    public static string Recite(int startVerse, int endVerse)
    {
        var verses = new List<string>();

        for (int i = startVerse - 1; i < endVerse; i++)
        {
            verses.Add(BuildVerse(i));

            if (i < endVerse - 1)
                verses.Add("");
        }

        return string.Join("\n", verses);
    }

    private static string BuildVerse(int index)
    {
        if (index == 7) 
        {
            return $"I know an old lady who swallowed a {animals[index]}.\n{animalComments[index]}";
        }

        var lines = new List<string>
        {
            $"I know an old lady who swallowed a {animals[index]}."
        };

        if (!string.IsNullOrEmpty(animalComments[index]))
        {
            lines.Add(animalComments[index]);
        }

        for (int i = index; i > 0; i--)
        {
            if (i == 1)
            {
                lines.Add("She swallowed the spider to catch the fly.");
            }
            else if (i == 2)
            {
                lines.Add("She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.");
            }
            else
            {
                lines.Add($"She swallowed the {animals[i]} to catch the {animals[i - 1]}.");
            }
        }

        lines.Add("I don't know why she swallowed the fly. Perhaps she'll die.");

        return string.Join("\n", lines);
    }
}
