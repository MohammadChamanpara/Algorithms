using System;
using System.Linq;

public class Islands
{
    public static void Run()
    {
        char[][] input = new char[][]
        {
            new char[] { '1', '1', '1', '0', '1' },
            new char[] { '1', '1', '0', '0', '1' },
            new char[] { '1', '1', '0', '0', '1' },
            new char[] { '0', '1', '1', '1', '1' },
        };
        Console.WriteLine(new Islands().NumIslands(input));
    }
    public int NumIslands(char[][] grid)
    {
        int count = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == '1')
                {
                    count++;
                    Destroy(grid, i, j);
                }
            }
        }
        return count;
    }

    private void Destroy(char[][] grid, int i, int j)
    {
        if (i < 0 || i >= grid.Length || j < 0 || j >= grid[i].Length)
            return;

        if (grid[i][j] == '0')
            return;

        grid[i][j] = '0';
        Destroy(grid, i - 1, j);
        Destroy(grid, i, j - 1);
        Destroy(grid, i, j + 1);
        Destroy(grid, i + 1, j);
    }
}