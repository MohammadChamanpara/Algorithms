using System;

class FindMedianSorted
{
    public static void Run()
    {

        Console.WriteLine(new Solution().FindMedianSortedArrays(new int[] { 6 }, new int[] { 1, 2, 3, 4, 5, 7 }));
    }

    public class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int count = nums1.Length + nums2.Length;

            int[] wanted;
            if (count % 2 == 0)
                wanted = new int[] { count / 2 - 1, count / 2 };
            else
                wanted = new int[] { count / 2 };

            int sum = 0;
            foreach (var index in wanted)
            {
                sum += GetValue(nums1, nums2, index);
            }
            return (double)sum / wanted.Length;
        }

        private int GetValue(int[] nums1, int[] nums2, int index)
        {
            if (nums1.Length == 0)
                return nums2[index];

            if (nums2.Length == 0)
                return nums1[index];

            int? value = FindValue(index, nums1, nums2);
            if (value.HasValue)
                return value.Value;
            return FindValue(index, nums2, nums1).Value;
        }

        private int? FindValue(int index, int[] main, int[] helper)
        {
            int start = 0;
            int end = main.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                int candidate = main[mid];

                int fit = RightPosition(candidate, helper, index - mid);
                if (fit == 0)
                    return candidate;
                if (fit < 0)
                    start = mid + 1;
                else
                    end = mid - 1;
            }
            return null;
        }

        private int RightPosition(int candidate, int[] helper, int index)
        {
            int tooSmall = -1, tooBig = 1, fit = 0;

            if (index < 0)
                return tooBig;

            if (index > helper.Length)
                return tooSmall;

            if (index == 0)
            {
                if (candidate <= helper[0])
                    return fit;
                return tooBig;
            }

            if (index == helper.Length)
            {
                if (candidate >= helper[helper.Length - 1])
                    return 0;
                return tooSmall;
            }


            if (candidate <= helper[index])
            {
                if (candidate >= helper[index - 1])
                    return fit;

                return tooSmall;
            }
            else
                return tooBig;
        }
    }
}