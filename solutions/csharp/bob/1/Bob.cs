public static class Bob
{
    public static string Response(string statement)
    {
        if (statement == null)
            statement = "";

        string trimmed = statement.Trim();

        if (trimmed == "")
            return "Fine. Be that way!";

        bool isQuestion = trimmed.EndsWith("?");
        bool hasLetters = trimmed.Any(char.IsLetter);
        bool isYelling = hasLetters && trimmed.ToUpper() == trimmed;

        if (isQuestion && isYelling)
            return "Calm down, I know what I'm doing!";

        if (isYelling)
            return "Whoa, chill out!";

        if (isQuestion)
            return "Sure.";

        return "Whatever.";
    }
}