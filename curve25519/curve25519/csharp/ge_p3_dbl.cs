namespace org.whispersystems.curve25519.csharp
{

    public class Ge_p3_dbl
    {

        //CONVERT #include "ge.h"

        /*
        r = 2 * p
        */

        public static void ge_p3_dbl(Ge_p1p1 r, Ge_p3 p)
        {
            Ge_p2 q = new Ge_p2();
            Ge_p3_to_p2.ge_p3_to_p2(q, p);
            Ge_p2_dbl.ge_p2_dbl(r, q);
        }
    }
}