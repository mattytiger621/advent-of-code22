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

        public static List<Tuple<int, int, int, int>> ProcessInputFile(TextReader text)
        {
            var results = new List<Tuple<int, int, int, int>>();
            while (text.ReadLine() is { } line)
            {
                var lineSplit = line.Split(',');
                var firstAssignmentString = lineSplit.First().Split('-');
                var secondAssignmentString = lineSplit.Last().Split('-');
                int firstAssignmentStartRange = int.Parse(firstAssignmentString[0]);
                int firstAssignmentEndRange = int.Parse(firstAssignmentString[1]);
                int secondAssignmentStartRange = int.Parse(secondAssignmentString[0]);
                int secondAssignmentEndRange = int.Parse(secondAssignmentString[1]);
                results.Add(new Tuple<int, int, int, int>(firstAssignmentStartRange, firstAssignmentEndRange
                    , secondAssignmentStartRange, secondAssignmentEndRange));
            }
            return results;
        }

        public static bool AssignmentFullyIncludedInOther(Tuple<int, int, int, int> input)
        {
            return (input.Item1 <= input.Item3
                    && input.Item2 >= input.Item4
                    || input.Item3 <= input.Item1
                    && input.Item4 >= input.Item2);
        }
        
        public static bool AssignmentOverlapsWithOther(Tuple<int, int, int, int> input)
        {
            return (input.Item1 >= input.Item3 && input.Item1 <= input.Item4
                    || input.Item2 <= input.Item4 && input.Item2 >= input.Item3
                    || input.Item3 >= input.Item1 && input.Item3 <= input.Item1
                    || input.Item4 <= input.Item2 && input.Item4 >= input.Item1);
        }
        
        public static int Part1Solution(IEnumerable<Tuple<int, int, int, int>> data)
        {
            return data.Count(i => AssignmentFullyIncludedInOther(i));
        }

        public static int Part2Solution(IEnumerable<Tuple<int, int, int, int>> data)
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