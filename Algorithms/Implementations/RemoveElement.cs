using System;
using System.Collections.Generic;
using System.Linq;

class RemoveElement
{
    public static void Run()
    {
        //var array = Tools.MakeArray(1, 2, 3);
        //Console.WriteLine(new Solution().XXXX(123));
    }
    public class Solution
    {
        public int RemoveElement(int[] nums, int val)
        {
            if (nums.Length == 0)
                return 0;
            int cur = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                    nums[++cur] = nums[i];
            }
            return cur + 1;
        }
    }
}