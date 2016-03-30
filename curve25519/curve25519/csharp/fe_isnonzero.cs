namespace org.whispersystems.curve25519.csharp
{

    public class Fe_isnonzero
    {

        //CONVERT #include "fe.h"
        //CONVERT #include "crypto_verify_32.crypto_verify_32.h"

        /*
        return 1 if f == 0
        return 0 if f != 0

        Preconditions:
           |f| bounded by 1.1*2^26,1.1*2^25,1.1*2^26,1.1*2^25,etc.
        */

        static readonly byte[] zero = new byte[32];

        public static int fe_isnonzero(int[] f)
        {
            byte[] s = new byte[32];
            Fe_tobytes.fe_tobytes(s, f);
            return Crypto_verify_32.crypto_verify_32(s, zero);
        }


    }
}