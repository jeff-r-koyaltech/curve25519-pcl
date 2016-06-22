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
    /// <summary>
    /// This is one way limbs are represented (and calculated upon) for Curve25519 donna (as 10 64-bit integers).
    /// Referred to as "long form". It is primarily useful for storing the result of multiplication prior to reduction of coeffecients.
    /// </summary>
    public class Limb19 : LimbN
    {
        public Limb19() : base(new Limb[19]){}

        public Limb19(Limb[] limb)
        {
            if ((limb == null) || (limb.Length > 19))
            {
                throw new ArgumentException("Limb should be of long form (length 19).");
            }

            if(limb.Length < 19)
            {
                //copy in what we can, and zero fill the rest
                _limb = new Limb[19];
                limb.CopyTo(_limb, 0);
            }
            else //if same length
            {
                _limb = limb;
            }
        }

    }
}
