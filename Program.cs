//Bailey Ilagan
//October 13, 2016 
//p2.cs
//The purpose of this driver is test all funtionality of the randomTargets class

//Assumptions: 
// -

using System;
using static System.Console; 

namespace p2
{
    class p2
    {
        const int ARR_SIZE = 3;
        const int RAND_LIMIT = 10;
        const int NUM_GUESSES = 10;
        const int NUM_OBJ = 2; 
        const int NOT_FOUND = -1;
        static Random random = new Random(); 

        /// Returns object with the greatest number of high guess and the object
        /// with the greatest number of low guesses 
        /// 
        /// 
        /// <param name="r"></param>
        static void stats (randomTargets r)
        {
            targetInt temp = new targetInt(r.findHighGuesses());
            targetInt temp2 = new targetInt(r.findLowGuesses());

            WriteLine("Greatest # of high guesses: Object " + temp.getobjectID());
            WriteLine("--------------------------------------");

            WriteLine("# of guesses: " + temp.getnumGuess());
            WriteLine("# of high guesses: " + temp.gethighGuess());
            WriteLine("# of low guesses: " + temp.getlowGuess());
            WriteLine("Average guess: " + temp.getavgGuess());
            WriteLine("\n");

            WriteLine("Greatest # of low guesses: Object "+temp2.getobjectID());
            WriteLine("--------------------------------------");

            WriteLine("# of guesses: " + temp2.getnumGuess());
            WriteLine("# of high guesses: " + temp2.gethighGuess());
            WriteLine("# of low guesses: " + temp2.getlowGuess());
            WriteLine("Average guess: " + temp2.getavgGuess());
            WriteLine("\n");
        }

        /// Runs test on collection of randomTargets objects
        /// 
        /// Preconditon: 
        ///     There is al least one object 
        /// Postcondition: 
        ///     Test will run 
        /// Invariants: 
        ///     None
        static void runTests(randomTargets[] arr)
        {
            for (int i = 0; i < NUM_OBJ; i++)
            {
                WriteLine("-------");
                WriteLine("Test " + (i + 1));
                WriteLine("-------");
                WriteLine("\n");

                for (int j = 0; j < NUM_GUESSES; j++)
                {
                    int guess = random.Next(RAND_LIMIT);
                    int index = 0;

                    if (!arr[i].isEmpty())
                    {

                        WriteLine("Guess " + (j + 1) + ": " + guess);
                        index = arr[i].processGuess(guess);

                        if (index == NOT_FOUND)
                        {
                            WriteLine("Incorrect...guess again...");
                        }
                        else
                        {
                            WriteLine("Correct!");
                            int deleted = arr[i].delete(index);
                            WriteLine("Object " + deleted + " was deleted...");
                        }
                        WriteLine("------------------");
                    }
                }

                if (arr[i].isEmpty())
                    WriteLine("Congradulations! You have guessed all the numbers!");

                WriteLine("\n");
                WriteLine("---------------------");
                WriteLine("Statistics for Test " + (i + 1));
                WriteLine("---------------------");

                stats(arr[i]);
            }
        }

        /// Returns array of random numbers
        static int[] randomize()
        {
            int[] rand_array = new int[ARR_SIZE];

            for (int i = 0; i < ARR_SIZE; i++)
                rand_array[i] = random.Next(RAND_LIMIT);

            return rand_array; 
        }

        static void Main(string[] args)
        {
            randomTargets[] targets = new randomTargets[NUM_OBJ];

            for (int i = 0; i < NUM_OBJ; i++)
                targets[i] = new randomTargets(ARR_SIZE, randomize());

            WriteLine("Welcome to the randomTargets class demonstration!");
            WriteLine("\n");

            WriteLine("In this program, the randomTargets class will be");
            WriteLine("tested using a variety of random numebers in order");
            WriteLine("to guess the internal values that lie within the");
            WriteLine("object.");
            WriteLine("\n");

            WriteLine("Press enter to start the test...");
            ReadKey();

            Clear();

            runTests(targets);

            WriteLine("Press enter to end the program...");
            ReadKey();

            //shows the statistics 
            //demonstrate both known and unknown state
        }
    }
}
