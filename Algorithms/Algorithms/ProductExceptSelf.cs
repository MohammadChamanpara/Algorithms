using System;

class ArrayProductExceptSelf
{
    public static void Run()
    {
        var r = new ArrayProductExceptSelf().DO_O1Space(new int[] { 1, 2, 3, 4 });
        foreach (var item in r)
        {
            Console.WriteLine(item);
        }
    }
    public int[] Do_ON(int[] nums)
    {
        int[] fromStart = new int[nums.Length];
        int[] toEnd = new int[nums.Length];
        int[] result = new int[nums.Length];


        fromStart[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            fromStart[i] = fromStart[i - 1] * nums[i];
        }

        toEnd[nums.Length - 1] = nums[nums.Length - 1];
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            toEnd[i] = toEnd[i + 1] * nums[i];
        }

        result[0] = toEnd[1];
        result[nums.Length - 1] = fromStart[nums.Length - 2];
        for (int i = 1; i < nums.Length - 1; i++)
        {
            result[i] = fromStart[i - 1] * toEnd[i + 1];
        }

        return result;
    }

    public int[] DO_O1Space(int[] nums)
    {
        int[] result = new int[nums.Length];


        result[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
            result[i] = result[i - 1] * nums[i];

        for (int i = nums.Length - 2; i >= 0; i--)
            nums[i] *= nums[i + 1];

        result[nums.Length - 1] = result[nums.Length - 2];
        for (int i = nums.Length - 2; i > 0; i--)
            result[i] = result[i - 1] * nums[i + 1];
        result[0] = nums[1];

        return result;
    }
}