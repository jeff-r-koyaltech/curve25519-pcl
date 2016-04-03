namespace org.whispersystems.curve25519.csharp {

    public interface Sha512 {

        void calculateDigest(byte[] digestOut, byte[] inData, long length);

    }
}