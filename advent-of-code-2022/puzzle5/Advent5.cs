using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;

namespace advent_of_code_2022.puzzle5
{
    public class Advent5
    {

        public static StreamReader GetInput()
        {
            const string filePath = "puzzle5/input.txt";
            var inputData = new FileInfo(filePath);
            return inputData.OpenText();
        }

        public static Dictionary<int, List<char>> CreateCrateMap(TextReader text)
        {
            Dictionary<int, List<char>> crateMap = new Dictionary<int, List<char>>();
            while (text.ReadLine() is { } line)
            {
                string fixedLine = line.Substring(1).TrimEnd();
                for (int i = 0; i < fixedLine.Length; i++)
                {
                    if (i % 4 == 0)
                    {
                        int key = (i / 4);
                        if (!crateMap.ContainsKey(key))
                        {
                            crateMap.Add(key, new List<char>());
                        }

                        {
                            if (Char.IsLetter(fixedLine[i]))
                                crateMap[key].Add(fixedLine[i]);
                        }
                    }
                }
                if (fixedLine[0] =='1')
                {
                    return crateMap;
                }

            }

            return crateMap;
        }

        public static List<Tuple<int, int, int>> CreateCommandsList(TextReader text)
        {
            List<Tuple<int, int, int>> commandsList = new List<Tuple<int, int, int>>();
            while (text.ReadLine() is { } line)
            {
                if (line.Contains("move"))
                {
                    var lineSplitUp = line.Split(' ');
                    var numbersOnLine = new List<int>();
                    foreach (string part in lineSplitUp)
                    {
                        if (int.TryParse(part, out int number))
                        {
                            numbersOnLine.Add(number);
                        }
                    }

                    commandsList.Add(new Tuple<int, int, int>(numbersOnLine[0], numbersOnLine[1] - 1, numbersOnLine[2] - 1));
                }
            }

            return commandsList;
        }

        public static string Task1Solution(Dictionary<int, List<char>> map, IEnumerable<Tuple<int, int, int>> commands)
        {
            foreach (Tuple<int, int, int> command in commands)
            {
            // Take the first command.item1 items and make them be the first three in reverse in the new.
                var cratesToMove = map[command.Item2].Take(command.Item1);
                map[command.Item3].InsertRange(0, cratesToMove.Reverse());
                for (int i = 0; i < command.Item1; i++)
                {
                    map[command.Item2].RemoveAt(0);
                }
                 // a b c d h u r b + a c b => b c a a b c d h u r b a c b 
            }
            // Add first of each 
            string finalString = "";
            for (int e = 0; e < map.Keys.Count; e++)
            {
                finalString += map[e].First();
            }
            return finalString;
        }

        public static string Task1Solution()
        {
            var initialInput = GetInput();
            var map = CreateCrateMap(initialInput);
            var commands = CreateCommandsList(initialInput);
            return Task1Solution(map, commands);
        }
        
        public static string Task2Solution(Dictionary<int, List<char>> map, IEnumerable<Tuple<int, int, int>> commands)
        {
            foreach (Tuple<int, int, int> command in commands)
            {
                // Take the first command.item1 items and make them be the first three in reverse in the new.
                var cratesToMove = map[command.Item2].Take(command.Item1);
                map[command.Item3].InsertRange(0, cratesToMove);
                for (int i = 0; i < command.Item1; i++)
                {
                    map[command.Item2].RemoveAt(0);
                }
                // a b c d h u r b + a c b => b c a a b c d h u r b a c b 
            }
            // Add first of each 
            string finalString = "";
            for (int e = 0; e < map.Keys.Count; e++)
            {
                finalString += map[e].First();
            }
            return finalString;
        }

        public static string Task2Solution()
        {
            var initialInput = GetInput();
            var map = CreateCrateMap(initialInput);
            var commands = CreateCommandsList(initialInput);
            return Task2Solution(map, commands);
        }
        /*
               public static List<Tuple<int, int, int, int>> ProcessInputFile(TextReader text)
               {// Check how many lines until "1"
                   // From 0 to (amount of lines until "1" - 1) 
                   var results = new List<Tuple<int, int, int>>();
                   while (text.ReadLine() is { } line)
                   {
                       for (int i = 2; i < line.Length; i++)
                       {
                           if (line[i - 2].Equals('[') && line[i].Equals(']'))
                           {
                               crateMap[i].Add(new Crate(line[i - 1]));
                           }
                       }
                       
                       if (splitLine.Contains("move"))
                       {
                           // Stop creating map. 
                       }
                   }
                   return results;
               }
           }
           */
    }
}