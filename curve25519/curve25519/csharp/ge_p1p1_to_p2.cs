namespace org.whispersystems.curve25519.csharp
{

    public class Ge_p1p1_to_p2
    {

        //CONVERT #include "ge.h"

        /*
        r = p
        */

        public static void ge_p1p1_to_p2(Ge_p2 r, Ge_p1p1 p)
        {
            Fe_mul.fe_mul(r.X, p.X, p.T);
            Fe_mul.fe_mul(r.Y, p.Y, p.Z);
            Fe_mul.fe_mul(r.Z, p.Z, p.T);
        }


    }
}