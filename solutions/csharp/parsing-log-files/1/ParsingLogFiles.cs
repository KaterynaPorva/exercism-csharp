using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class LogParser
{
    private static readonly string[] ValidPrefixes = { "[TRC]", "[DBG]", "[INF]", "[WRN]", "[ERR]", "[FTL]" };

    public bool IsValidLine(string line)
    {
        return ValidPrefixes.Any(prefix => line.StartsWith(prefix));
    }

    public string[] SplitLogLine(string line)
    {
        var pattern = @"<[\^*=\-]+>";
        return Regex.Split(line, pattern);
    }

    public int CountQuotedPasswords(string logLines)
    {
        var lines = logLines.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
        int count = 0;
        foreach (var line in lines)
        {
            var matches = Regex.Matches(line, @"""([^""]*password[^""]*)""", RegexOptions.IgnoreCase);
            count += matches.Count;
        }
        return count;
    }

    public string RemoveEndOfLineText(string line)
    {
        return Regex.Replace(line, @"end-of-line\d+", "");
    }

    public IEnumerable<string> ListLinesWithPasswords(string[] lines)
    {
        var result = new List<string>();

        foreach (var line in lines)
        {
            var match = Regex.Match(line, @"\bpassword\w+", RegexOptions.IgnoreCase);

            if (match.Success)
            {
                var pw = match.Value;
                result.Add($"{pw}: {line}");
            }
            else
            {
                result.Add($"--------: {line}");
            }
        }

        return result;
    }
}