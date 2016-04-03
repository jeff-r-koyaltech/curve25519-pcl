using org.whispersystems.curve25519;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curve25519
{
    public class PCLSecureRandomProvider : SecureRandomProvider
    {
        public void nextBytes(byte[] output)
        {
            PCLCrypto.NetFxCrypto.RandomNumberGenerator.GetBytes(output);
        }

        public int nextInt(int maxValue)
        {
            int randomInt = (int)PCLCrypto.WinRTCrypto.CryptographicBuffer.GenerateRandomNumber() % maxValue;
            return randomInt;
        }
    }
}
