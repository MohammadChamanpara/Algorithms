using System;
using System.Collections;
using System.Collections.Generic;

class LongestSubstring
{
    public static void Run()
    {
        Console.WriteLine(new Solution().LengthOfLongestSubstring("tmmzuxt"));
    }

    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> d = new Dictionary<char, int>();
            if (string.IsNullOrEmpty(s)) return 0;
            int max = 0, start = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (d.ContainsKey(s[i]))
                    start = Math.Max(start, d[s[i]] + 1);

                int length = i - start + 1;
                if (length > max)
                    max = length;

                d[s[i]] = i;
            }
            return max;
        }
    }
}