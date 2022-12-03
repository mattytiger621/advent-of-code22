using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_of_code_2022.puzzle3
{
    public class Advent3
    {
        private const string FILE_NAME = "puzzle3/input.txt";
        
        public static int FindSumOfPriorities()
        {
            int finalSum = 0;
            StreamReader sr = System.IO.File.OpenText(FILE_NAME);
            string line = sr.ReadLine();
            while (line != null)
            {
                Rucksack rs = new Rucksack(line);
                rs.FillCompartments();
                finalSum += rs.FindCommonItem().GetPriorityValue();
                line = sr.ReadLine();
            }
            return finalSum;
        }

        public static int FindSumOfBadgePriorities()
        {
            int finalSum = 0;
            int lineCounter = 1;
            Dictionary<int, List<char>> threeLineCollection = new Dictionary<int, List<char>>();
            StreamReader sr = System.IO.File.OpenText(FILE_NAME);
            string line = sr.ReadLine();
            while (line != null)
            {
                if (lineCounter == 3)
                {
                    foreach (char letter in line)
                    {
                        if (threeLineCollection[1].Contains(letter) && threeLineCollection[2].Contains(letter))
                        {
                            Badge badge = new Badge(letter);
                            finalSum += badge.GetPriorityValue();
                            threeLineCollection.Clear();
                            lineCounter = 0;
                            break;
                        }
                    }
                }
                threeLineCollection[lineCounter] = line.ToCharArray().ToList();
                lineCounter++;
                line = sr.ReadLine();
            }
            return finalSum;
        }
    }
}