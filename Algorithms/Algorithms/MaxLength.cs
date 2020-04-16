using System;

class MaxLength
{
    public static void Run()
    {
        Console.WriteLine(FindMaxLength(new int[] { 1, 0, 0, 1 }));
    }

    public static int FindMaxLength(int[] nums)
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
}