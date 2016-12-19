//Bailey Ilagan                                                                 
//October 13, 2016 
//targetInt.cs 
//Version 2
//The purpose of this is to implement the targetInt object. A targetInt 
//can hold a random number a user can try to guess. This class has two 
//states, known and !known, which identify whether the number has been
// found (known) or not found (!known). 
// 
//"known" - the internal value has been guessed correctly 
//"!known" - the internal value has yet to be guessed 


using System; 

namespace p2
{

    class targetInt
    {
        //all getters are used to print out stats in the driver    

        
        private int numGuess; //total # of guesses 
        private int highGuess; //# of high guesses the user has made 
        private int lowGuess; //# of low guesses the user has made 
        private int avgGuess;//average guess user has made     
        private int numToGuess; //target number user has to guess
        private int objectID; //identifing number for the object
        private int total; //the total that all the guesses (avg calculation) 
        private bool known; //true if number is guessed correctly 
        
        //constructor 
        public targetInt(int num, int id)
        {
            numToGuess = num;
            numGuess = 0;
            highGuess = 0;
            lowGuess = 0;
            avgGuess = 0;
            objectID = id; 
            total = 0; 
            known = false; 
        }

        public targetInt(targetInt t)
        {
            numGuess = t.numGuess;
            highGuess = t.highGuess;
            lowGuess = t.lowGuess;
            avgGuess = t.avgGuess;
            objectID = t.objectID; 
            numToGuess = t.numToGuess;
            total = t.total;
            known = t.known;
        }

        //getter for numGuess 
        public int getnumGuess()
        {
            return numGuess; 
        }

        //getter for highGuess 
        public int gethighGuess()
        {
            return highGuess;
        }

        //getter for lowGuess 
        public int getlowGuess()
        {
            return lowGuess; 
        }

        //getter for avgGuess
        public int getavgGuess()
        {
            return avgGuess; 
        }

        //getter for objectID
        public int getobjectID()
        {
            return objectID;
        }

        //returns true if the number was found 
        //no parameters
        //does not change any variables 
        public bool found()
        {
            return known;
        }

        ///Resets all the data fields back to normal
        ///Precondition: None
        ///Postcondition: data fields will be back to normal
        ///Invariants: None
        public void reset(int num, int id)
        {
            numToGuess = num;
            numGuess = 0;
            highGuess = 0;
            lowGuess = 0;
            avgGuess = 0;
            objectID = id;
            total = 0;
            known = false;
        }

        ///Updates data fields with accepted value
        ///Precondition: accepted value is not a negative number
        ///Postconditon: data fields will be updated accordingly
        ///Invariants: None
        ///State will change to known if val = numToGuess
        public void update(int val)
        {
            if (val > numToGuess) //updates highGuess
                highGuess++;
            else if (val < numToGuess) //updates lowGuess
                lowGuess++;
            else if (val == numToGuess) //checks if target number has been found 
                known = true; //changes the state of known to true if found 

            numGuess++; 
            total = total + val; //update total
            avgGuess = total / numGuess; //average calculation 
        }

        /// Gives feedback on whether the guess passed in is too high or low
        /// 
        /// Returns a -1 if guess is less than numToGuess
        /// Returns a 1 if guess is greater than numToGuess
        /// 
        ///Preconditions: Value is not negative 
        ///Postconditions: None
        ///Invariants: Will either return 1 or -1
        public int help(int val)
        {
            if (val < numToGuess)
                return -1; 
            else 
                return 1; 
        }
    }
}
