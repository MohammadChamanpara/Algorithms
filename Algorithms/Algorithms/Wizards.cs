using System;
using System.Collections.Generic;
using System.Linq;

class Wizards
{
    public static void Run()
    {
        int numberOfWizards = 10;
        int src = int.Parse(Console.ReadLine());
        int dest = int.Parse(Console.ReadLine());

        int[][] matrix = new int[numberOfWizards][];
        for (int i = 0; i < numberOfWizards; i++)
        {
            string line = Console.ReadLine();
            matrix[i] = new int[line.Length];
            for (int j = 0; j < line.Length; j++) matrix[i][j] = int.Parse(line[j].ToString());
        }

        int minCost;
        int[] minPath;
        Distance(src, dest, matrix, out minCost, out minPath);
        Console.Write("{0} {1}", minCost, string.Join("", minPath));
    }

    public static void Distance(int src, int dest, int[][] wizards, out int minCost, out int[] minPath)
    {
        minCost = 0;
        minPath = new int[] { };

        List<int> path = Go(src, dest, wizards);
        if (path == null)
            return;

        for (int i = 1; i < path.Count; i++)
        {
            int dif = path[i] - path[i - 1];
            minCost += dif * dif;
        }
        minPath = path.ToArray();
    }

    private static List<int> Go(int src, int dest, int[][] wizards)
    {
        if (src == dest)
            return new List<int>(new int[] { dest });
        wizards[src] = wizards[src].OrderBy(x => x).ToArray();
        foreach (var w in wizards[src])
        {
            if (w <= src)
                continue;
            var path = Go(w, dest, wizards);
            if (path != null)
            {
                path.Insert(0, src);
                return path;
            }
        }
        return null;
    }
}

