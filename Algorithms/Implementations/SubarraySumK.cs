using System;
using System.Collections.Generic;
using System.Linq;

class SubarraySumK
{
    public static void Run()
    {
        var array = Tools.MakeArray(1, 2, -1, 8, 6, -4, -10, -1, -5);
        Console.WriteLine(new Solution().SubarraySum(array, 6));
    }
    public class Solution
    {
        public int SubarraySum(int[] nums, int k)
        {
            if (nums.Length == 0)
                return 0;

            int sum = nums[0] == k ? 1 : 0;

            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] += nums[i - 1];
                if (nums[i] == k)
                    sum++;
            }

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = i; j < nums.Length; j++)
                {
                    nums[j] -= nums[i - 1];
                    if (nums[j] == k)
                        sum++;
                }
            }
            return sum;
        }
    }
}