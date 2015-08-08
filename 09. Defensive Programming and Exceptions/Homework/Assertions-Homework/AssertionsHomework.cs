using System;
using System.Diagnostics;
using System.Linq;

public static class AssertionsHomework
{
    public static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }

    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array can not be null");
        Debug.Assert(arr.Length != 0, "You can not pass an empty array");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            
            Swap(ref arr[index], ref arr[minElementIndex]);
        }

        Debug.Assert(ValidateIfArrayIsSorted(arr), "Array is not sorted.");
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array can not be null");
        Debug.Assert(arr.Length != 0, "You can not pass an empty array");
        Debug.Assert(startIndex < endIndex, "The start index can not be larger than the end index");
        Debug.Assert(startIndex >= 0, "Start index must be greater than or equal to 0.");
        Debug.Assert(endIndex > 0, "End index must be greater than 0.");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                Debug.Assert(ValidateCorrectPositionOfElement(arr, value, midIndex), "Incorrect position of element");
                
                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        Debug.Assert(ValidateCorrectPositionOfElement(arr, value, -1), "Incorrect position of element");
        
        return -1;
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array can not be null");
        Debug.Assert(arr.Length != 0, "You can not pass an empty array");
        Debug.Assert(startIndex < endIndex, "The start index can not be larger than the end index");
        Debug.Assert(startIndex >= 0, "Start index must be greater than or equal to 0.");
        Debug.Assert(endIndex > 0, "End index must be greater than 0.");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        Debug.Assert(ValidateMinElementPosition(arr, startIndex, endIndex, minElementIndex), "Minimum element is not correctly identified.");

        return minElementIndex;
    }

    private static bool ValidateMinElementPosition<T>(T[] arr, int startIndex, int endIndex, int minElementIndex) where T : IComparable<T>
    {
        for (int i = startIndex; i <= endIndex; i++)
        {
            if (arr[minElementIndex].CompareTo(arr[i]) > 0)
            {
                return false;
            }
        }

        return true;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    private static bool ValidateIfArrayIsSorted<T>(T[] arr) where T : IComparable<T>
    {
        bool isSorted = true;

        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i].CompareTo(arr[i + 1]) > 0)
            {
                isSorted = false;
            }
        }

        return isSorted;
    }

    private static bool ValidateCorrectPositionOfElement<T>(T[] arr, T value, int result) 
        where T : IComparable<T>
    {
        int index = Array.IndexOf(arr, value);
        if (index == result)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
