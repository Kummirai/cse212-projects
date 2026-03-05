public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // 1. Create an Array of size length.
        // 2. Loop through the Array and multiply every element by the index and append product to array.
        // 3. Return the Array.

        var doublesList = new double[length];

        for (var i = 0; i < length; i++)
        {
            doublesList[i] = number * (i + 1);
        }

        return doublesList;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // 1. Use modulo (%) to ensure we only iterate the necessary number of times, even if the amount is larger than the list size.
        //  2. If amount is  zero return.
        //  3. Loop through the  List and save the last element.
        //  4. Create and inner for loop and shift all other elements one position to the right
        //  5. Put the last element at the begining.
        //  

        amount %= data.Count;

        if (amount == 0)
            return;

        for (int i = 0; i < amount; i++)
        {

            int lastElement = data[data.Count - 1];

            for (int j = data.Count - 1; j > 0; j--)
            {
                data[j] = data[j - 1];
            }

            data[0] = lastElement;
        }


    }
}
