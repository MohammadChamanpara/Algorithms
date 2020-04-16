using System;

class Palidrome
{
    public static void Run()
    {
        string s = "1234X4321";
        Console.WriteLine($"Palindrom. {s} {isPalindrome(s)}");
    }
    public static bool isPalindrome(string s)
    {
        s = s.ToLower();
        int charsCount =  256;

        int[] odd = new int[charsCount];
        for (int i = 0; i < s.Length; i++)
        {
            odd[s[i]] = 1 - odd[s[i]];
        }

        int odds = 0;
        for (int i = 0; i < charsCount; i++)
        {
            if (odd[i] == 1)
            {
                odds++;
                if (odds > 1)
                    return false;
            }
        }
        return true;
    }
}
