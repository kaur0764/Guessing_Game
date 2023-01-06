/*
 * Jasreet Kaur
 * Completed on April 14, 2022
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessing_Game
{
    class RandomInteger //base class
    {
        protected Random random = new(int.Parse(Guid.NewGuid().ToString()[..8], System.Globalization.NumberStyles.HexNumber));
        protected int currentRandomNumber = 0;

        // default constructor:
        public RandomInteger()
        {

        }

        //method
        public int GenerateRandomNumber()
        {
            currentRandomNumber = random.Next();
            return currentRandomNumber;
        }

        // get method
        public int GetCurrentRandomNumber() { return currentRandomNumber; }

    }



}
