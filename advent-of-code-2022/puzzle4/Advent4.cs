using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace advent_of_code_2022.puzzle4
{
    public class Advent4
    {

        public static StreamReader GetInput()
        {
            const string filePath = "puzzle4/input.txt";
            var inputData = new FileInfo(filePath);
            return inputData.OpenText();
        }

        public static List<Tuple<string, string>> ProcessInputFile(TextReader text)
        {
            var results = new List<Tuple<string, string>>();
            while (text.ReadLine() is { } line)
            {
                string firstAssignment = line.Split(',').First();
                string secondAssignment = line.Split(',').Last();
                results.Add(new Tuple<string, string>(firstAssignment, secondAssignment));
            }
            return results;
        }

        public static bool AssignmentFullyIncludedInOther(Tuple<string, string> input)
        {
            var firstAssignmentNumbers = input.Item1.Split('-').Select(i => int.Parse(i.ToString()));
            var secondAssignmentNumbers = input.Item2.Split('-').Select(i => int.Parse(i.ToString()));
            var minimumFirst = firstAssignmentNumbers.Min();
            var minimumSecond = secondAssignmentNumbers.Min();
            var maximumFirst = firstAssignmentNumbers.Max();
            var maximumSecond = secondAssignmentNumbers.Max();
            return (minimumFirst <= minimumSecond
                    && maximumFirst >= maximumSecond
                    || minimumSecond <= minimumFirst
                    && maximumSecond >= maximumFirst);
        }
        
        public static bool AssignmentOverlapsWithOther(Tuple<string, string> input)
        {
            var firstAssignmentNumbers = input.Item1.Split('-')
                .Select(i => int.Parse(i.ToString()));
            var secondAssignmentNumbers = input.Item2.Split('-')
                .Select(i => int.Parse(i.ToString()));
            var minimumFirst = firstAssignmentNumbers.Min();
            var minimumSecond = secondAssignmentNumbers.Min();
            var maximumFirst = firstAssignmentNumbers.Max();
            var maximumSecond = secondAssignmentNumbers.Max();
            return (minimumFirst >= minimumSecond && minimumFirst <= maximumSecond
                || maximumFirst <= maximumSecond && maximumFirst >= minimumSecond
                || minimumSecond >= minimumFirst && minimumSecond <= minimumFirst
                || maximumSecond <= maximumFirst && maximumSecond >= minimumFirst);
        }
        
        public static int Part1Solution(IEnumerable<Tuple<string, string>> data)
        {
            return data.Count(i => AssignmentFullyIncludedInOther(i));
        }

        public static int Part2Solution(IEnumerable<Tuple<string, string>> data)
        {
            return data.Count(i => AssignmentOverlapsWithOther(i));
        }

        public static int Part1Solution()
        {
            var input = GetInput();
            var data = ProcessInputFile(input);
            return Part1Solution(data);
        }

        public static int Part2Solution()
        {
            var input = GetInput();
            var data = ProcessInputFile(input);
            return Part2Solution(data);
        }
    }
}