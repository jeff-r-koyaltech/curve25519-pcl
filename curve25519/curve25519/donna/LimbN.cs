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
    /// Limb of size N (a base class for use when a function can operate on short or long form limbs)
    /// Obviously these classes could be avoided in the implementation, but it makes the code more readable.
    /// </summary>
    public class LimbN : System.IPclCloneable
    {
        protected Limb[] _limb;

        protected LimbN(){}

        public LimbN(Limb [] limb)
        {
            _limb = limb;
        }

        public Limb this[int index]
        {
            get
            {
                return _limb[index];
            }
            set
            {
                _limb[index] = value;
            }
        }

        public IPclCloneable Clone()
        {
            Limb[] _newlimb = (Limb[])_limb.Clone();
            Limb19 _newThis = new Limb19(_newlimb);
            return _newThis;
        }

        /// <summary>
        /// Array.CopyTo() wrapper for Limb structures
        /// </summary>
        /// <param name="arrayDest">Copy the data to this Limb array</param>
        /// <param name="index">Starting at this index</param>
        public void CopyTo(LimbN arrayDest, int index, int length)
        {
            Array.Copy(_limb, 0, arrayDest._limb, index, length);
            //_limb.CopyTo(arrayDest._limb, index);
        }

        /// <summary>
        /// Some implementations call for the partial zeroing of an array. This is just
        /// a helper function to facilitate that.
        /// </summary>
        public void ZeroLimb(int start, int value, int count)
        {
            if (start + count > _limb.Length)
                throw new ArgumentException("Cannot exceed bounds of the Limb array.");

            for (int i = start; i < start + count; i++)
            {
                _limb[i] = value;
            }
        }
    }
}
