using curve25519.bc_crypto.digests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace org.whispersystems.curve25519
{
    public class BouncyCastleDotNETSha512Provider : org.whispersystems.curve25519.csharp.Sha512
    {
        public void calculateDigest(byte[] digestOut, byte[] inData, long length)
        {
            Sha512Digest d = new Sha512Digest();
            d.BlockUpdate(inData, 0, (int)length);
            d.DoFinal(digestOut, 0);
        }
    }
}
