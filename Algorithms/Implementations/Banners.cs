using System;
using System.Collections.Generic;
using System.Linq;

public class Banners
{
    public static void Run()
    {
        int[] input = new int[] { 3,1,4};
        Console.WriteLine(new Banners().solution(input));
    }
    public int solution(int[] H)
    {
        int size = H.Length;
        int[] maxFromStart = new int[size];
        maxFromStart[0] = H[0];
        for (int i = 1; i < size; i++)
        {
            maxFromStart[i] = Math.Max(maxFromStart[i - 1], H[i]);
        }

        int[] maxFromEnd = new int[size];
        maxFromEnd[size - 1] = H[size - 1];
        for (int i = size - 2; i >= 0; i--)
        {
            maxFromEnd[i] = Math.Max(maxFromEnd[i + 1], H[i]);
        }

        int[] bannerSize = new int[size];
        bannerSize[0] = maxFromEnd[0] * size;
        for (int i = 1; i < size ; i++)
        {
            bannerSize[i] = i * maxFromStart[i-1] + (size - i) * maxFromEnd[i];
        }

        return bannerSize.Min();
    }
}