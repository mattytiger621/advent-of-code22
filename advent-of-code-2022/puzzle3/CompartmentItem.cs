using System;

namespace advent_of_code_2022.puzzle3
{



    public class CompartmentItem
    {
        public char CharValue { get; set; }

        public CompartmentItem(char letter)
        {
            CharValue = letter;
        }

        public int GetPriorityValue()
        {
            /*
            if (item.CharValue)
            {
                throw new ArgumentException("Item does not have a character set to it.");
            }
            */
            if (Char.IsUpper(CharValue))
            {
                int index = 'Z' - CharValue;
                return (52 - index);
            }

            return (26 - ('z' - CharValue));
        }
    }
}