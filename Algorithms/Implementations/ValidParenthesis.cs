using System;
using System.Linq;

public class ValidParenthesis
{
    public static void Run()
    {
        string input = ")()*";
        Console.WriteLine(new ValidParenthesis().CheckValidString(input));
    }
    public bool CheckValidString(string s)
    {
        int min = 0, max = 0;
        foreach (var c in s)
        {
            switch (c)
            {
                case '(':
                    {
                        min++;
                        max++;
                        break;
                    }
                case ')':
                    {
                        min--;
                        max--;
                        break;
                    }
                case '*':
                    {
                        max++;
                        min--;
                        break;
                    }
            }

            if (max < 0)
                return false;

            if (min < 0)
                min = 0;
        }
        return min == 0;
    }
}