using System;

namespace ArraySort
{   
    ///<summary>
    ///A representation for the type of sorting options
    ///the user will be able to choose later in the program
    ///</summary>
    public enum Sorting
    {
        SmallestTo = 1,
        LargestTo,
        OddTo,
        EvenTo
    }

    ///<summary>
    ///Constants to use as limits permited for the length of the outer and inner arrays
    ///mainly to prevent magic numbers.
    ///</summary>
    public class Constants
    {   
        public const int minLengthOuterArr = 2;
        public const int maxLengthOuterArr= 6;

        public const int minLengthInnerArr = 1;
        public const int maxLengthInnerArr = 6;
    }

    ///<summary>
    ///This class contains all the methods that will be used 
    ///to create all the arrays and sorting options the user will be able to choose.
    ///</summary>
    public class ArrayUtils
    {
        ///<summary>
        ///Ask the user to enter an integer number between 2 and 6
        ///which will be the quantity of the inner arrays the outer array will contain.
        ///</summary>
        ///<param name="prompt">prompts the user for the length of the outer array</param>
        ///<returns>Integer number between 2 and 6</returns>
        public static int OuterArrayLength(string prompt)
        {
            int arrLengthInput = 0;

            while(true)
            {
                Console.Clear();
                Console.WriteLine("NOTE: the jagged array cannot contain less than 2 and more than 6 inner arrays.\n");
                Console.WriteLine(prompt);
                Console.Write("Length: ");

                if(int.TryParse(Console.ReadLine(), out arrLengthInput) && arrLengthInput >= Constants.minLengthOuterArr && arrLengthInput <= Constants.maxLengthOuterArr)
                {
                    return arrLengthInput;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("ERROR: Invalid input, expected integer between 2 and 6. Press any key to try again.");
                    Console.ReadKey();
                }
            }
        }

        ///<summary>
        ///Let the user assign the length of each inner array
        ///</summary>
        ///<param name="array">Jagged array previously created</param>
        public static void InnerRowsLength(int[][] array)
        {
            Console.Clear();
            Console.WriteLine($"The jagged array will have: {array.Length} inner arrays\n");
            Console.WriteLine("It's time to choose the length of each inner array and fill them with integer numbers.\n");
            Console.WriteLine("Press any key to start with the process.");
            Console.ReadKey();

            for(int i = 0; i < array.Length; i++)
            {
                int currentRowLength = ArrayUtils.CurrentRowLength(i + 1, array.Length);

                array[i] = new int[currentRowLength];
            }
        }

        ///<summary>
        ///Initialize the the outer array
        ///</summary>
        ///<param name="rows">integer that determines the quantity of the arrays the outer array will contain</param>
        ///<returns>jagged array with the length choosen by the user</returns>
        public static int[][] CreateJaggArray(int rows)
        {
            int[][] array = new int[rows][];
            
            return array;
        }

        //Helper method for InnerRowLength
        private static int CurrentRowLength(int currentRow, int arrayTotalLength)
        {
            
            int rowLengthInput = 0;

            while(true)
            {
                Console.Clear();
                Console.WriteLine("NOTE: Each inner array can only have a min of 1 and a max of 6 in length\n");
                Console.WriteLine($"You are currently in inner array number {currentRow} of {arrayTotalLength}");
                Console.Write($"Length of array: ");

                if(int.TryParse(Console.ReadLine(), out rowLengthInput) && rowLengthInput >= Constants.minLengthInnerArr && rowLengthInput <= Constants.maxLengthInnerArr)
                {
                    return rowLengthInput;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("ERROR: invalid input, expected integer between 1 and 6. Press any key to try again.");
                    Console.ReadKey();
                }
            }
        }
    }
}