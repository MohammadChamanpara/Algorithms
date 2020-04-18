using System;
using System.Linq;

public class BreakChain
{
    public static void Run()
    {
        var array1 = Enumerable.Repeat(100000, (int)Math.Pow(10, 8)).ToArray();
        var array2 = new int[] { 5, 3, 1, 4, 2, 5 };
        var array3 = new int[] { 5, 3, 1, 4, 4 };
        Console.WriteLine(new BreakChain().solution(array1));
        Console.WriteLine(new BreakChain().solution(array3));
    }
    public int solution(int[] A)
    {
        /* -- Sample Input [ 5 , 3 , 1 , 3 , 8 , 5 ] -- */

        if (A == null || A.Length < 5)
            return -1;

        /* -- Weakest link and its other breaking point (1,8)  -- */

        int weakestLink = FindMin(A);
        int breakingPoint = FindMin(A, weakestLink - 1, weakestLink, weakestLink + 1);
        int cost1 = (breakingPoint != -1) ? A[weakestLink] + A[breakingPoint] : int.MaxValue;


        /* -- Second weakest link and its other breaking point (3,3)  -- */

        int secondWeakestLink = FindMin(A, weakestLink);

        if (A[secondWeakestLink] >= cost1)
            return cost1;

        breakingPoint = FindMin(A, secondWeakestLink - 1, secondWeakestLink, secondWeakestLink + 1);
        int cost2 = (breakingPoint != -1) ? A[secondWeakestLink] + A[breakingPoint] : int.MaxValue;

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