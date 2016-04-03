using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using System.Runtime.InteropServices.WindowsRuntime;

namespace curve25519Tests
{
    /// <summary>
    /// These tests cover functionality that was not a simple find/replace from Java to C#.
    /// </summary>
    [TestClass]
    public class ConversionRelatedTests
    {
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
        /// Verifies org.whispersystems.curve25519.csharp.Ge_scalarmult_base.negative properly detects negative numbers in a branch-less way.
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

        /// <summary>
        /// Make sure Bouncy Castle's Sha512 implementation matches with other hashing functions known to provide good values.
        /// </summary>
        [TestMethod]
        public void TestSha512ProviderConsistency()
        {
            byte [] message = System.Text.Encoding.UTF8.GetBytes(
                    "abcdefghbcdefghicDEFghijdefghijkefghijklfghijklmghijklmnhijklmnoijklmnopjklmnopqklmnopqrlmnopqrsmnopqrstnopqrstu");
            int digestExpectedLength = 64; //for SHA 512, this is the expected length

            //The Bouncy Castle way
            org.whispersystems.curve25519.BouncyCastleDotNETSha512Provider provider = new org.whispersystems.curve25519.BouncyCastleDotNETSha512Provider();
            byte[] digestActual = new byte[digestExpectedLength];
            provider.calculateDigest(digestActual, message, message.Length);

            //The WinRT way
            HashAlgorithmProvider sha512Provider = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha512);
            IBuffer bMessage = WindowsRuntimeBufferExtensions.AsBuffer(message);
            IBuffer bDigest = sha512Provider.HashData(bMessage);
            byte [] digestWinRT = WindowsRuntimeBufferExtensions.ToArray(bDigest);

            //The PCLCrypto way
            PCLCrypto.IHashAlgorithmProvider sha512PCLProvider = PCLCrypto.WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(PCLCrypto.HashAlgorithm.Sha512);
            byte [] digestPCL = sha512PCLProvider.HashData(message);

            //Did we get the same value for all ways?
            CollectionAssert.AreEqual(digestWinRT, digestActual);
            CollectionAssert.AreEqual(digestPCL, digestWinRT);
        }
    }
}
