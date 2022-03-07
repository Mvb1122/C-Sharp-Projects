// NOTE: There's something wrong with this example, and I don't know what it is.


int[] arr1 = new int[] { 9, 1, 3, 5, 4 };
int[] temp = new int[arr1.Length];

b.MergeSortHelper(ref arr1, 0, arr1.Length - 1, ref temp);
foreach (int i in temp) Console.WriteLine(i);

/** Precondition: (arr.length == 0 or 0 <= from <= to <= arr.length)

 * arr.length == temp.length

 */
public class b
{
    public static void MergeSortHelper(ref int[] arr, int from, int to, ref int[] temp)

    {

        if (from < to)

        {

            int middle = (from + to) / 2;

            MergeSortHelper(ref arr, from, middle, ref temp);

            MergeSortHelper(ref arr, middle + 1, to,ref temp);

            Merge(ref arr, from, middle, to, ref temp);

        }

    }

    public static void Merge(ref int[] arr, int from, int middle, int to, ref int[] temp)
    {
        // Get first half.
        middle = arr.Length / 2;
        int[] firstHalf = new int[middle];
        for (int i = 0; i < middle; i++)
        {
            firstHalf[i] = arr[i];
        }

        // Get second half.
        int[] secondHalf = new int[middle + 1];
        for (int i = middle ;i < arr.Length; i++)
        {
            secondHalf[i - middle] = arr[i];
        }

        // Sort.
        Array.Sort(secondHalf);
        Array.Sort(firstHalf);

        // Re-Concatonate.
        temp = new int[arr.Length];
        for (int i = 0;i < arr.Length;i++)
        {
            if (i < middle) 
                temp[i] = firstHalf[i];
            else
                temp[i] = secondHalf[i - middle];
        }

        // Send back the value by reference.
        arr = temp;
    }
}