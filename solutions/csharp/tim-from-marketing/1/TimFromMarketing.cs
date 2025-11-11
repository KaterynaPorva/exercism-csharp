using System;

public static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string departmentLabel = department?.ToUpper() ?? "OWNER";

        if (id == null)
        {
            return $"{name} - {departmentLabel}";
        }

        return $"[{id}] - {name} - {departmentLabel}";
    }
}