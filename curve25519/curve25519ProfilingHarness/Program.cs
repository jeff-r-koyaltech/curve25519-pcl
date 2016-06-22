/** 
 * Copyright (C) 2015 langboost
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

using org.whispersystems.curve25519;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curve25519ProfilingHarness
{
    class Program
    {
        private const int TEST_COUNT = 100;
        private const int BYTES_SIZE = 32;

        /// <summary>
        /// Plug code in here like a unit test to see it in the Diagnostic Tools window.
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("BEGIN...");
            DateTime start = DateTime.UtcNow;

            Curve25519 curve = Curve25519.getInstance(Curve25519.BEST);

            byte[] private_key = new byte[BYTES_SIZE];
            byte[] public_key = new byte[BYTES_SIZE];

            for (int i = 0; i < TEST_COUNT; i++)
            {
                private_key = curve.generatePrivateKey();
                public_key = curve.generatePublicKey(private_key);
            }

            DateTime end = DateTime.UtcNow;
            Console.WriteLine("END...");
            Console.WriteLine("Time elapsed (in ms): " + (end.Subtract(start).TotalMilliseconds));
            Console.ReadLine();
        }
    }
}
