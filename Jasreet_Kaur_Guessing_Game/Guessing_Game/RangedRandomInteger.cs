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
    sealed class RangedRandomInteger : RandomInteger //derived class - It is sealed therefore it cannot be inherited by another class
    {
        private int maximum = 10; // this field represents the highest number the random object should create
        private int minimum = 1; // this field represents the lowest number the random object should create

        // default constructor:
        public RangedRandomInteger()
        {

        }

        // overloaded constructor:
        public RangedRandomInteger(int minimum, int maximum)
        {
            SetMinimum(minimum);
            SetMaximum(maximum);
        }

        //methods

        //this method generates a random number in the required range
        public new int GenerateRandomNumber() //Override the GenerateRandomNumber of the base class
        {
            if(minimum > maximum)
            {
                int temp = minimum;
                minimum = maximum;  
                maximum = temp; 
            }
            else if (minimum == maximum)
            {
                return minimum;
            }

            currentRandomNumber = random.Next(minimum, maximum + 1);

            return currentRandomNumber; 
        }


        // set methods

        public void SetMaximum(int maximum)
        {
            if (maximum < 1)
            {
                maximum = 1;
            }
            this.maximum = maximum;
        }

        public void SetMinimum(int minimum)
        {
            if(minimum < 0)
            {
                minimum = 0;
            }
            this.minimum = minimum;
        }


        // get methods

        public int GetMaximum() { return maximum; }
        public int GetMinimum() { return minimum; }

       
    }
}
