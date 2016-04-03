
using System;
using System.Collections.Generic;
using System.Reflection;
/**
* Copyright (C) 2015 Open Whisper Systems
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
namespace org.whispersystems.curve25519
{

    /**
     * A Curve25519 interface for generating keys, calculating agreements, creating signatures,
     * and verifying signatures.
     *
     * @author Moxie Marlinspike
     */
    public class Curve25519
    {

        //public const string NATIVE = "native";
        /// <summary>
        /// CSharp PCL-compatible implementation
        /// </summary>
        public const string CSHARP   = "csharp";
        //public const string J2ME   = "j2me";
        //public const string BEST = "best";

        public static Curve25519 getInstance(string type)
        {
            return getInstance(type, null);
        }

        public static Curve25519 getInstance(string type, SecureRandomProvider random)
        {
            //if      (NATIVE.equals(type)) return new Curve25519(constructNativeProvider(random));
            //else if (JAVA.equals(type))   return new Curve25519(constructJavaProvider(random));
            //else if (J2ME.equals(type))   return new Curve25519(constructJ2meProvider(random));
            //else if (BEST.Equals(type)) return new Curve25519(constructOpportunisticProvider(random));
            if (CSHARP.Equals(type))
                return new Curve25519(constructCSharpProvider(random));
            else
                throw new NoSuchProviderException(type);
        }

        private readonly Curve25519Provider provider;

        private Curve25519(Curve25519Provider provider)
        {
            this.provider = provider;
        }

        /**
         * {@link Curve25519} is backed by either a native (via JNI)
         * or pure-Java provider.  By default it prefers the native provider, and falls back to the
         * pure-Java provider if the native library fails to load.
         *
         * @return true if backed by a native provider, false otherwise.
         */
        public bool isNative()
        {
            return provider.isNative();
        }

        /**
         * Generates a Curve25519 keypair.
         *
         * @return A randomly generated Curve25519 keypair.
         */
        public Curve25519KeyPair generateKeyPair()
        {
            byte[] privateKey = provider.generatePrivateKey();
            byte[] publicKey = provider.generatePublicKey(privateKey);

            return new Curve25519KeyPair(publicKey, privateKey);
        }

        /**
         * Calculates an ECDH agreement.
         *
         * @param publicKey The Curve25519 (typically remote party's) public key.
         * @param privateKey The Curve25519 (typically yours) private key.
         * @return A 32-byte shared secret.
         */
        public byte[] calculateAgreement(byte[] publicKey, byte[] privateKey)
        {
            return provider.calculateAgreement(privateKey, publicKey);
        }

        /**
         * Calculates a Curve25519 signature.
         *
         * @param privateKey The private Curve25519 key to create the signature with.
         * @param message The message to sign.
         * @return A 64-byte signature.
         */
        public byte[] calculateSignature(byte[] privateKey, byte[] message)
        {
            byte[] random = provider.getRandom(64);
            return provider.calculateSignature(random, privateKey, message);
        }

        /**
         * Verify a Curve25519 signature.
         *
         * @param publicKey The Curve25519 public key the signature belongs to.
         * @param message The message that was signed.
         * @param signature The signature to verify.
         * @return true if valid, false if not.
         */
        public bool verifySignature(byte[] publicKey, byte[] message, byte[] signature)
        {
            return provider.verifySignature(publicKey, message, signature);
        }

        private static Curve25519Provider constructCSharpProvider(SecureRandomProvider random)
        {
            return constructClass(typeof(BaseCSharpCurve25519Provider), new object[] { new org.whispersystems.curve25519.BouncyCastleDotNETSha512Provider(), random });
        }
        /* TODO: Implement as appropriate to grow the flexibility of the library...
        private static Curve25519Provider constructNativeProvider(SecureRandomProvider random)
        {
            return constructClass("NativeCurve25519Provider", random);
        }

        private static Curve25519Provider constructJ2meProvider(SecureRandomProvider random)
        {
            return constructClass("J2meCurve25519Provider", random);
        }

        private static Curve25519Provider constructOpportunisticProvider(SecureRandomProvider random)
        {
            return constructClass("OpportunisticCurve25519Provider", random);
        }
        */
        private static Curve25519Provider constructClass(Type curve25519Impl, object[] ctorParams)
        {
            Curve25519Provider provider = null;
            TypeInfo curve25519TypeInfo = curve25519Impl.GetTypeInfo();

            //class must implement Curve25519Provider base class 
            if (curve25519TypeInfo.BaseType != typeof(Curve25519Provider))
            {
                throw new ArgumentException("Class must be a subclass of " + typeof(Curve25519Provider).Name);
            }

            IEnumerator<ConstructorInfo> ctorEnum = curve25519TypeInfo.DeclaredConstructors.GetEnumerator();
            while (ctorEnum.MoveNext())
            {
                ConstructorInfo currCtor = ctorEnum.Current;
                provider = (Curve25519Provider)currCtor.Invoke(null);
                break;
            }
            return provider;
        }
    }
}