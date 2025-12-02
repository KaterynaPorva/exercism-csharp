using System;
using System.Collections.Generic;
using System.Linq;

public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        var dominoList = dominoes.ToList();

        if (!dominoList.Any())
            return true;

        var adjacency = new Dictionary<int, List<int>>();
        var degrees = new Dictionary<int, int>();

        foreach (var (a, b) in dominoList)
        {
            if (!adjacency.ContainsKey(a)) adjacency[a] = new List<int>();
            if (!adjacency.ContainsKey(b)) adjacency[b] = new List<int>();
            
            if (!degrees.ContainsKey(a)) degrees[a] = 0;
            if (!degrees.ContainsKey(b)) degrees[b] = 0;

            adjacency[a].Add(b);
            adjacency[b].Add(a);

            degrees[a]++;
            degrees[b]++;
        }

        foreach (var degree in degrees.Values)
        {
            if (degree % 2 != 0)
            {
                return false; 
            }
        }

        
        var startNode = dominoList[0].Item1;
        var visited = new HashSet<int>();
        var stack = new Stack<int>();

        stack.Push(startNode);
        visited.Add(startNode);

        while (stack.Count > 0)
        {
            var current = stack.Pop();

            if (adjacency.ContainsKey(current))
            {
                foreach (var neighbor in adjacency[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        stack.Push(neighbor);
                    }
                }
            }
        }

        return visited.Count == degrees.Count;
    }
}