using System;

namespace ArraySort
{   
    ///<summary>
    ///A representation for the four sorting options that
    ///the user will be able to choose later in the program
    ///</summary>
    public enum Sorting
    {
        Ascending = 1,
        Descending,
        OddOnly,
        EvenOnly
    }

    ///<summary>
    ///Constants for the length permited of the outer and inner arrays.
    ///</summary>
    public static class Constants
    {   
        public const int minLengthOuterArr = 2;
        public const int maxLengthOuterArr= 6;

        public const int minLengthInnerArr = 1;
        public const int maxLengthInnerArr = 6;

        public const int minSortingOption = 1;
        public const int maxSortingOption = 4;
    }

    ///<summary>
    ///This class contains all the methods that will be used 
    ///to create all the arrays and sorting options for the user.
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

            Console.Clear();
            Console.WriteLine("NOTE: the jagged array cannot contain less than 2 or more than 6 inner arrays.\n");
            Console.WriteLine(prompt);
            arrLengthInput = IntegerInputValidation("Length: ", arrLengthInput, Constants.minLengthOuterArr, Constants.maxLengthOuterArr);

            return arrLengthInput;
        }
        
        //Helper method for integer validation
        private static int IntegerInputValidation(string askedInput, int userInput, int minimum, int maximum)
        {
            while(true)
            {
                Console.Write(askedInput);

                if(int.TryParse(Console.ReadLine(), out userInput) && userInput >= minimum && userInput <= maximum)
                {
                    return userInput;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"ERROR: Invalid input, expected integer between {minimum} and {maximum}. Press any key to try again.");
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
            Console.WriteLine($"The jagged array will contain a number of: {array.Length} arrays\n");
            Console.WriteLine("Now let's choose the length of each inner array and proceed to fill them with integer numbers.\n");
            Console.WriteLine("Press any key to begin.");
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

            Console.Clear();
            Console.WriteLine("NOTE: The minimum length permited for each inner array is of 1 and a maximum length of 6\n");
            Console.WriteLine($"Array {currentRow} of {arrayTotalLength}");
            rowLengthInput = IntegerInputValidation("Length of array: ", rowLengthInput, Constants.minLengthInnerArr, Constants.maxLengthInnerArr);

            return rowLengthInput;
        }

        ///<summary>
        ///Populate each inner array, by manually inserting each element
        ///or automatically starting at random from 1 to 100.
        ///</summary>
        ///<param name="array">current array to be filled with elements</param> 
        public static void PopulateInnerArray(int[][] array)
        {
            int indexOuterArray = 0;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Here is the length of each array: ");

            foreach(int[] innerArray in array)
            {
                Console.WriteLine($"At Index {indexOuterArray} the length is {innerArray.Length}");
                indexOuterArray++;
            }

            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("NOTE: if selected 'n' each array will be filled automatically with random numbers from 1 to 100.");
            bool userChoice = UserInputConfirmation("Would you like to insert manually each element on each row?", "Y/N: ");

            if(userChoice == true)
            {
                InsertManually(array);
            }
            else
            {
                InsertAutomatically(array);
            }
        }
        
        //Helper method that takes the user input to confirm an action
        private static bool UserInputConfirmation(string prompt1, string prompt2)
        {
            while(true)
            {
                Console.WriteLine();
                Console.WriteLine(prompt1);
                Console.Write(prompt2);
                string input = Console.ReadLine().ToLower();

                if(string.Equals(input, "y", StringComparison.OrdinalIgnoreCase) || string.Equals(input, "yes", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                else if(string.Equals(input, "n", StringComparison.OrdinalIgnoreCase) || string.Equals(input, "no", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("ERROR INVALID INPUT: expected 'y' for yes or 'n' for no. Press any key to try again.");
                    Console.ReadKey();
                }
            }
        }

        //Helper method to insert each element manually
        private static void InsertManually(int[][] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                for(int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = ValidateUserInput("NOTE: the element to be inserted at the current index must be an integer.", "Enter integer: ", i + 1, j);
                }
            }
        }

        //Helper method to validate the user input for confirmation of an action.
        private static int ValidateUserInput(string prompt1, string prompt2, int currentRow, int currentIndex)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine(prompt1);
                Console.WriteLine($"\nYou are at index: {currentIndex} of inner array: {currentRow}");
                Console.Write(prompt2);

                if(int.TryParse(Console.ReadLine(), out int numInput))
                {
                    return numInput;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("ERROR: invalid input, expected integer number. Press any key to try again.");
                    Console.ReadKey();
                }
            }
        }

        //Helper method to insert each element at random, numbers between 1 to 100.
        private static void InsertAutomatically(int[][] array)
        {
            Random random = new Random();

            for(int i = 0; i < array.Length; i++)
            {
                for(int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = random.Next(1, 101);
                }
            }
        }

        //Helper method that prints the current contents of the array.
        private static void DisplayArray(int[][] array)
        {
            Console.Clear();
            Console.WriteLine($"Jagged Array total Length: {array.Length} inner arrays");

            for(int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"\nInner Array at index {i}");

                for(int j = 0; j < array[i].Length; j++)
                {
                    Console.Write($"{array[i][j]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        ///<summary>
        ///Prompts user to select one of the four presented options
        ///for sorting the contents of each array.
        ///</summary>
        ///<param name="array">previously created array by the user</param>
        public static void SortArray(int[][] array)
        {
            DisplayArray(array);

            bool userChoice = UserInputConfirmation("Would you like to sort the contents of each array?", "Y/N: ");
            
            if(userChoice == true)
            {
                Sorting selectedSort = SelectType("1- Ascending\n2- Descending\n3- Odd Only\n4- Even Only\n", "Type: ");

                if(selectedSort == Sorting.Ascending || selectedSort == Sorting.Descending)
                {
                    AscendingOrDescending(array, selectedSort);
                    DisplayArray(array);
                }
                else if(selectedSort == Sorting.OddOnly || selectedSort == Sorting.EvenOnly)
                {
                    var newArray = OddsOrEven(array, selectedSort);
                    
                    Console.Clear();
                    Console.WriteLine($"New array: \n");

                    foreach(int element in newArray)
                    {
                        Console.Write($"{element} ");
                    }
                    
                    Console.WriteLine("\n\nThank you for testing the program, goodbye!\n");
                }   
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Thank you for testing the program, goodbye!\n");
            }
        }

        //Helper method for the selection of the type of sorting
        private static Sorting SelectType(string prompt1, string prompt2)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Select one of the four sorting options.\n");
                Console.WriteLine("WARNING: selecting odds or evens only will create a new array with only the selected numbers.");
                Console.WriteLine(prompt1);
                Console.Write(prompt2);

                if(int.TryParse(Console.ReadLine(), out int userInput) && userInput >= Constants.minSortingOption && userInput <= Constants.maxSortingOption)
                {
                    bool userChoice = UserInputConfirmation($"You selected sorting type {userInput} is this correct?", "Y/N: ");

                    if(userChoice == true)
                    {
                        return (Sorting)userInput;
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("ERROR: Invalid input, expected integer between 1 and 4. Press any key to try again.");
                    Console.ReadKey();
                }
            }
        }

        //Helper method to sort by the insertion algorithm
        private static void AscendingOrDescending(int[][] array, Sorting selectedSort)
        {
            bool condition = SelectedSortingType(selectedSort);

            for(int i = 0; i < array.Length; i++)
            {
                for(int j = 1; j < array[i].Length; j++)
                {
                    int selectedElement = array[i][j]; //current element to be inserted
                    int k = j - 1; //index pointer

                    while(k >= 0 && (condition ? array[i][k] > selectedElement : array[i][k] < selectedElement))
                    {
                        array[i][k + 1] = array[i][k];
                        k--;
                    }

                    array[i][k + 1] = selectedElement;
                }
            }
        }

        //Helper method for AscendingOrDescending 
        private static bool SelectedSortingType(Sorting selectedSort)
        {
            if(selectedSort == Sorting.Ascending || selectedSort == Sorting.OddOnly)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper method that creates a new array with only the odds or even of all the inner arrays 
        private static int[] OddsOrEven(int[][] array, Sorting selectedSort)
        {
            int newArrayLength = OddOrEvenCount(array, selectedSort); //returns the total count of odd or even nums on all arrays
            bool condition = SelectedSortingType(selectedSort);

            int[] newArray = new int[newArrayLength]; //will contain all the odd or even numbers
            int indexPointer = 0;

            for(int i = 0; i < array.Length; i++)
            {
                for(int j = 0; j < array[i].Length; j++)
                {
                    if(condition ? array[i][j] % 2 != 0 : array[i][j] % 2 == 0)
                    {
                        newArray[indexPointer] = array[i][j];
                        indexPointer++;
                    }
                }
            }

            return newArray;
        }

        //Helper method for OddsOrEven returns the total count of all the odd or even nums inside all the arrays
        private static int OddOrEvenCount(int[][] array, Sorting selectedSort)
        {
            int count = 0;

            for(int i = 0; i < array.Length; i++)
            {
                for(int j = 0; j < array[i].Length; j++)
                {
                    if(selectedSort == Sorting.OddOnly && array[i][j] % 2 != 0)
                    {
                        count++;
                    }
                    else if(selectedSort == Sorting.EvenOnly && array[i][j] % 2 == 0)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}