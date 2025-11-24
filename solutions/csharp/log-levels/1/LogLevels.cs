static class LogLine
{
    public static string Message(string logLine)
    {
        int colonIndex = logLine.IndexOf(":");
        string message = logLine.Substring(colonIndex + 1);
        return message.Trim(); 
    }

    public static string LogLevel(string logLine)
    {
        int start = logLine.IndexOf("[") + 1;
        int end = logLine.IndexOf("]");

        string level = logLine.Substring(start, end - start);
        return level.ToLower();
    }

    public static string Reformat(string logLine)
    {
        string message = Message(logLine);
        string level = LogLevel(logLine);
        return $"{message} ({level})";
    }
}

