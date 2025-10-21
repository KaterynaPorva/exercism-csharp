using System;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        var builder = new StringBuilder();
        bool makeUpper = false;

        foreach (char c in identifier)
        {
            if (c == ' ')
            {
                builder.Append('_');
            }
            else if (char.IsControl(c))
            {
                builder.Append("CTRL");
            }
            else if (c == '-')
            {
                makeUpper = true;
            }
            else if (char.IsLetter(c))
            {
                if (c >= 'α' && c <= 'ω')
                    continue;

                builder.Append(makeUpper ? char.ToUpperInvariant(c) : c);
                makeUpper = false;
            }
        }

        return builder.ToString();
    }
}
