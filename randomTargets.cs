//Bailey Ilagan
//October 13, 2016 
//randomTargets.cs
//The purpose of this class is to encapsulate a collection of distinct targetInt
//objects. This class has the ability to delete targetInt objects within the
//collection as well as taken input and compare it to all the internal values. 
//This class also has the ability to compare the stats of the internal objects. 

//Assumptions:
//- When this class accepts an integer, it compares it with all the objects 
//  within its collection, not just one
//- 
//
//"empty" - array is empty 
//"!empty" - array has at least one item in it
using System;
    
namespace p2
{
    class randomTargets
    {
        private targetInt[] array; //contains the collection of targetInts
        private targetInt[] statsArray; //holds on to deleted objects for stats
        private int currentSize; //current size of array
        private int stats_size; //current size of statsArray 
        private bool empty; //determines whether array is empty or not

        //constructor 
        public randomTargets(int size, int[] arr)
        {
            array = new targetInt[size];
            statsArray = new targetInt[size]; 

            for (int i = 0; i < size; i++)
                array[i] = new targetInt(arr[i], (i + 1));

            currentSize = size;
            stats_size = 0;
            empty = false;
        }

        //getter for empty
        public bool isEmpty()
        {
            return empty; 
        }

        /// Deletes a targetInt objects at the given index and returns the 
        /// objectID for the object that was just deleted
        /// 
        /// Preconditions: 
        ///     There need to be at least one object in the array 
        ///  
        ///  Postconditions: 
        ///     currentSize will decrease by one and stats_size will increase
        ///     by one 
        ///     
        ///  Invariant(s): 
        ///     currentSize and stats_size will never be greater than ARR_SIZE
        ///     
        ///State will change to empty if currentSize = 0 
        public int delete(int index)
        {
            targetInt[] temp = new targetInt[currentSize - 1];
            int count = 0;

            for (int i = 0; i < currentSize; i++)
            {
                if (i != index)
                {
                    temp[count] = new targetInt(array[i]);
                    count++;
                }
                else
                {
                    statsArray[stats_size] = new targetInt(array[i]);
                    stats_size++;
                }
            }
            Array.Resize(ref array, currentSize - 1);

            for (int i = 0; i < (currentSize - 1); i++)
                array[i] = new targetInt(temp[i]);

            currentSize--;

            if (currentSize == 0)
                empty = true; 

            return statsArray[stats_size - 1].getobjectID(); 
        }

        /// Processes the accepted integer 
        /// 
        ///Returns -1 if the integer is not found in the array 
        ///Returns the index of the object if the integer is found
        ///
        ///Preconditions: 
        ///    The array needs to have at least one object in it 
        ///    
        ///Postconditions: 
        ///    If the accepted integer exist in one of the objects in the 
        ///    array, then the index for that object will be returned 
        ///    
        ///Invariant(s): 
        ///    Will always return -1 when the integer is not found in the array 
        public int processGuess(int val)
        {
            for (int i = 0; i < currentSize; i++)
            {
                array[i].update(val);
                if (array[i].found())
                    return i;
            }
            return -1; 
        }    


        /// Finds the object in the arrays (array and statsArray) that has the
        /// greatest number of high guesses.
        /// 
        ///Returns a copy of the targetInt object that has the greatest number
        ///of high guesses
        ///
        ///Preconditions: 
        ///    Both arrays (array and statsArray) are not empty
        ///    
        ///Postconditions: 
        ///    If both arrays are not empty, a targetInt object that has the
        ///    greatest amount of high guesses 
        ///    
        ///Invariants: 
        ///    The returned object will either come from array or statsArray
        public targetInt findHighGuesses()
        {
            int num_highGuesses = 0;
            int index = 0; 
            bool isMainArray = true; 

            if (currentSize > 0)
            {
                for (int i = 0; i < currentSize; i++)
                {
                    if (array[i].gethighGuess() > num_highGuesses)
                    {
                        num_highGuesses = array[i].gethighGuess();
                        index = i;
                        isMainArray = true; 
                    }
                }
            }

            if (stats_size > 0)
            {
                for (int i = 0; i < stats_size; i++)
                {
                    if (statsArray[i].gethighGuess() > num_highGuesses)
                    {
                        num_highGuesses = statsArray[i].gethighGuess();
                        index = i;
                        isMainArray = false;
                    }
                }
            }



            if (isMainArray)
                return array[index];
            else
                return statsArray[index];
        }


        /// Finds the object in the arrays (array and statsArray) that has the
        /// greatest number of low guesses.
        /// 
        ///Returns a copy of the targetInt object that has the greatest number
        ///of low guesses
        ///
        ///Preconditions: 
        ///    Both arrays (array and statsArray) are not empty
        ///    
        ///Postconditions: 
        ///    If both arrays are not empty, a targetInt object that has the
        ///    greatest amount of low guesses 
        ///    
        ///Invariants: 
        ///    The returned object will either come from array or statsArray
        public targetInt findLowGuesses()
        {
            int num_lowGuesses = 0; 
            int index = 0;
            bool isMainArray = true;

            if (currentSize > 0)
            {
                for (int i = 0; i < currentSize - 1; i++)
                {
                    if (array[i].getlowGuess() > num_lowGuesses)
                    {
                        num_lowGuesses = array[i].getlowGuess();
                        index = i;
                        isMainArray = true;
                    }
                }
            }

        
            if (stats_size > 0)
            {
                for (int i = 0; i < stats_size; i++)
                {
                    if (statsArray[i].getlowGuess() > num_lowGuesses)
                    {
                        num_lowGuesses = statsArray[i].getlowGuess();
                        index = i;
                        isMainArray = false;
                    }
                }
            }

            if (isMainArray)
                return array[index];
            else
                return statsArray[index];
        }

    }
}
