using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace curve25519Tests
{
    [TestClass]
    public class ConversionRelatedTests
    {
        public void TestExpectedDataTypeSizes()
        {
            //TODO: Check 64 bit 32 bit related sizes of uint, byte, etc?
            //Research online, then implement here
        }

        /// <summary>
        /// Basic equality / inequality sanity check
        /// </summary>
        [TestMethod]
        public void TestEquality_Ge_scalarmult_base()
        {
            byte b = 123;
            byte c = 255;
            byte d = 123;
            Assert.AreEqual<int>(0, org.whispersystems.curve25519.csharp.Ge_scalarmult_base.equal(b, c));
            Assert.AreEqual<int>(1, org.whispersystems.curve25519.csharp.Ge_scalarmult_base.equal(b, d));
        }

        /// <summary>
        /// This test checks if the standard (branch-using) way of comparing bytes is always equal with the branch-less equals method we use in curve25519.
        /// </summary>
        [TestMethod]
        public void TestEquality_Ge_scalarmult_base_both()
        {
            byte[,] test_cases = new byte[,]
            {
                {0, 0 },
                {0, 1 },
                {0, 255 },
                {255, 255 },
                {255, 0 },
                {255, 1 }
            };
            for (int i = 0; i < test_cases.GetLength(0); i++)
            {
                //branch-less equality
                int result = org.whispersystems.curve25519.csharp.Ge_scalarmult_base.equal(test_cases[i, 0], test_cases[i, 1]);

                int result2 = 0;
                if (test_cases[i, 0].CompareTo(test_cases[i, 1]) == 0)
                {
                    result2 = 1;
                }
                Assert.AreEqual<int>(result, result2);
            }
        }

        /// <summary>
        /// Verifies org.whispersystems.curve25519.csharp.Ge_scalarmult_base.negative properly detects negative numbers.
        /// </summary>
        [TestMethod]
        public void TestNegative_Ge_scalarmult_base_negative()
        {
            for (sbyte b = sbyte.MinValue; b < sbyte.MaxValue; b++)
            {
                int result = org.whispersystems.curve25519.csharp.Ge_scalarmult_base.negative(b);
                bool bResult2 = b < 0;
                int result2 = 0;
                if (bResult2)
                    result2 = 1;
                Assert.AreEqual<int>(result, result2);
            }
        }
    }
}
