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

            Console.WriteLine("\nThe jagged array is mostly complete, the final step is to populate each inner array.");
            ArrayUtils.PopulateInnerArray(jaggedArray);
        }
    }
}