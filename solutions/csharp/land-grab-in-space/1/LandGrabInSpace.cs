public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot
{
    public Coord A { get; }
    public Coord B { get; }
    public Coord C { get; }
    public Coord D { get; }

    public Plot(Coord a, Coord b, Coord c, Coord d)
    {
        A = a;
        B = b;
        C = c;
        D = d;
    }

    public override bool Equals(object obj)
    {
        if (obj is Plot p)
        {
            return A.X == p.A.X && A.Y == p.A.Y &&
                   B.X == p.B.X && B.Y == p.B.Y &&
                   C.X == p.C.X && C.Y == p.C.Y &&
                   D.X == p.D.X && D.Y == p.D.Y;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(A, B, C, D);
    }

    public int LongestSide()
    {
        int w = Math.Abs(B.X - A.X);  
        int h = Math.Abs(C.Y - A.Y);  
        return Math.Max(w, h);
    }
}


public class ClaimsHandler
{
    private readonly List<Plot> _claims = new List<Plot>();
    private Plot? _lastClaim;

    public void StakeClaim(Plot plot)
    {
        _claims.Add(plot);
        _lastClaim = plot;
    }

    public bool IsClaimStaked(Plot plot)
    {
        return _claims.Contains(plot);
    }

    public bool IsLastClaim(Plot plot)
    {
        if (_lastClaim is null) return false;
        return plot.Equals(_lastClaim.Value);
    }

    public Plot GetClaimWithLongestSide()
    {
        if (_claims.Count == 0)
            throw new InvalidOperationException("No claims staked!");

        Plot longest = _claims[0];
        int max = longest.LongestSide();

        foreach (var claim in _claims)
        {
            int side = claim.LongestSide();
            if (side > max)
            {
                max = side;
                longest = claim;
            }
        }

        return longest;
    }
}
