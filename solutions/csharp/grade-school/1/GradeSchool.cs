using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private readonly Dictionary<int, HashSet<string>> _school
        = new Dictionary<int, HashSet<string>>();

    public bool Add(string student, int grade)
    {
        if (_school.Values.Any(set => set.Contains(student)))
        {
            return false;
        }

        if (!_school.ContainsKey(grade))
        {
            _school[grade] = new HashSet<string>();
        }

        _school[grade].Add(student);
        return true;
    }

    public IEnumerable<string> Roster()
    {
        return _school
            .OrderBy(g => g.Key)
            .SelectMany(g => g.Value.OrderBy(s => s));
    }

    public IEnumerable<string> Grade(int grade)
    {
        if (!_school.ContainsKey(grade))
        {
            return Enumerable.Empty<string>();
        }

        return _school[grade].OrderBy(s => s);
    }
}