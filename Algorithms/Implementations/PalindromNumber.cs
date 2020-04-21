using System;
using System.Collections.Generic;
using System.Linq;

class PalindromeNumber
{
    public static void Run()
    {
        //var array = Tools.MakeArray(1, 2, 3);
        Console.WriteLine(new Solution().IsPalindrome(212321223));
    }

    public class Solution
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;

            int ox = x;
            int y = 0;
            while (ox > 0)
            {
                y *= 10;
                y += ox % 10;
                ox /= 10;
            }

            return x == y;
        }
    }
}