using System;
using System.Collections.Generic;
using System.Linq;

class RomanNumberToInt
{
    public static void Run()
    {
        //var array = Tools.MakeArray(1, 2, 3);
        Console.WriteLine(new Solution().RomanToInt("MCMXCIV"));
    }

    public class Solution
    {
        public int RomanToInt(string s)
        {
            Dictionary<string, int> ed = new Dictionary<string, int>();
            Dictionary<char, int> d = new Dictionary<char, int>();
            ed.Add("IV", 4);
            ed.Add("IX", 9);
            ed.Add("XL", 40);
            ed.Add("XC", 90);
            ed.Add("CD", 400);
            ed.Add("CM", 900);
            d.Add('I', 1);
            d.Add('V', 5);
            d.Add('X', 10);
            d.Add('L', 50);
            d.Add('C', 100);
            d.Add('D', 500);
            d.Add('M', 1000);

            int sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (!d.ContainsKey(s[i]))
                    continue;

                if (i < s.Length - 1)
                {
                    bool found = false;
                    foreach (var roman in ed.Keys)
                    {
                        if (s[i] == roman[0] && s[i + 1] == roman[1])
                        {
                            i++;
                            sum += ed[roman];
                            found = true;
                            break;
                        }
                    }
                    if (found)
                        continue;
                }

                sum += d[s[i]];

            }

            return sum;
        }
    }
}