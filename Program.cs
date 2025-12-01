using System;

namespace ArraySort
{
    ///<summary>
    ///this program is a practice to test arrays
    ///user will create array, fill with the elements and finally select the type of sort.
    ///</summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome user! in this test we are going to create a jagged array");
            Console.WriteLine("fill all the inner arrays with integer numbers choosen by you and print the output.");
            Console.WriteLine("To begin with the process press any key to continue.");
            Console.ReadKey();

            var JaggArrSize = ChooseSize("Enter the size of the jagged array");  

            /*
                for testing the outputs, remove at the end.
            */
            Console.WriteLine();
            Console.Write($"[TEST] User choosed size: {JaggArrSize}");  
        }

        ///<summary>
        ///Ask the user to enter an integer number between 2 and 6
        ///which will be the quantity of the inner array the outer array will contain.
        ///</summary>
        ///<param name="prompt">prompts the user for the size of the jagged array</param>
        ///<returns>Integer number between 2 and 6</returns>
        public static int ChooseSize(string prompt)
        {
            int size = 0;

            while(true)
            {
                Console.Clear();
                Console.WriteLine("NOTE: the outer array cannot contain less than 2 and more than 6 inner arrays.\n");
                Console.WriteLine(prompt);
                Console.Write("Size: ");

                if(int.TryParse(Console.ReadLine(), out size) && size >= 2 && size <= 6)
                {
                    return size;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("ERROR: Invalid input, expected integer between 2 and 6. Press any key to try again.");
                    Console.ReadKey();
                }
            }
        }
    }
}