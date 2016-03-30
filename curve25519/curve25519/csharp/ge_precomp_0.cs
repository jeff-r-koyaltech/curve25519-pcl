namespace org.whispersystems.curve25519.csharp
{

    public class Ge_precomp_0
    {

        //CONVERT #include "ge.h"

        public static void ge_precomp_0(Ge_precomp h)
        {
            Fe_1.fe_1(h.yplusx);
            Fe_1.fe_1(h.yminusx);
            Fe_0.fe_0(h.xy2d);
        }


    }
}