using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Authenticator
{
    private class EyeColor
    {
        public const string Blue = "blue";
        public const string Green = "green";
        public const string Brown = "brown";
        public const string Hazel = "hazel";
        public const string Grey = "grey";
    }

    private readonly Identity admin;
    private readonly ReadOnlyDictionary<string, Identity> developers;

    public Authenticator(Identity admin)
    {
        this.admin = new Identity
        {
            Email = admin.Email,
            EyeColor = admin.EyeColor
        };

        var devs = new Dictionary<string, Identity>
        {
            ["Bertrand"] = new Identity
            {
                Email = "bert@ex.ism",
                EyeColor = EyeColor.Blue
            },
            ["Anders"] = new Identity
            {
                Email = "anders@ex.ism",
                EyeColor = EyeColor.Brown
            }
        };

        developers = new ReadOnlyDictionary<string, Identity>(devs);
    }

    public Identity Admin
    {
        get
        {
            return new Identity
            {
                Email = admin.Email,
                EyeColor = admin.EyeColor
            };
        }
    }

    public ReadOnlyDictionary<string, Identity> GetDevelopers()
    {
        return developers;
    }
}

public struct Identity
{
    public string Email { get; set; }
    public string EyeColor { get; set; }
}

