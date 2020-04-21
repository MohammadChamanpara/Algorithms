using System;

class ReverseInt
{
    public static void Run()
    {

        Console.WriteLine(new Solution().Reverse(123));
    }

    public class Solution
    {
        public int Reverse(int x)
        {
            bool negative = false;
            if (x < 0)
            {
                x = -x;
                negative = true;
            }
            int y = 0;

            try
            {
                while (x > 0)
                {
                    checked
                    {
                        y *= 10;
                        y += x % 10;
                    }
                    x /= 10;
                }
            }
            catch (OverflowException) {
                return 0;
            }

            return negative ? -y : y;
        }
    }
}