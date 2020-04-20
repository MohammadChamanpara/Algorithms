using System;

class RotatedBinarySearch
{
    public static void Run()
    {
        Console.WriteLine(new RotatedBinarySearch().Search(new int[] { 1, 3 ,0}, 3));
    }

    public int Search(int[] nums, int target)
    {
        if (nums == null || nums.Length == 0)
            return -1;

        int size = nums.Length;
        int last = FindActualStart(nums, 0, size - 1);

        return BinarySearch(nums, target, 0, size - 1, last);
    }

    private int BinarySearch(int[] nums, int target, int from, int to, int actualStart)
    {
            if (from > to)
            return -1;

        int mid = (from + to) / 2;

        int pmid = (mid + actualStart) % nums.Length;

        if (nums[pmid] == target)
            return pmid;

        if (nums[pmid] < target)
            return BinarySearch(nums, target, mid + 1, to, actualStart);
        else
            return BinarySearch(nums, target, from, mid - 1, actualStart);
    }

    private int FindActualStart(int[] nums, int start, int end)
    {
        if (start == end)
        {
            if (nums[start] < nums[0])
                return start;
            return (start + 1) % nums.Length;
        }
        int mid = (start + end) / 2;

        if (nums[mid] >= nums[0])
            return FindActualStart(nums, mid + 1, end);
        else
            return FindActualStart(nums, start, mid);
    }
}