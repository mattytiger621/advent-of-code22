using System;

namespace advent_of_code_2022.puzzle1;

public class Advent1
{
    const string FILE_NAME = "puzzle1/input.txt";

    public static int FindHighestCalories(IEnumerable<int> group)
    {
        return group.Max();
    }

    public static int FindSumOfThreeHighest(IEnumerable<int> group)
    {
        return group.OrderByDescending(g => g).Take(3).Sum();
    }
    
    public static IEnumerable<int> FindGroupedCalories()
    {
        int elfCalories = 0;
        List<int> allElves = new List<int>();
        var reader = System.IO.File.OpenText(FILE_NAME);
        string? line = reader.ReadLine();
        while (line != null)
        {
            if (line != "")
            {
                elfCalories += Int32.Parse(line);
            }
            else
            {
                allElves.Add(elfCalories);
                elfCalories = 0;
            }
            line = reader.ReadLine();
        }
        return allElves;
    } 
}