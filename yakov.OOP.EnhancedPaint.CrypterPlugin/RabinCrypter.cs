﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using yakov.OOP.EnhancedPaint.Plugins;
using yakov.OOP.EnhancedPaint.Plugins.Interfaces;

namespace yakov.OOP.EnhancedPaint.CrypterPlugin
{
    [Plugin(PluginType.Crypter)]
    public class RabinCrypter : ICrypter
    {
        public string Path { get; set; }

        public byte[] Encrypt(BigInteger publicKeyN, BigInteger publicKeyB, byte[] inputData)
        {
            if (publicKeyN <= publicKeyB)
                throw new Exception("Public key B must be lower, than N");

            int maxEncryptedCapacity = publicKeyN.ToByteArray().Length;
            byte[] encryptedData = new byte[maxEncryptedCapacity * inputData.Length];

            for (int i = 0; i <= inputData.Length - 1; i++)
            {
                byte currByte = inputData[i];
                var encryptedNum = currByte * (currByte + publicKeyB) % publicKeyN;
                encryptedNum.ToByteArray().CopyTo(encryptedData, i * maxEncryptedCapacity);
            }

            return encryptedData;
        }

        private static long s_currEncryptedPos;

        public byte[] Decrypt(BigInteger privateKeyQ, BigInteger privateKeyP, BigInteger publicKeyB, byte[] encryptedData)
        {
            s_currEncryptedPos = 0;
            BigInteger publicKeyN = privateKeyP * privateKeyQ;

            int maxEncryptedCapacity = publicKeyN.ToByteArray().Length;
            var decryptedBytes = new byte[encryptedData.Length / maxEncryptedCapacity];

            for (long i = 0; i <= encryptedData.Length / maxEncryptedCapacity - 1; i++)
            {
                var currNumber = new BigInteger(GetNumberBytes(encryptedData, maxEncryptedCapacity));
                decryptedBytes[i] = DecryptNumber(currNumber, privateKeyQ, privateKeyP, publicKeyN, publicKeyB);
            }

            return decryptedBytes;
        }

        private static byte DecryptNumber(BigInteger number, BigInteger privateKeyQ, BigInteger privateKeyP, BigInteger publicKeyN, BigInteger publicKeyB)
        {
            BigInteger discriminant = (publicKeyB * publicKeyB + 4 * number) % publicKeyN;

            var mp = BigInteger.ModPow(discriminant, (privateKeyP + 1) / 4, privateKeyP);
            var mq = BigInteger.ModPow(discriminant, (privateKeyQ + 1) / 4, privateKeyQ);

            RabinHelpMath.ExtendedEuclidean(privateKeyP, privateKeyQ, out BigInteger yp, out BigInteger yq);

            var dResults = new BigInteger[4]
            {
                    (yp * privateKeyP * mq + yq * privateKeyQ * mp) % publicKeyN,
                    publicKeyN,
                    (yp * privateKeyP * mq - yq * privateKeyQ * mp) % publicKeyN,
                    publicKeyN
            };
            (dResults[1], dResults[3]) = (publicKeyN - dResults[0], publicKeyN - dResults[2]);

            var mResults = new BigInteger[4];
            for (int i = 0; i < 4; i++)
            {
                mResults[i] = ((dResults[i] - publicKeyB).IsEven) ? (dResults[i] - publicKeyB) / 2 % publicKeyN : (dResults[i] + publicKeyN - publicKeyB) / 2 % publicKeyN;
            }

            foreach (BigInteger currRes in mResults)
                if (currRes >= 0 && currRes <= 255)
                    return currRes.ToByteArray()[0];

            return 0;
        }

        // For decrypt only.
        private static byte[] GetNumberBytes(byte[] srcArray, int length)
        {
            var bytes = new byte[length];
            long endPos = s_currEncryptedPos + length - 1;

            try
            {
                while (s_currEncryptedPos <= endPos)
                    // Works properly, if length stays the same for full array.
                    bytes[s_currEncryptedPos % length] = srcArray[s_currEncryptedPos++];
            }
            catch { return new byte[length]; }

            return bytes;
        }

    }
}
