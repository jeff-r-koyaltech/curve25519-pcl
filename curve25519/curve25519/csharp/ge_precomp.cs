
namespace org.whispersystems.curve25519.csharp
{

    public class Ge_precomp
    {

        public int[] yplusx;
        public int[] yminusx;
        public int[] xy2d;

        public Ge_precomp()
        {
            yplusx = new int[10];
            yminusx = new int[10];
            xy2d = new int[10];
        }

        public Ge_precomp(int[] new_yplusx, int[] new_yminusx,
                          int[] new_xy2d)
        {
            yplusx = new_yplusx;
            yminusx = new_yminusx;
            xy2d = new_xy2d;
        }
    }

}