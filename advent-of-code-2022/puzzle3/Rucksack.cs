using System;
using System.Collections.Generic;
using System.Linq;

namespace advent_of_code_2022.puzzle3
{

    public class Rucksack
    {
        private string ItemsInString;
        private IEnumerable<CompartmentItem> FirstCompartment { get; set; }
        private IEnumerable<CompartmentItem> SecondCompartment { get; set; }

        public Rucksack(string items)
        {
            ItemsInString = items;
            FirstCompartment = new List<CompartmentItem>();
            SecondCompartment = new List<CompartmentItem>();
        }

        public void FillCompartments()
        {
            FirstCompartment = ItemsInString.Substring(0, ItemsInString.Length / 2)
                .ToArray().Select(g => new CompartmentItem(g));
            SecondCompartment = ItemsInString.Substring(ItemsInString.Length / 2)
                .ToArray().Select(g => new CompartmentItem(g));
        }

        public CompartmentItem FindCommonItem()
        {
            IEnumerable<char> firstCompartmentChars = FirstCompartment.Select(g => g.CharValue); 
            foreach (CompartmentItem item in SecondCompartment)
            {
                if (firstCompartmentChars.Contains(item.CharValue))
                {
                    return item;
                }
            }
            throw new InvalidOperationException("Couldn't find a common item!");
        }


        public IEnumerable<char> GetFirstCompartmentChars()
        {
            return FirstCompartment.Select(g => g.CharValue);
        }

        public IEnumerable<char> GetSecondCompartmentChars()
        {
            return SecondCompartment.Select(g => g.CharValue);
        }
    }
}
