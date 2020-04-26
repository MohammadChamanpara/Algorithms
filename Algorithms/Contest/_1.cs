using System;
using System.Collections.Generic;
using System.Linq;

class One
{
    public static void Run()
    {
        //var array = Tools.MakeArray(1, 2, 3);
        Console.WriteLine(new Solution().MaxScore("011101"));
    }
    public class Solution
    {
        public int MaxScore(string s)
        {
            int[] zeros = new int[s.Length];
            zeros[0] = (s[0] == '0') ? 1 : 0;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == '0')
                    zeros[i] = zeros[i - 1] + 1;
                else
                    zeros[i] = zeros[i - 1];
            }

            int[] ones = new int[s.Length];
            ones[s.Length - 1] = s[s.Length - 1] == '1' ? 1 : 0;
            for (int i = s.Length - 2; i >= 0; i--)
            {
                if (s[i] == '1')
                    ones[i] = ones[i + 1] + 1;
                else
                    ones[i] = ones[i + 1];
            }

            int max = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (zeros[i] + ones[i + 1] > max)
                    max = zeros[i] + ones[i + 1];
            }
            return max;
        }
    }
}