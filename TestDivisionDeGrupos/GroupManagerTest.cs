using NUnit.Framework;
using divisionDeGrupos;
using System.Linq;
using System.IO;
using System.Collections.Generic;


namespace TestDivisionDeGrupos
{
    public class GroupManagerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GroupManager_elements_with_no_remanent()
        {
            GroupManager manager = new GroupManager();

            List<string> elements = new List<string>()
            {
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
                "11",
                "12",
                "13",
                "14",
                "15"
            };

            int numberOfGroups = 5;

            List<string>[] groups = manager.RandomizeGroups(elements, numberOfGroups);

            Assert.That(groups.Select(group => group.Count), Is.All.EqualTo(3));




        }

        [Test]
        public void GroupManager_RandomizeGroups_elements_with_remanent()
        {
            GroupManager manager = new GroupManager();
            int numberOfGroups = 5;
            List<string> groups = new List<string>()
            {
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
                "11",
                "12",
                "13",
                "14",
                "15"
            };
            Assert.Pass();
        }

        [Test]
        public void GroupManager_RandomNumber()
        {
            GroupManager manager = new GroupManager();
            Assert.Pass();
        }
    }
}