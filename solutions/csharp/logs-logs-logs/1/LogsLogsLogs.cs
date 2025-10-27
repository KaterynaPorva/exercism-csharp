enum LogLevel
{
    Unknown,
    Trace,
    Debug,
    Info,
    Warning,
    Error,
    Fatal
}

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        string code = logLine.Split(':')[0].Trim('[', ']');

        return code switch
        {
            "TRC" => LogLevel.Trace,
            "DBG" => LogLevel.Debug,
            "INF" => LogLevel.Info,
            "WRN" => LogLevel.Warning,
            "ERR" => LogLevel.Error,
            "FTL" => LogLevel.Fatal,
            _ => LogLevel.Unknown
        };
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        int code = logLevel switch
        {
            LogLevel.Unknown => 0,
            LogLevel.Trace => 1,
            LogLevel.Debug => 2,
            LogLevel.Info => 4,
            LogLevel.Warning => 5,
            LogLevel.Error => 6,
            LogLevel.Fatal => 42,
            _ => 0
        };

        return $"{code}:{message}";
    }
}
