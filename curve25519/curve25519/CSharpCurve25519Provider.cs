using org.whispersystems.curve25519;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curve25519
{
    /// <summary>
    /// Default PCL-compatible implementation of Curve25519
    /// </summary>
    public class CSharpCurve25519Provider : BaseCSharpCurve25519Provider
    {
        //Note: For now, I'm sticking with the Bouncy Castle SHA 512 implementation,
        //because it is pure C#. The PCLCrypto random provider is probably the only part
        //of this entire implementation that depends on something non-C# (see the
        //PCLCrypto wiki for an explanation). And there, it is better to trust the
        //operating system's random number generator, unless someone wants to contribute
        //a pure C# way to reliably produce random numbers. Such an implementation
        //would have to go through a lot of scrutiny before being used here.

        public CSharpCurve25519Provider() :
            base(new BouncyCastleDotNETSha512Provider(), new PCLSecureRandomProvider())
        {
        }

        public override bool isNative()
        {
            return false;
        }
    }
}
