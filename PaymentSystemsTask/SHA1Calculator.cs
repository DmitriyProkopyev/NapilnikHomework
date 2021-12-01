using System;
using Encoding = System.Text.Encoding;
using SHA1 = System.Security.Cryptography.SHA1;

public class SHA1Calculator : HashCalculator
{
    public SHA1Calculator(Func<Order, string> origin) : base(origin) { }

    protected override int CalculateHash(string input)
    {
        var sha1 = SHA1.Create();

        var inputBytes = Encoding.ASCII.GetBytes(input);
        var hash = sha1.ComputeHash(inputBytes);

        return BitConverter.ToInt32(hash, 0);
    }
}
