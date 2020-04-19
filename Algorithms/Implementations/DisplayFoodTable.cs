using System;
using System.Collections.Generic;

public class DisplayFoodTable
{
    public static void Run()
    {
        IList<IList<string>> input = new List<IList<string>>() {
            new List<string>{ "Laura", "2", "qean Burrito" },
            new List<string>{ "Jhon", "2", "Xeef Burrito" },
            new List<string>{"Melissa", "2", "Soda" } };
        new DisplayFoodTable().DisplayTable(input);
    }
    public IList<IList<string>> DisplayTable(IList<IList<string>> orders)
    {
        List<string> foods = new List<string>();


        for (int i = 0; i < orders.Count; i++)
        {
            if (!foods.Contains(orders[i][2]))
                foods.Add(orders[i][2]);
        }
        foods.Sort(StringComparer.Ordinal);

        var d = new Dictionary<string, int>();
        for (int i = 0; i < foods.Count; i++)
        {
            d.Add(foods[i], i);
        }

        string[,] matrix = new string[501, foods.Count + 1];

        matrix[0, 0] = "Table";

        for (int i = 0; i < foods.Count; i++)
        {
            matrix[0, i + 1] = foods[i];
        }

        for (int i = 0; i < orders.Count; i++)
        {
            string food = orders[i][2];
            int table = int.Parse(orders[i][1]);
            int value = 0;
            int.TryParse(matrix[table, d[food] + 1], out value);
            value++;
            matrix[table, d[food] + 1] = value.ToString();
            matrix[table, 0] = table.ToString();
        }

        IList<IList<string>> o = new List<IList<string>>();

        for (int i = 0; i < 501; i++)
        {
            if (matrix[i, 0] != null)
            {
                o.Add(new List<string>());
                for (int j = 0; j <= foods.Count; j++)
                {
                    o[o.Count - 1].Add(matrix[i, j] == null ? "0" : matrix[i, j]);
                }
            }
        }
        return o;
    }
}