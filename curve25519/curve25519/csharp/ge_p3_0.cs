namespace org.whispersystems.curve25519.csharp
{

    public class Ge_p3_0
    {

        //CONVERT #include "ge.h"

        public static void ge_p3_0(Ge_p3 h)
        {
            Fe_0.fe_0(h.X);
            Fe_1.fe_1(h.Y);
            Fe_1.fe_1(h.Z);
            Fe_0.fe_0(h.T);
        }
    }
}