using System;

static class Tools
{
    public static T[] MakeArray<T>(params T[] items)
    {
        return items;
    }

    public static void Print<T>(this T[] array)
    {
        Console.Write("(");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i]);
            if (i != array.Length - 1)
                Console.Write(",");
        }
        Console.WriteLine(")");
    }
}
