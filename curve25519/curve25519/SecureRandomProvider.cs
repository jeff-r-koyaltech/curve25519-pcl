namespace org.whispersystems.curve25519
{
    public interface SecureRandomProvider
    {
        void nextBytes(byte[] output);
        int nextInt(int maxValue);
    }
}