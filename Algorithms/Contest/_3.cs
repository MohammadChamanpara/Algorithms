using System;
using System.Collections.Generic;
using System.Linq;

class Three
{
    public static void Run()
    {
        //var array = Tools.MakeArray(1, 2, 3);
        //Console.WriteLine(new Solution().XXXX(123));
    }
    public class Solution
    {
        int max = 0;
        public int[] FindDiagonalOrder(IList<IList<int>> nums)
        {
            int count = getCount(nums);
            int[] output = new int[count];
            int index = 0;
            int size = nums.Count;
            int[] indexes = new int[size];

            for (int i = 0; i < size; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    int? next = getNext(nums, i, indexes);
                    if (next == null)
                        continue;
                    output[index++] = next.Value;
                }
            }
            for (int i = 0; i < max; i++)
            {
                for (int j = size; j >= 0; j--)
                {
                    int? next = getNext(nums, i, indexes);
                    if (next == null)
                        continue;
                    output[index++] = next.Value;
                }
            }
            return output;
        }

        private int? getNext(IList<IList<int>> nums, int i, int[] indexes)
        {
            if (indexes[i] >= nums[i].Count() - 1)
                return null;
            return nums[i][indexes[i]++];
        }

        private int getCount(IList<IList<int>> nums)
        {
            int count = 0;
            for (int i = 0; i < nums.Count(); i++)
            {
                int c = nums[i].Count();
                count += c;
                if (c > max)
                    max = c;
            }
            return count;
        }


    }

}