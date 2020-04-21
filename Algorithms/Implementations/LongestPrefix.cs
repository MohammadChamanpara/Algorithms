using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class LongestPrefix
{
    public static void Run()
    {
        //var array = Tools.MakeArray(1, 2, 3);
        //Console.WriteLine(new Solution().XXXX(123));
    }

    public class Solution
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
                return "";

            if (string.IsNullOrEmpty(strs[0]))
                return "";

            StringBuilder prefix = new StringBuilder();
            int size = strs[0].Length;

            for (int i = 0; i < size; i++)
            {
                var c = strs[0][i];
                bool equal = true;
                foreach (var str in strs)
                {
                    if (str.Length <= i || str[i] != c)
                    {
                        equal = false;
                        break;
                    }
                }
                if (equal == false)
                    break;
                prefix.Append(c);
            }
            return prefix.ToString();
        }
    }
}