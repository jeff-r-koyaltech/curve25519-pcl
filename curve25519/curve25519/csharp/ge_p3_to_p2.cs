namespace org.whispersystems.curve25519.csharp
{

    public class Ge_p3_to_p2
    {

        //CONVERT #include "ge.h"

        /*
        r = p
        */

        public static void ge_p3_to_p2(Ge_p2 r, Ge_p3 p)
        {
            Fe_copy.fe_copy(r.X, p.X);
            Fe_copy.fe_copy(r.Y, p.Y);
            Fe_copy.fe_copy(r.Z, p.Z);
        }
    }
}