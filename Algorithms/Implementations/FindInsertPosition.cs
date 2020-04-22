using System;
using System.Collections.Generic;
using System.Linq;

class FindInsertPosition
{
    public static void Run()
    {
        //var array = Tools.MakeArray(1, 2, 3);
        //Console.WriteLine(new Solution().XXXX(123));
    }
    public class Solution
    {
        public int SearchInsert(int[] nums, int target)
        {
            int start = 0, end = nums.Length - 1;
            while(start<=end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] == target)
                    return mid;
                if (nums[mid] < target)
                    start = mid + 1;
                else
                    end = mid - 1;
            }
            return start;
        }
    }
}