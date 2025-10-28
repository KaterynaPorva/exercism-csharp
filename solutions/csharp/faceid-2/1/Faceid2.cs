using System;
using System.Collections.Generic;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public override bool Equals(object obj)
    {
        if (obj is not FacialFeatures other) return false;
        return EyeColor == other.EyeColor && PhiltrumWidth == other.PhiltrumWidth;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(EyeColor, PhiltrumWidth);
    }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public override bool Equals(object obj)
    {
        if (obj is not Identity other) return false;
        return Email == other.Email && Equals(FacialFeatures, other.FacialFeatures);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Email, FacialFeatures);
    }
}

public class Authenticator
{
    private HashSet<Identity> _registered = new HashSet<Identity>();

    private static readonly Identity AdminIdentity = new Identity(
        "admin@exerc.ism",
        new FacialFeatures("green", 0.9m)
    );

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceB);
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        return ReferenceEquals(identityA, identityB);
    }

    public bool IsAdmin(Identity identity)
    {
        return identity.Equals(AdminIdentity);
    }

    public bool Register(Identity identity)
    {
        return _registered.Add(identity);
    }

    public bool IsRegistered(Identity identity)
    {
        return _registered.Contains(identity);
    }
}

