
namespace org.whispersystems.curve25519.csharp
{

    public class Ge_cached
    {

        public int[] YplusX;
        public int[] YminusX;
        public int[] Z;
        public int[] T2d;

        public Ge_cached()
        {
            YplusX = new int[10];
            YminusX = new int[10];
            Z = new int[10];
            T2d = new int[10];
        }
    }

}