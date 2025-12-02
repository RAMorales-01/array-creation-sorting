using System;

namespace ArraySort
{
    ///<summary>
    ///This program is manly a practice on how the array works, the objective is:
    ///To create a jagged array, choose the length(how many arrays will contain the outer array) 
    ///then selecte each inner array length and finally insert elements inside each array.
    ///After the creation of the array is complete the user will get the chance to sort its contents.
    ///</summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("This is a test to create a jagged array, insert the elements and finally sort its contents.\n");
            Console.WriteLine("To begin with the process press any key to continue.");
            Console.ReadKey();

            var jaggedArrayCountRows = ArrayUtils.OuterArrayLength("Enter how many arrays will contain the jagged array"); 
            var jaggedArray = ArrayUtils.CreateJaggArray(jaggedArrayCountRows);
            ArrayUtils.InnerRowsLength(jaggedArray);

            /*
                for testing the outputs and returns, remove at the end.
            */
            Console.WriteLine();
            Console.WriteLine($"[TEST] User choosed size: {jaggedArrayCountRows}");  
            Console.WriteLine($"[TEST] Total Rows of the jagged array: {jaggedArray.Length}");
            foreach(int[] innerArr in jaggedArray)
            {
                Console.WriteLine($"{innerArr.Length}");
            }
            Console.WriteLine("--- TEST FINISHED ---");
        }
    }
}