using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class CountAndSay
{
    public static void Run()
    {
        Console.WriteLine(new Solution().CountAndSay(5));
    }
    public class Solution
    {
        public string CountAndSay(int n)
        {
            string str = "1";
            for (int i = 2; i <= n; i++)
            {
                str = Transfor(str);
            }
            return str;
        }

        private string Transfor(string str)
        {
            int count = 1;
            char last = str[0];
            StringBuilder result = new StringBuilder();

            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == last)
                {
                    count++;
                }
                else
                {
                    result.Append(count.ToString());
                    result.Append(last);
                    last = str[i];
                    count = 1;
                }
            }

            result.Append(count.ToString());
            result.Append(last);

            return result.ToString();
        }
    }
}