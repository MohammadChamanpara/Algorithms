using System;
using System.Collections.Generic;
using System.Linq;

public class FindTwoSum
{
    public static void Run()
    {
        int[] input = new int[] { 3, 2, 4 };
        foreach (var item in new FindTwoSum().TwoSum(input, 6))
        {
            Console.WriteLine(item);
        }
    }
    public int[] TwoSum(int[] nums, int target)
    {
        var d = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
            d[nums[i]] = i;

        for (int i = 0; i < nums.Length; i++)
        {
            int second = target - nums[i];
            if (d.ContainsKey(second))
                if (d[second] != i)
                    return new int[] { i, d[second] };
        }

        return new int[] { };
    }
}