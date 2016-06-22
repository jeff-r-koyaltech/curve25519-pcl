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

using System;
using Limb = System.Int64;

namespace curve25519.donna
{
    /* (from original C implementation...)
    * Field element representation:
    *
    * Field elements are written as an array of signed, 64-bit limbs, least
    * significant first. The value of the field element is:
    *   x[0] + 2^26·x[1] + x^51·x[2] + 2^102·x[3] + ...
    *
    * i.e. the limbs are 26, 25, 26, 25, ... bits wide.
    */

    /// <summary>
    /// This is one way limbs are represented (and calculated upon) for Curve25519 donna (as 10 64-bit integers).
    /// Referred to as "short form", in a reduced coeffecient format.
    /// </summary>
    public class Limb10 : LimbN
    {
        public Limb10() : base(new Limb[10]) { }

        public Limb10(Limb[] limb)
        {
            if ((limb == null) || (limb.Length > 10))
            {
                throw new ArgumentException("Limb should be of long form (length 10).");
            }

            if (limb.Length < 10)
            {
                //copy in what we can, and zero fill the rest
                _limb = new Limb[10];
                limb.CopyTo(_limb, 0);
            }
            else //if same length
            {
                _limb = limb;
            }
        }
    }
}
