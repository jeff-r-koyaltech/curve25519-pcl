namespace org.whispersystems.curve25519.csharp
{

    public class Ge_p2_0
    {

        //CONVERT #include "ge.h"

        public static void ge_p2_0(Ge_p2 h)
        {
            Fe_0.fe_0(h.X);
            Fe_1.fe_1(h.Y);
            Fe_1.fe_1(h.Z);
        }


    }
}