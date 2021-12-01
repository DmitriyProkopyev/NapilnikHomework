using System;
using Encoding = System.Text.Encoding;
using MD5 = System.Security.Cryptography.MD5;

public class MD5Calculator : HashCalculator
{
    public MD5Calculator(Func<Order, string> origin) : base(origin) { }

    protected override int CalculateHash(string input)
    {
        var md5 = MD5.Create();

        var inputBytes = Encoding.ASCII.GetBytes(input);
        var hash = md5.ComputeHash(inputBytes);

        return BitConverter.ToInt32(hash, 0);
    }
}
