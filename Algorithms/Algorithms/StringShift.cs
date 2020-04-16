using System;

class StringShifter
{
    public static void Run()
    {
        Console.WriteLine(new StringShifter().StringShift
        (
            "0123456789",

            new int[][]
            {
                new int[] { 1, 6 },
                new int[] { 0, 1 },
                new int[] { 1, 3 },
                new int[] { 1, 0 },
                new int[] { 0, 3 }
            }
        ));
    }
    public string StringShift(string s, int[][] shift)
    {
        int finalShift = 0;
        foreach (var item in shift)
            finalShift += item[0] == 1 ? item[1] : -item[1];

        finalShift %= s.Length;

        if (finalShift == 0)
            return s;
        else if (finalShift > 0)
            return s.Substring(s.Length - finalShift) + s.Substring(0, s.Length - finalShift);
        else
            return s.Substring(-finalShift) + s.Substring(0, -finalShift);

    }
}