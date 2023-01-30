﻿using VetAwesome.Bll.Interfaces.RandomDataMakers;

namespace VetAwesome.Bll.RandomDataMakers
{
    public class RandomNameMaker : RandomDataMaker, IRandomNameMaker
    {
        #region Names
        private readonly List<string> firstNames = new();
        private readonly List<string> lastNames = new()
            {
                "Martinez",
                "Leon",
                "Key",
                "Miller",
                "Zuniga",
                "Guerrero",
                "Green",
                "Roy",
                "Villarreal",
                "Olsen",
                "Elliott",
                "Moreno",
                "Russo",
                "Flynn",
                "Jackson",
                "Dunlap",
                "Mathews",
                "Montoya",
                "Kramer",
                "Roach",
                "Chandler",
                "Cuevas",
                "Nelson",
                "Zamora",
                "Griffith",
                "Preston",
                "Baker",
                "Mcfarland",
                "Cox",
                "Gross",
                "Gallagher",
                "Dalton",
                "Cameron",
                "Paul",
                "Ponce",
                "Osborne",
                "Quinn",
                "Oconnor",
                "Fitzgerald",
                "Gray",
                "Barrera",
                "Small",
                "Reyes",
                "Greer",
                "Wagner",
                "Hickman",
                "Willis",
                "Glass",
                "Peterson",
                "Cannon"
            };
        private readonly List<string> maleNames = new()
        {
            "Korbin",
            "Christopher",
            "Jorge",
            "Russell",
            "Camron",
            "Aidan",
            "Darren",
            "Sonny",
            "Jackson",
            "Alexander",
            "Dillon",
            "Christian",
            "Alonso",
            "Fisher",
            "Noel",
            "Lawson",
            "Franco",
            "Harrison",
            "Edgar",
            "Draven",
            "Keith",
            "Jalen",
            "Victor",
            "Kylan",
            "Antonio",
            "Lincoln",
            "Cruz",
            "Abraham",
            "Cordell",
            "Junior",
            "Keaton",
            "Marc",
            "Sam",
            "Trey",
            "Ernesto",
            "Reed",
            "Emilio",
            "Kendall",
            "Dayton",
            "Gerald",
            "Matteo",
            "Hector",
            "Octavio",
            "Winston",
            "Ashton",
            "Everett",
            "Jonah",
            "Colten",
            "Conner",
            "Jair"
        };
        private readonly List<string> femaleNames = new()
        {
            "Annabelle",
            "Evelyn",
            "Alaina",
            "Sariah",
            "Kaitlyn",
            "Madalynn",
            "Kayley",
            "Gina",
            "Campbell",
            "Dakota",
            "Shania",
            "Nathalia",
            "Audrina",
            "Michelle",
            "Chloe",
            "Kristin",
            "Mareli",
            "Adelyn",
            "Shaylee",
            "Karlee",
            "Josephine",
            "Aileen",
            "Beatrice",
            "Lauryn",
            "Diya",
            "Hope",
            "Emelia",
            "Iliana",
            "Jessie",
            "Annalise",
            "Karissa",
            "Karlie",
            "Lucia",
            "Livia",
            "Kiara",
            "Diana",
            "Zariah",
            "Amara",
            "Jazmine",
            "Rosemary",
            "Kenley",
            "Lilah",
            "Karla",
            "Mariela",
            "Abigail",
            "Aimee",
            "Makaila",
            "Ariana",
            "Jordyn",
            "Arabella"
        };
        #endregion

        public RandomNameMaker()
        {
            firstNames.AddRange(maleNames);
            firstNames.AddRange(femaleNames);
        }

        public string MakeFirstName()
        {
            return GetRandomElement(firstNames);
        }

        public string MakeFemaleName()
        {
            return GetRandomElement(femaleNames);
        }

        public string MakeMaleName()
        {
            return GetRandomElement(maleNames);
        }

        public string MakeLastName()
        {
            return GetRandomElement(lastNames);
        }
    }
}
