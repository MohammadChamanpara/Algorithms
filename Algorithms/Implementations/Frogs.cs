using System;

public class Frogs
{
    public static void Run()
    {
        Console.WriteLine(new Frogs().MinNumberOfFrogs("croakcroak"));
    }
    public int MinNumberOfFrogs(string croakOfFrogs)
    {
        int[] frogs = new int[5];

        foreach (var c in croakOfFrogs)
        {
            var x = GetIndex(c);

            if (x == -1)
                return -1;

            if (x == 0)
            {
                if (frogs[4] > 0) frogs[4]--;
                frogs[0]++;
                continue;
            }

            if (frogs[x - 1] == 0)
                return -1;

            frogs[x - 1]--;
            frogs[x]++;
        }

        for (int i = 0; i <= 3; i++)
        {
            if (frogs[i] > 0)
                return -1;
        }

        return frogs[4];
    }

    private int GetIndex(char c)
    {
        switch (c)
        {
            case 'c':
                return 0;
            case 'r':
                return 1;
            case 'o':
                return 2;
            case 'a':
                return 3;
            case 'k':
                return 4;
        }
        return -1;
    }
}