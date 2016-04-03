using System;

namespace org.whispersystems.curve25519
{

    public class NoSuchProviderException : Exception
    {

        private readonly Exception nested;

        public NoSuchProviderException(Exception e)
        {
            this.nested = e;
        }

        public NoSuchProviderException(string type) : base(type)
        {
            this.nested = null;
        }

        public Exception getNested()
        {
            return nested;
        }
    }
}