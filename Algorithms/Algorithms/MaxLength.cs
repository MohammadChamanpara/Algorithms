using System;
using System.Linq;

class MaxLength
{
    public static void Run()
    {
        Console.WriteLine(FindMaxLength(new int[] { 0, 0, 1, 0, 0, 0, 1, 1 }));
    }

    public static int FindMaxLength_On2(int[] nums)
    {
        int max = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            int zeros = 0, ones = 0;
            if (nums.Length - i <= max)
                break;
            for (int j = i; j < nums.Length; j++)
            {
                if (nums[j] == 0)
                    zeros++;
                if (nums[j] == 1)
                    ones++;
                if (zeros == ones)
                {
                    int lenght = j - i + 1;
                    if (lenght > max)
                        max = lenght;
                }
            }
        }
        return max;
    }
    public int FindMaxLength(int[] nums)
    {
        int max = 0;
        int?[] firstIndex = new int?[2 * nums.Length + 1];
        int count = 0;
        firstIndex[nums.Length + count] = -1;
        for (int i = 0; i < nums.Length; i++)
        {
            count += (nums[i] == 0) ? -1 : 1;
            if (firstIndex[nums.Length + count].HasValue)
                max = Math.Max(max, i - firstIndex[nums.Length + count].Value);
            else
                firstIndex[nums.Length + count] = i;
        }
        return max;
    }
}