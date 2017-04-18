using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<string> list = new List<string>() { "AAAAAA", "BBBBBB", "CCCCCC", "DDDDDD" };

        foreach (var row in splitList(list))
        {

            Console.WriteLine("row.Count() = " + row.Count());

            for (int i = 0; i <= row.Count() - 1; i++)

                Console.WriteLine("i = " + row[i]);
        }

    }

    public static IEnumerable<List<string>> splitList(List<string> locations, int nSize = 3)
    {
        for (int i = 0; i < locations.Count; i += nSize)
        {
            yield return locations.GetRange(i, Math.Min(nSize, locations.Count - i));
        }
    }

}