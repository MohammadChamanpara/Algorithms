using System;
using System.Linq;

public class MinPathInGrid
{
    public static void Run()
    {
        int[][] input = new int[][]
        {
            new int[] { 1, 3, 1 },
            new int[] { 1, 5, 1 },
            new int[] { 4, 2, 1 },
        };
        Console.WriteLine(new MinPathInGrid().MinPathSum(input));
    }
    public int MinPathSum(int[][] grid)
    {
        int rows = grid.Length;
        if (rows == 0) return 0;
        int cols = grid[0].Length;
        if (cols == 0) return 0;

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (i == 0 && j == 0)
                    continue;

                grid[i][j] += Math.Min(Above(grid, i, j), Left(grid, i, j));
            }
        }
        return grid[rows - 1][cols - 1];
    }

    private int Left(int[][] grid, int i, int j)
    {
        return (j == 0) ? int.MaxValue : grid[i][j - 1];
    }

    private int Above(int[][] grid, int i, int j)
    {
        return (i == 0) ? int.MaxValue : grid[i - 1][j];
    }
}