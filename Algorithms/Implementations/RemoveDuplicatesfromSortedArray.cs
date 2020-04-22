using System;
using System.Collections.Generic;
using System.Linq;

class RemoveDuplicatesfromSortedArray
{
    public static void Run()
    {
        //var array = Tools.MakeArray(1, 2, 3);
        //Console.WriteLine(new Solution().XXXX(123));
    }
    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int cur = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != nums[cur])
                {
                    nums[++cur] = nums[i];
                }
            }
            return cur + 1;
        }
    }
}