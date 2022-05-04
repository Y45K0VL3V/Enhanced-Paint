using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace yakov.OOP.EnhancedPaint.Plugins.Interfaces
{
    public interface ICrypter
    {
        byte[] Encrypt(BigInteger publicKeyN, BigInteger publicKeyB, byte[] inputData);

        byte[] Decrypt(BigInteger privateKeyQ, BigInteger privateKeyP, BigInteger publicKeyB, byte[] encryptedData);
    }
}
