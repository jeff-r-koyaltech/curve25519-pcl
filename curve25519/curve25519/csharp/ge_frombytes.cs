namespace org.whispersystems.curve25519.csharp {

    public class Ge_frombytes {

        //CONVERT #include "ge.h"

        static int[] d = {
//CONVERT #include "d.h"
-10913610,13857413,-15372611,6949391,114729,-8787816,-6275908,-3247719,-18696448,-12055116
};

        static int[] sqrtm1 = {
//CONVERT #include "sqrtm1.h"
-32595792,-7943725,9377950,3500415,12389472,-272473,-25146209,-2005654,326686,11406482
};

        public static int ge_frombytes_negate_vartime(Ge_p3 h, byte[] s)
        {
            int[] u = new int[10];
            int[] v = new int[10];
            int[] v3 = new int[10];
            int[] vxx = new int[10];
            int[] check = new int[10];

            Fe_frombytes.fe_frombytes(h.Y, s);
            Fe_1.fe_1(h.Z);
            Fe_sq.fe_sq(u, h.Y);
            Fe_mul.fe_mul(v, u, d);
            Fe_sub.fe_sub(u, u, h.Z);       /* u = y^2-1 */
            Fe_add.fe_add(v, v, h.Z);       /* v = dy^2+1 */

            Fe_sq.fe_sq(v3, v);
            Fe_mul.fe_mul(v3, v3, v);        /* v3 = v^3 */
            Fe_sq.fe_sq(h.X, v3);
            Fe_mul.fe_mul(h.X, h.X, v);
            Fe_mul.fe_mul(h.X, h.X, u);    /* x = uv^7 */

            Fe_pow22523.fe_pow22523(h.X, h.X); /* x = (uv^7)^((q-5)/8) */
            Fe_mul.fe_mul(h.X, h.X, v3);
            Fe_mul.fe_mul(h.X, h.X, u);    /* x = uv^3(uv^7)^((q-5)/8) */

            Fe_sq.fe_sq(vxx, h.X);
            Fe_mul.fe_mul(vxx, vxx, v);
            Fe_sub.fe_sub(check, vxx, u);    /* vx^2-u */
            if (Fe_isnonzero.fe_isnonzero(check) != 0) {
                Fe_add.fe_add(check, vxx, u);  /* vx^2+u */
                if (Fe_isnonzero.fe_isnonzero(check) != 0) return -1;
                Fe_mul.fe_mul(h.X, h.X, sqrtm1);
            }

            if (Fe_isnegative.fe_isnegative(h.X) == ((((uint)s[31]) >> 7) & 0x01)) {
                Fe_neg.fe_neg(h.X, h.X);
            }

            Fe_mul.fe_mul(h.T, h.X, h.Y);
            return 0;
        }


    }
}