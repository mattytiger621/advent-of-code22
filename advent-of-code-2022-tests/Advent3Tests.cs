using System;
using NUnit.Framework;
using advent_of_code_2022.puzzle3;

namespace TestProject2
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void GetFirstCompartmentChars_OrdinaryString_RuckSackIsCorrect()
            {
                Rucksack rs = new Rucksack("vJrwpWtwJgWrhcsFMMfFFhFp");
                rs.FillCompartments();
                var compartment1 = "vJrwpWtwJgWr".ToCharArray();
                Assert.AreEqual(compartment1, rs.GetFirstCompartmentChars());
            }
            
        [Test]
            public void GetSecondCompartmentChars_OrdinaryString_RuckSackIsCorrect()
            {
                Rucksack rs = new Rucksack("vJrwpWtwJgWrhcsFMMfFFhFp");
                rs.FillCompartments();
                var compartment2 = "hcsFMMfFFhFp".ToCharArray();
                Assert.AreEqual(compartment2, rs.GetSecondCompartmentChars());
            }

            [Test]
            public void PriorityValue_LowercaseA_1()
            {
                CompartmentItem a = new CompartmentItem('a');
                Assert.AreEqual(1, a.GetPriorityValue());
            }
            
            [Test]
            public void PriorityValue_UppercaseA_1()
            {
                CompartmentItem a = new CompartmentItem('A');
                Assert.AreEqual(27, a.GetPriorityValue());
            }
            
            [Test]
            public void PriorityValue_LowercaseE_5()
            {
                CompartmentItem a = new CompartmentItem('e');
                Assert.AreEqual(5, a.GetPriorityValue());
            }
            
            [Test]
            public void PriorityValue_LowercaseE_Y()
            {
                CompartmentItem a = new CompartmentItem('y');
                Assert.AreEqual(25, a.GetPriorityValue());
            }
            
            [Test]
            public void PriorityValue_UppercaseY_1()
            {
                CompartmentItem a = new CompartmentItem('Y');
                Assert.AreEqual(51, a.GetPriorityValue());
            }
        }
    }
    