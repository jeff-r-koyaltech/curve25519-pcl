namespace org.whispersystems.curve25519.csharp
{

    public class Arrays
    {
        /**
         * Assigns the specified byte value to each element of the specified array
         * of bytes.
         *
         * @param a the array to be filled
         * @param val the value to be stored in all elements of the array
         */
        public static void fill(byte[] a, byte val)
        {
            for (int i = 0, len = a.Length; i < len; i++)
                a[i] = val;
        }

    }
}