using System;
using System.Collections.Generic;

public class ReformatLetterDigits
{
    public string Reformat(string s)
    {
        List<char> digits = new List<char>();
        List<char> letters = new List<char>();
        foreach (var item in s)
        {
            if (char.IsDigit(item))
                digits.Add(item);
            else if (char.IsLetter(item))
                letters.Add(item);
        }

        if (Math.Abs(digits.Count - letters.Count) > 1)
            return "";

        List<char> smaller;
        List<char> bigger;

        if (digits.Count < letters.Count)
        {
            smaller = digits;
            bigger = letters;
        }
        else
        {
            smaller = letters;
            bigger = digits;
        }

        List<char> output = new List<char>();
        int smallerIndex=0,biggerIndex = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (i % 2 == 0)
                output.Add(bigger[biggerIndex++]);
            else
                output.Add(smaller[smallerIndex++]);
        }
        return string.Concat(output.ToArray());
    }
}