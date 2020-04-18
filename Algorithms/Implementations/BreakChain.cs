using System;
using System.Linq;

public class BreakChain
{
    public static void Run()
    {
        //var array1 = Enumerable.Repeat(100000, (int)Math.Pow(10, 8)).ToArray();
        var array2 = new int[] { 5, 3, 1, 4, 2, 5 };
        Console.WriteLine(new BreakChain().solution(array2));
    }
    public int solution(int[] A)
    {
        /* -- Sample Input [5,3,1,3,8,5] -- */

        if (A?.Length < 5)
            return -1;

        /* -- Weakest link and its pair (1,8)  -- */

        int minIndex = FindMin(A); 
        int pairIndex1 = FindMin(A, minIndex - 1, minIndex, minIndex + 1); 
        int cost1 = (pairIndex1 != -1) ? A[minIndex] + A[pairIndex1] : int.MaxValue; 


        /* -- Second weakest link and its pair (3,3)  -- */

        int secondMinIndex = FindMin(A, minIndex); 

        if (A[secondMinIndex] >= cost1)
            return cost1;

        int pairIndex2 = FindMin(A, secondMinIndex - 1, secondMinIndex, secondMinIndex + 1); 
        int cost2 = (pairIndex2 != -1) ? A[secondMinIndex] + A[pairIndex2] : int.MaxValue; 

        /* -- Best (3,3) -- */
        return Math.Min(cost1, cost2);
    }

    private int FindMin(int[] array, params int[] exclude)
    {
        int min = int.MaxValue;
        int minIndex = -1;
        for (int i = 1; i < array.Length - 1; i++)
            if (array[i] < min && !exclude.Contains(i))
            {
                min = array[i];
                minIndex = i;
            }

        return minIndex;
    }

    /* --  Time Complexity O(n)   -- */
    /* --  Space Complexity O(1)  -- */
}