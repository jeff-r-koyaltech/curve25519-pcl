using org.whispersystems.curve25519.csharp;

namespace org.whispersystems.curve25519
{

    public abstract class Curve25519Provider
    {
        public const int PRIVATE_KEY_LEN = 32;

        public abstract byte[] calculateAgreement(byte[] ourPrivate, byte[] theirPublic);
        public abstract byte[] calculateSignature(byte[] random, byte[] privateKey, byte[] message);
        public abstract byte[] generatePrivateKey();
        public abstract byte[] generatePrivateKey(byte[] random);
        public abstract byte[] generatePublicKey(byte[] privateKey);
        public abstract byte[] getRandom(int length);
        public abstract bool isNative();
        public abstract void setRandomProvider(SecureRandomProvider provider);
        public abstract void setSha512Provider(Sha512 provider);
        public abstract bool verifySignature(byte[] publicKey, byte[] message, byte[] signature);
    }
}