using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using UnityEngine;
using WorldMapStrategyKit;
using static CountryToGlobalCountry;
using static SpecialOperationsTeam;

#pragma warning disable 0168 // variable declared but not used.
#pragma warning disable 0219 // variable assigned but not used.
#pragma warning disable 0414 // private field assigned but not used.

namespace Assets
{


    public class ContactGenerator
    {
        public List<Gear> GearByType(KitType kitType)
        {
            return DefaultGearList().Where(kits => kits.GearKitType == kitType).ToList();
        }
        public TeamKits GenerateKit(KitType type)
        {
            var cg = new ContactGenerator();

            var newKit = new TeamKits()
            {
                Name = type.ToDescription(),
                KitGunHitRate = 85f,
                KitHealthHP = 100f,
                KitsKillSight = 75f,
                Kit = type,
                Gun = null
            };

            newKit.Gear = cg.GearByType(type);
            return newKit;
        }
        public List<Gear> DefaultGearList()
        {
            return new List<Gear>
                {
                    new Gear()
                    {

                    GearName = "Sniper Scope",
                    GearPerkType = KitValueType.GunAccurancy,
                    GearValue = 1.5f,
                    GearCount = 1,
                    GearKitType = KitType.Sniper
                    },
                    new Gear()
                    {

                    GearName = "Ghillie Suit",
                    GearPerkType = KitValueType.Armor,
                    GearValue = 1.5f,
                    GearCount = 1,
                    GearKitType = KitType.Sniper
                    },
                    new Gear()
                    {

                    GearName = "Range Finder",
                    GearPerkType = KitValueType.GunAccurancy,
                    GearValue = 1.5f,
                    GearCount = 1,
                    GearKitType = KitType.Sniper
                    },
                    new Gear()
                    {

                    GearName = "Mission Datalink",
                    GearPerkType = KitValueType.KillSight,
                    GearValue = 1.5f,
                    GearCount = 1,
                    GearKitType = KitType.Sniper
                    },
                    new Gear()
                    {

                    GearName = "Bipod",
                    GearPerkType = KitValueType.GunAccurancy,
                    GearValue = 1.5f,
                    GearCount = 1,
                    GearKitType = KitType.Sniper
                    },

                    new Gear()
                    {

                    GearName = "40mm Grenade Launcher",
                    GearPerkType = KitValueType.Ammo,
                    GearValue = 1.5f,
                    GearCount = 8,
                    GearKitType = KitType.Assault
                    },
                    new Gear()
                    {

                    GearName = "Body Armor",
                    GearPerkType = KitValueType.Armor,
                    GearValue = 1.5f,
                    GearCount = 1,
                    GearKitType = KitType.Assault
                    },
                    new Gear()
                    {

                    GearName = "Enhanced NVGs",
                    GearPerkType = KitValueType.KillSight,
                    GearValue = 1.5f,
                    GearCount = 1,
                    GearKitType = KitType.Assault
                    },
                    new Gear()
                    {

                    GearName = "Smoke grenades",
                    GearPerkType = KitValueType.Grenade,
                    GearValue = 1.5f,
                    GearCount = 4,
                    GearKitType = KitType.Any
                    },
                    new Gear()
                    {

                    GearName = "ACOG Scope",
                    GearPerkType = KitValueType.GunAccurancy,
                    GearValue = 1.5f,
                    GearCount = 1,
                    GearKitType = KitType.Assault
                    },
                    new Gear()
                    {

                    GearName = "Gunshot wound Kit",
                    GearPerkType = KitValueType.Health,
                    GearValue = 1.5f,
                    GearCount = 5,
                    GearKitType = KitType.Medic

                    },
                    new Gear()
                    {

                    GearName = "Body Armor",
                    GearPerkType = KitValueType.Armor,
                    GearValue = 1.5f,
                    GearCount = 1,
                    GearKitType = KitType.Medic
                    },
                    new Gear()
                    {

                    GearName = "Shrapnel wound kit",
                    GearPerkType = KitValueType.Health,
                    GearValue = 1.5f,
                    GearCount = 1,
                    GearKitType = KitType.Medic
                    },
                    new Gear()
                    {

                    GearName = "defibrillator",
                    GearPerkType = KitValueType.Health,
                    GearValue = 1.5f,
                    GearCount = 1,
                    GearKitType = KitType.Medic
                    },
                    new Gear()
                    {

                    GearName = "bleed powder",
                    GearPerkType = KitValueType.Health,
                    GearValue = 1.5f,
                    GearCount = 5,
                    GearKitType = KitType.Medic
                    },
                    new Gear()
                    {

                    GearName = "40mm Grenade Launcher",
                    GearPerkType = KitValueType.Ammo,
                    GearValue = 1.5f,
                    GearCount = 5,
                    GearKitType = KitType.Grenadier
                    },
                    new Gear()
                    {

                    GearName = "Body Armor",
                    GearPerkType = KitValueType.Armor,
                    GearValue = 1.5f,
                    GearCount = 1,
                    GearKitType = KitType.Grenadier
                    },
                    new Gear()
                    {

                    GearName = "Enhanced NVGs",
                    GearPerkType = KitValueType.GunAccurancy,
                    GearValue = 1.5f,
                    GearCount = 1,
                    GearKitType = KitType.Grenadier
                    },
                    new Gear()
                    {

                    GearName = "Claymore",
                    GearPerkType = KitValueType.Grenade,
                    GearValue = 1.5f,
                    GearCount = 2,
                    GearKitType = KitType.Grenadier
                    },
                    new Gear()
                    {

                    GearName = "Grip",
                    GearPerkType = KitValueType.GunAccurancy,
                    GearValue = 1.5f,
                    GearCount = 1,
                    GearKitType = KitType.Any
                    },
                    new Gear()
                    {

                    GearName = "556mm Ammo",
                    GearPerkType = KitValueType.Ammo,
                    GearValue = 1.5f,
                    GearCount = 5,
                    GearKitType = KitType.Any
                    },
                    new Gear()
                    {

                    GearName = "Body Armor",
                    GearPerkType = KitValueType.Armor,
                    GearValue = 1.5f,
                    GearCount = 1,
                    GearKitType = KitType.SquadLeader
                    },
                    new Gear()
                    {

                    GearName = "Enhanced NVGs",
                    GearPerkType = KitValueType.GunAccurancy,
                    GearValue = 1.5f,
                    GearCount = 1,
                    GearKitType = KitType.SquadLeader
                    },
                    new Gear()
                    {

                    GearName = "Bincolars",
                    GearPerkType = KitValueType.GunAccurancy,
                    GearValue = 1.5f,
                    GearCount = 2,
                    GearKitType = KitType.SquadLeader
                    },
                    new Gear()
                    {
                    GearName = "Radio",
                    GearPerkType = KitValueType.KillSight,
                    GearValue = 1.5f,
                    GearCount = 1,
                    GearKitType = KitType.Nco
                    },new Gear()
                    {

                    GearName = "Grip",
                    GearPerkType = KitValueType.GunAccurancy,
                    GearValue = 1.5f,
                    GearCount = 1,
                    GearKitType = KitType.Nco
                    }
                    ,new Gear()
                    {

                    GearName = "Body Armor",
                    GearPerkType = KitValueType.Armor,
                    GearValue = 1.5f,
                    GearCount = 1,
                    GearKitType = KitType.Nco
                    }
                    ,new Gear()
                    {

                    GearName = "ACOG Scope",
                    GearPerkType = KitValueType.GunAccurancy,
                    GearValue = 1.5f,
                    GearCount = 1,
                    GearKitType = KitType.Nco
                    }
                    ,new Gear()
                    {

                    GearName = "Bipod",
                    GearPerkType = KitValueType.GunAccurancy,
                    GearValue = 1.5f,
                    GearCount = 1,
                    GearKitType = KitType.SAW
                    }
                     ,new Gear()
                    {

                    GearName = "5.56mm Ammo",
                    GearPerkType = KitValueType.Ammo,
                    GearValue = 1.5f,
                    GearCount = 1,
                    GearKitType = KitType.SAW
                    }
                      ,new Gear()
                    {

                    GearName = "Heavy Barrel",
                    GearPerkType = KitValueType.GunAccurancy,
                    GearValue = 1.5f,
                    GearCount = 1,
                    GearKitType = KitType.SAW
                    }
                      ,new Gear()
                    {

                    GearName = "Body Armor",
                    GearPerkType = KitValueType.Armor,
                    GearValue = 1.5f,
                    GearCount = 1,
                    GearKitType = KitType.SAW
                    }
                    };
        }
        #region Constants

        #region Squad Names

        public static string[] ChineseSquads =
      {
            // A Male names
            "Blade",
            "Arrow",
            "Falcon",
            "Tiger",
            "Flying Dragon",
            "Oscar",
            "Bat",
            "Eagle",
            "Backfire",
            "Owl",
            "Blackjack",
            "Sword",
            "Sea Dragon",
            "Dragon",
            "South",
            "Jade",
            "Monokey",
            "Crane",
            "Mantis",
            "Panada",
            "Snow leopard",
            "Thundergod"
        };

        public static string[] WesternSquads =
       {
            // A Male names
            "Alpha",
            "Bravo",
            "Charlie",
            "Delta",
            "Echo",
            "Foxtrot",
            "Golf",
            "Hotel",
            "India",
            "Juliet",
            "Kilo",
            "Lima",
            "Mike",
            "November",
            "Oscar",
            "Papa",
            "Quebec",
            "Romeo",
            "Sierra",
            "Tango",
            "Uniform",
            "Victor",
            "Whiskey",
            "X-Ray",
            "Yankee",
            "Zulu",
                "Adam",
                "Able",
                "Baker",
                "Charlie",
                "David",
               "Easy",
                "Frank",
               "Georg",
                "Henry",
                "Item",
                "Johnn",
                "King",
                "Love",
                "Mike",
                "Nab/N",
                "Oboe",
                "Peter",
                "Queen",
                "Roger",
                "Sugar",
                "Tare",
                "Uncle",
                "Victo",
                "William",
                "X-Ray",
                "Yoke",
                "Zebra",
                "Dog",
                "Easy",
                "Fox",
                "George",
                "How",
                "Item",
                "Jig",
                "King",
                "Roger",
                "Sugar",
                "Tare",
                "Uncle",
                "Victor",
                "William ",
                "Yoke",
                "Edward",
                "George",
                "John",
                "Lincoln",
                "Mary",
                "Ocean",
                "Robert",
                "Sam",
                "Tom",
                "Union",
        };
        #endregion

        #region First Names Female
        /// <summary>
        /// The f fname.
        /// </summary>
        public static string[] FFname =
        {
// A Female names
            "Abby",
            "Abigail",
            "Ada",
            "Adrianna",
            "Adrienne",
            "Aggie",
            "Alex",
            "Alexandra",
            "Alice",
            "Alicia",
            "Alison",
            "Alli",
            "Allison",
            "Alma",
            "Amanda",
            "Amber",
            "Ambrosia",
            "Ameera",
            "Amy",
            "Andrea",
            "Angela",
            "Angelica",
            "Angelina",
            "Angelique",
            "Angie",
            "Anjelica",
            "Ann",
            "Anna",
            "Annabelle",
            "Anne",
            "Annie",
            "April",
            "Arielle",
            "Ashlee",
            "Ashley",
            "Audrey",
            "Ava", 

// B Female names
            "Babe",
            "Barbara",
            "Beatrice",
            "Becca",
            "Belle",
            "Bernice",
            "Bertha",
            "Beth",
            "Bethany",
            "Betsy",
            "Bianca",
            "Bridget",
            "Britta",
            "Brittany",
            "Bo",
            "Bobbie",
            "Bonnie",
            "Brenda",
            "Britta",
            "Brooke", 

// C Female names
            "Calliope",
            "Cameron",
            "Camellia",
            "Camilla",
            "Camille",
            "Cara",
            "Carmilla",
            "Carla",
            "Carly",
            "Carol",
            "Caroline",
            "Cass",
            "Cassandra",
            "Cassie",
            "Catlin",
            "Caitlin",
            "Cecile",
            "Charlene",
            "Cheryl",
            "Celia",
            "Celeste",
            "Charlotte",
            "Chelsea",
            "Cheryl",
            "Chloe",
            "Christine",
            "Ciara",
            "Cindy",
            "Claire",
            "Clara",
            "Clarice",
            "Clarissa",
            "Claudia",
            "Colleen",
            "Constance",
            "Cordelia",
            "Courtney",
            "Cricket",
            "Crystal", 

// D Female names
            "Daisy",
            "Dana",
            "Danielle",
            "Danni",
            "Daphne",
            "Darla",
            "Dawn",
            "Debbie",
            "Deborah",
            "Dee",
            "Delfina",
            "Desiree",
            "Deveney",
            "Di",
            "Diana",
            "Diane",
            "Dinah",
            "Dixie",
            "Dominique",
            "Donna",
            "Doris", 

// E Female names
            "Edith",
            "Emily",
            "Emma",
            "Emmy",
            "Eileen",
            "Elena",
            "Elizabeth",
            "Elle",
            "Epiphany",
            "Erica",
            "Erin",
            "Etta",
            "Eve", 

// F Female names
            "Faith",
            "Farah",
            "Felicia",
            "Flo",
            "Frankie",
            "Frannie", 

// G Female names
            "Gabriella",
            "Gabrielle",
            "Georgie",
            "Georgina",
            "Ginny",
            "Gillian",
            "Gina",
            "Ginger",
            "Giselle",
            "Gloria",
            "Grace",
            "Greenlee",
            "Gwen", 

// H Female names
            "Haley",
            "Hannah",
            "Hayley",
            "Heather",
            "Helen",
            "Helena",
            "Helga",
            "Hillary",
            "Holly",
            "Hope", 

// I Female names
            "Ilana",
            "Ilsa",
            "Iris",
            "Isabella",
            "Iva",
            "Ivy", 

// J Female names
            "Jade",
            "Jamie",
            "Jane",
            "Janet",
            "Janene",
            "Janice",
            "Jaqueline",
            "Jasmine",
            "Jen",
            "Jenna",
            "Jennifer",
            "Jenny",
            "Jessica",
            "Joan",
            "Jordan",
            "Josephine",
            "Josie",
            "Josslyn",
            "Joy",
            "Joyce",
            "Julia",
            "Julie",
            "Juliet",
            "June",
            "Justine", 

// K Female names
            "Karen",
            "Kate",
            "Katherine",
            "Kathleen",
            "Kathy",
            "Katie",
            "Kayla",
            "Keesha",
            "Kelly",
            "Kendra",
            "Kim",
            "Kimberly",
            "Kit",
            "Kelly",
            "Kristin",
            "Kristina",
            "Krystal", 

// L Female names
            "Lainy",
            "Lana",
            "Laura",
            "Laurel",
            "Lauren",
            "Leigh",
            "Leora",
            "Letitia",
            "Leslie",
            "Lexie",
            "Leyla",
            "Liberty",
            "Libby",
            "Lila",
            "Lily",
            "Linda",
            "Lindsay",
            "Lisa",
            "Lisanne",
            "Liz",
            "Liza",
            "Lois",
            "Lorena",
            "Loretta",
            "Lorna",
            "Louise",
            "Lucinda",
            "Lucy",
            "Lulu",
            "Lydia", 

// M Female names
            "Macy",
            "Maddie",
            "Madge",
            "Madison",
            "Maelani",
            "Maggie",
            "Maisie",
            "Marcy",
            "Margo",
            "Maria",
            "Marian",
            "Marianne",
            "Marie",
            "Marissa",
            "Marla",
            "Marlena",
            "Marlene",
            "Mary",
            "Martha",
            "Maxie",
            "Maxine",
            "Meg",
            "Melinda",
            "Melissa",
            "Mercedes",
            "Mia",
            "Mimi",
            "Miranda",
            "Missy",
            "Molly",
            "Mona",
            "Monica",
            "Morgan",
            "Myrtle", 

// N Female names
            "Nadia",
            "Nadine",
            "Nancy",
            "Naomi",
            "Natalia",
            "Natalie",
            "Nicole",
            "Nika",
            "Nikki",
            "Nina", 

// O Female names
            "Olivia",
            "Opal", 

// P Female names
            "Paige",
            "Pam",
            "Pamela",
            "Patricia",
            "Paula",
            "Peggy",
            "Penelope",
            "Penny",
            "Phoebe",
            "Phyllis",
            "Piper",
            "Prudence", 

// R Female names
            "Rachel",
            "Rae",
            "Randi",
            "Rebecca",
            "Reena",
            "Regina",
            "Rhonda",
            "Robin",
            "Rosa",
            "Rosanna",
            "Rose",
            "Rosie",
            "Roxanne",
            "Ruby",
            "Ruth", 

// S Female names
            "Sabrina",
            "Sage",
            "Sally",
            "Samantha",
            "Sandy",
            "Santana",
            "Sasha",
            "Savannah",
            "Shannon",
            "Sharlene",
            "Sierra",
            "Silver",
            "Simone",
            "Skye",
            "Sofia",
            "Sofie",
            "Stacey",
            "Steffy",
            "Stephanie",
            "Storm",
            "Sue",
            "Susan",
            "Sylvie", 

// T Female names
            "Tabitha",
            "Tamara",
            "Tara",
            "Tawny",
            "Taylor",
            "Terri",
            "Tess",
            "Theresa",
            "Therese",
            "Thomasina",
            "Tiffany",
            "Tina",
            "Toni",
            "Tracy",
            "Tricia",
            "Trish",
            "Trisha",
            "Trista",
            "Trixie", 

// V Female names
            "Vanessa",
            "Vicky",
            "Vienna",
            "Vivian",
            "Vivien", 

// W Female names
            "Willow", 

// Z Female names
            "Zoe"
        };
        #endregion

        #region Asian Last Name
        public static string[] AsianLName =
        {
            "Lǐ",
            "Wáng",
            "Zhāng",
            "Liú",
            "Chén",
            "Yáng",
            "Zhào",
            "Huáng",
            "Zhōu",
            "Wú",
            "Xú",
            "Sūn",
            "Hú",
            "Zhū",
            "Gāo",
            "Lín",
            "Hé",
            "Guō",
            "Mǎ",
            "Luó",
            "Liáng",
            "Sòng",
            "Zhèng",
            "Xiè",
            "Hán",
            "Táng",
            "Féng",
            "Yú",
            "Dǒng",
            "Xiāo",
            "Chéng",
            "Cáo",
            "Yuán",
            "Dèng",
            "Xǔ",
            "Fù",
            "Shěn",
            "Zēng",
            "Péng",
            "Lǚ",
            "Sū",
            "Lú",
            "Jiǎng",
            "Cài",
            "Jiǎ",
            "Dīng",
            "Wèi",
            "Xuē",
            "Yè",
            "Yán",
            "Yú",
            "Pān",
            "Dài",
            "Xià",
            "Zhōng",
            "Wāng",
            "Tián",
            "Rén",
            "Jiāng",
            "Fàn",
            "Fāng",
            "Shí",
            "Yáo",
            "Tán",
            "Shèng",
            "Zōu",
            "Xióng",
            "Jīn",
            "Lù",
            "Hǎo",
            "Kǒng",
            "Bái",
            "Cuī",
            "Kāng",
            "Máo",
            "Qiū",
            "Qín",
            "Jiāng",
            "Shǐ",
            "Gù",
            "Hóu",
            "Shào",
            "Mèng",
            "Lóng",
            "Duàn",
            "Zhāng",
            "Qián",
            "Tāng",
            "Yǐn",
            "Lí",
            "Yì",
            "Cháng",
            "Wǔ",
            "Qiáo",
            "Hè",
            "Lài",
            "Gōng",
            "Wén"
        };

        #endregion

        #region Last Name
        /// <summary>
        /// The l name.
        /// </summary>
        public static string[] LName =
        {
// A Surnames
            "Abrahms",
            "Abrams",
            "Adair",
            "Adams",
            "Adamson",
            "Addison",
            "Addy",
            "Adler",
            "Alcazar",
            "Alcott",
            "Alexander",
            "Alonso",
            "Alpert",
            "Anderson",
            "Andrassy",
            "Andrews",
            "Andropoulos",
            "Ardanowski",
            "Archer",
            "Arena",
            "Arnett",
            "Ashley",
            "Ashton",
            "Atkins",
            "Austen",
            "Austin",
            "Ali Aziz",
            "Arzt", 

// B Surnames
            "Baker",
            "Baldwin",
            "Bancroft",
            "Banning",
            "Barasa",
            "Barber",
            "Barelli",
            "Barnard",
            "Barrett",
            "Barrington",
            "Bass",
            "Bauer",
            "Baxter",
            "Beaudry",
            "Beck",
            "Bedford",
            "Bell",
            "Bellman",
            "Bennett",
            "Bentley",
            "Benton",
            "Bergman",
            "Berry",
            "Bingham",
            "Bishop",
            "Black",
            "Blake",
            "Blanchard",
            "Booth",
            "Bordisso",
            "Bowen",
            "Boyd",
            "Brady",
            "Bray",
            "Brent",
            "Brewer",
            "Brezetta",
            "Broadsky",
            "Brock",
            "Brooke",
            "Brookes",
            "Brown",
            "Browning",
            "Burgess",
            "Burley",
            "Buchanan",
            "Burke",
            "Burns",
            "Burrell",
            "Butler", 

// C Surnames
            "Cabot",
            "Caldwell",
            "Calhoon",
            "Callahan",
            "Cambias",
            "Campbell",
            "Capelli",
            "Capello",
            "Carey",
            "Carlino",
            "Carlyle",
            "Carner",
            "Carrington",
            "Carroll",
            "Carson",
            "Carter",
            "Carver",
            "Cassadine",
            "Cassady",
            "Castillo",
            "Cates",
            "Cerullo",
            "Chacone",
            "Chamberlain",
            "Chambers",
            "Chandler",
            "Chang",
            "Channing",
            "Chapin",
            "Chilson",
            "Chung",
            "Ciccone",
            "Clampett",
            "Clark",
            "Clayton",
            "Clinton",
            "Coates",
            "Coe",
            "Colby",
            "Coleman",
            "Collins",
            "Colton",
            "Conley",
            "Connell",
            "Connelly",
            "Conway",
            "Cook",
            "Cooney",
            "Cooper",
            "Corbin",
            "Corelli",
            "Corinthos",
            "Corning",
            "Cortez",
            "Cortlandt",
            "Cory",
            "Cosgrove",
            "Coulson",
            "Cramer",
            "Crow",
            "Crowell",
            "Cudahy",
            "Cullen",
            "Cummings",
            "Curtin", 

// D Surnames
            "Dalton",
            "Damiano",
            "Dane",
            "Dante",
            "Darros",
            "Davidovitch",
            "Davidson",
            "Davis",
            "Davison",
            "Dawson",
            "Decker",
            "Delafield",
            "DePoulignac",
            "DeWitt",
            "Delaney",
            "Delorean",
            "Devane",
            "Deveraux",
            "Devlin",
            "Devon",
            "Dillon",
            "DiLucca",
            "DiMera",
            "Dimestico",
            "Dixon",
            "Dominguez",
            "Donely",
            "Donev",
            "Donovan",
            "Dorman",
            "Douglas",
            "Downs",
            "Drake",
            "Driscoll",
            "Dumbrowski",
            "Dubois",
            "DuPres",
            "Durban",
            "Dudley",
            "Dunlap",
            "Duran",
            "Duvalier",
            "Duvall",
            "Dwire", 

// E Surnames
            "Eckert",
            "Eckley",
            "Edison",
            "Edwards",
            "Ellis",
            "Ellison",
            "Eppes",
            "English",
            "Erosa",
            "Estaban",
            "Evans",
            "Ewing", 

// F Surnames
            "Fabray",
            "Fairchild",
            "Faison",
            "Falconeri",
            "Faraday",
            "Fargate",
            "Fargo",
            "Farrell",
            "Faulk",
            "Faulkner",
            "Feinberg",
            "Fenton",
            "Fields",
            "Filmore",
            "Fisher",
            "Fitz",
            "Floyd",
            "Flynn",
            "Ford",
            "Forrester",
            "Foster",
            "Fowler",
            "Frame",
            "Frank",
            "Frasier",
            "Fredericks",
            "Frye", 

// G Surnames
            "Gabriel",
            "Gallant",
            "Garcia",
            "Gardner",
            "Garrison",
            "Gerard",
            "Giambetti",
            "Gideon",
            "Gilchrist",
            "Glass",
            "Goddard",
            "Gold",
            "Goodman",
            "Gordon",
            "Gorrow",
            "Greco",
            "Grady",
            "Grant",
            "Gregory",
            "Grey",
            "Griffin",
            "Grimaldi",
            "Grove", 

// H Surnames
            "Halloway",
            "Hamilton",
            "Hanley",
            "Hansen",
            "Harding",
            "Hardy",
            "Harper",
            "Harris",
            "Harrison",
            "Hastings",
            "Haver",
            "Hayes",
            "Hayward",
            "Henry",
            "Herman",
            "Hernandez",
            "Hill",
            "Hobart",
            "Hobson",
            "Hodges",
            "Hodgins",
            "Hollister",
            "Holloway",
            "Holmes",
            "Holt",
            "Hopper",
            "Hornsby",
            "Horton",
            "Hotchner",
            "Howard",
            "Howell",
            "Hudson",
            "Hubbard",
            "Hughes",
            "Hume",
            "Hummel",
            "Hunter",
            "Huntington",
            "Hutchins",
            "Hyatt", 

// I Surnames
            "Ingstorm",
            "Ishmael", 

// J Surnames
            "Jacks",
            "Jackson",
            "Jamison",
            "Janacek",
            "Jefferson",
            "Jensen",
            "Jennings",
            "Jerome",
            "Joffe",
            "Johnson",
            "Jones",
            "Jordan",
            "Jourdan",
            "Juarez",
            "Julian", 

// K Surnames
            "Kane",
            "Karenin",
            "Kasnoff",
            "Karpov",
            "Keefer",
            "Keenan",
            "Kelly",
            "Kent",
            "Kenyon",
            "Kibideaux",
            "Kim",
            "Knight",
            "Koslof",
            "Kramer",
            "Kwon", 

// L Surnames
            "Lamonte",
            "Lanford",
            "Lang",
            "Lansing",
            "Larrabee",
            "LaSalle",
            "Laverty",
            "Lavery",
            "Lawrence",
            "Lawson",
            "Lee",
            "Leeds",
            "LeFleur",
            "LeSeur",
            "Lewis",
            "Limbo",
            "Lindeman",
            "Lindquist",
            "Linus",
            "Littleton",
            "Lloyd",
            "Locke",
            "Logan",
            "Lopez",
            "Love",
            "Lovejoy",
            "Lovett",
            "Lowell",
            "Lucas",
            "Lutz",
            "Lynley",
            "Lyons", 

// M Surnames
            "Maclaine",
            "Maclay",
            "MacIntyre",
            "Madden",
            "Madison",
            "Malone",
            "Marick",
            "Marone",
            "Marsh",
            "Marshak",
            "Marshall",
            "Martin",
            "Marquez",
            "Masters",
            "Mason",
            "May",
            "Mayer",
            "Matthews",
            "McCall",
            "McGowan",
            "McGrath",
            "McHenry",
            "McKay",
            "McKechnie",
            "McKee",
            "McKenna",
            "McKinnon",
            "McLeod",
            "McNamara",
            "McTavish",
            "Mendel",
            "Mercer",
            "Meritt",
            "Metcalf",
            "Meyer",
            "Miller",
            "Mills",
            "Mir",
            "Monroe",
            "Montenegro",
            "Montgomery",
            "Montoya",
            "Moody",
            "Moore",
            "Moreno",
            "Morez",
            "Morgan",
            "Moss",
            "Munoz",
            "Munson",
            "Murdock",
            "Murray", 

// N Surnames
            "Nadler",
            "Needham",
            "Nelson",
            "Nichols",
            "Nikos",
            "Niles",
            "Nolan",
            "Norbeck",
            "Norris",
            "North",
            "Novak", 

// O Surnames
            "O'Connor",
            "Oliver",
            "Olivera",
            "Olsen",
            "O'Neill",
            "Ordway",
            "O'Reilly",
            "O'Toole", 

// P Surnames
            "Pace",
            "Paget",
            "Palmer",
            "Parker",
            "Parrish",
            "Perrini",
            "Parros",
            "Petersen",
            "Peterson",
            "Phillips",
            "Pierce",
            "Pike",
            "Pinkham",
            "Price",
            "Prentice",
            "Puckerman",
            "Putnam", 

// Q Surnames
            "Quartermaine",
            "Quick",
            "Quinn", 

// R Surnames
            "Radcliffe",
            "Rain",
            "Ramirez",
            "Ramsey",
            "Randolph",
            "Rayne",
            "Rayner",
            "Reed",
            "Reid",
            "Reyes",
            "Reynolds",
            "Richards",
            "Richardson",
            "Rivera",
            "Roberts",
            "Robertson",
            "Rodriguez",
            "Rollo",
            "Rooney",
            "Rosco",
            "Rosenberg",
            "Roy",
            "Rudder",
            "Ruiz",
            "Rushinberger",
            "Rutherford",
            "Ryan", 

// S Surnames
            "Salor",
            "Sanchez",
            "Sanford",
            "Santiago",
            "Santos",
            "Saroyan",
            "Saunders",
            "Schuester",
            "Scott",
            "Scorpio",
            "Scully",
            "Sharpe",
            "Shaw",
            "Shore",
            "Shea",
            "Shearer",
            "Shepherd",
            "Sheppard",
            "Sheridan",
            "Shirazi",
            "Sidle",
            "Silver",
            "Simmons",
            "Simonelli",
            "Simpson",
            "Sinclair",
            "Singleton",
            "Slater",
            "Sloan",
            "Smith",
            "Smythe",
            "Sneed",
            "Snyder",
            "Soltini",
            "Soong",
            "Sorel",
            "Spectra",
            "Spencer",
            "Spinelli",
            "Stamp",
            "Stanton",
            "Stenbeck",
            "Sterling",
            "Stewart",
            "Stafford",
            "Stanton",
            "Stanwyck",
            "Stark",
            "Stephens",
            "Stevens",
            "St. John",
            "St. George",
            "Stokes",
            "Stone",
            "Strang",
            "Straume",
            "Strauss",
            "Stryker",
            "Sullivan",
            "Summers",
            "Swan",
            "Sweets",
            "Swenson",
            "Sylvester", 

// T Surnames
            "Taggert",
            "Talbot",
            "Tanner",
            "Taub",
            "Taylor",
            "Thatcher",
            "Templeton",
            "Thomas",
            "Thompson",
            "Todd",
            "Tolliver",
            "Torres",
            "Trudeau",
            "Tucker",
            "Turner",
            "Tyler", 

// U Surnames

// V Surnames
            "Vaughn",
            "Vega",
            "Venable",
            "Verdansky",
            "Vining", 

// W Surnames
            "Wainright",
            "Walker",
            "Wallace",
            "Wallingford",
            "Walsh",
            "Ward",
            "Warner",
            "Warwick",
            "Watkins",
            "Webster",
            "Weeks",
            "Welles",
            "Wells",
            "Welton",
            "Wexler",
            "Wheatley",
            "Wheeler",
            "Whittaker",
            "Wick",
            "Widmore",
            "Wilding",
            "Williams",
            "Willows",
            "Wilson",
            "Winslow",
            "Winthrop",
            "Witherspoon",
            "Woods",
            "Wyatt",
            "Wyman", 

// Y names
            "Yang", 

// Z Surnames
            "Zacchara"
        };

        #endregion

        #region Male First Name
        /// <summary>
        /// The m fname.
        /// </summary>
        public static string[] MFname =
        {
            // A Male names
            "Aaron",
            "Abe",
            "Abel",
            "Adam",
            "Aidan",
            "Aiden",
            "AJ",
            "Alan",
            "Alastair",
            "Alec",
            "Alexander",
            "Alex",
            "Alfred",
            "Andre",
            "Andy",
            "Anthony",
            "Anton",
            "Antonio",
            "Artie",
            "Asher",
            "August", 

// B Male names
            "Ben",
            "Benjamin",
            "Benjy",
            "Benny",
            "Bernard",
            "Bill",
            "Blaine",
            "Bo",
            "Bob",
            "Bobby",
            "Boone",
            "Brad",
            "Bradley",
            "Bradly",
            "Brandon",
            "Brett",
            "Brian",
            "Brot",
            "Burt",
            "Buzz", 

// C Male names
            "Cal",
            "Caleb",
            "Cameron",
            "Carl",
            "Carlos",
            "Carter",
            "Casey",
            "Casper",
            "Cassius",
            "Cesar",
            "Chad",
            "Charles",
            "Charley",
            "Charlie",
            "Chaz",
            "Chris",
            "Christian",
            "CJ",
            "Clark",
            "Clarke",
            "Clayton",
            "Cliff",
            "Colby",
            "Cole",
            "Coleman",
            "Colin",
            "Colton",
            "Connor",
            "Constantine",
            "Cooper",
            "Cory",
            "Craig",
            "Cruz",
            "Cyrus", 

// D Male names
            "Dabney",
            "Dallas",
            "Dan",
            "Daniel",
            "Danny",
            "Dante",
            "Darek",
            "Damian",
            "Damien",
            "Damon",
            "Dave",
            "David",
            "Deacon",
            "Dean",
            "Decker",
            "Dennis",
            "Denny",
            "Derek",
            "Desmond",
            "Diego",
            "Dillon",
            "Dimitri",
            "Dino",
            "Dixon",
            "Dominick",
            "Doug",
            "Douglas",
            "Dre",
            "Duke",
            "Duncan",
            "Dusty",
            "Dylan", 

// E Male names
            "Ed",
            "Edge",
            "Edmund",
            "Edward",
            "EJ",
            "Eli",
            "Elliot",
            "Elwood",
            "Emilio",
            "Eric",
            "Ernest",
            "Ernesto",
            "Ernie",
            "Ethan",
            "Eugene",
            "Evan", 

// F Male names
            "Finn",
            "Finnian",
            "Fletcher",
            "Ford",
            "Franco",
            "Francois",
            "Frankie",
            "Fred",
            "Frisco", 

// G Male names
            "Gabriel",
            "Gabe",
            "Garrett",
            "Gary",
            "Georgie",
            "Gerald",
            "Gil",
            "Giovanni",
            "Grady",
            "Graham",
            "Grant",
            "Gray",
            "Greg",
            "Gregory",
            "Griffin",
            "Gus",
            "Guy", 

// H Male names
            "Hal",
            "Harrison",
            "Harlan",
            "Harley",
            "Harper",
            "Harry",
            "Hart",
            "Hawk",
            "Hector",
            "Henderson",
            "Henry",
            "Holden",
            "Hunter",
            "Hutch", 

// I Male names
            "Ian",
            "Ivan", 

// J Male names
            "Jack",
            "Jackson",
            "Jagger",
            "Jake",
            "Jamal",
            "James",
            "Jamie",
            "Jason",
            "Jasper",
            "Jax",
            "Jed",
            "Jeff",
            "Jerry",
            "Jesse",
            "Jett",
            "JJ",
            "Jim",
            "Justin",
            "Justus",
            "Joe",
            "Joey",
            "John",
            "Johnny",
            "Jonah",
            "Jonas",
            "Jonathan",
            "Jose",
            "Josh",
            "Joshua",
            "JR",
            "Jude",
            "Justin", 

// K Male names
            "Kelly",
            "Ken",
            "Kendall",
            "Kent",
            "Kevin",
            "Kirk",
            "Kirkland",
            "Kurt",
            "Kyle", 

// L Male names
            "Lance",
            "Langley",
            "Larry",
            "Lee",
            "Leo",
            "Leonard",
            "Leopold",
            "Liam",
            "Lindsay",
            "Logan",
            "Lorenzo",
            "Lucas",
            "Luke",
            "Lynch", 

// M Male names
            "Mac",
            "Macauley",
            "Massimo",
            "Marco",
            "Marcus",
            "Mark",
            "Marley",
            "Marshall",
            "Martin",
            "Martino",
            "Marty",
            "Marvin",
            "Mateo",
            "Matt",
            "Matthew",
            "Maurice",
            "Max",
            "Michael",
            "Miguel",
            "Mike",
            "Milo",
            "Miles",
            "Mitch",
            "Mitchell",
            "MJ",
            "Monty",
            "Morgan", 

// N Male names
            "Nate",
            "Nathan",
            "Navid",
            "Neal",
            "Nicholas",
            "Nick",
            "Nikolas",
            "Niles",
            "Neil",
            "Noah",
            "Norman", 

// O Male names
            "Owen", 

// P Male names
            "Palmer",
            "Paolo",
            "Parker",
            "Pat",
            "Patrick",
            "Paul",
            "Pauly",
            "Perry",
            "Pete",
            "Peter",
            "Petrov",
            "Phil",
            "Philip",
            "Pierce",
            "Pierre",
            "Porter",
            "Prescott",
            "Preston", 

// Q Male names
            "Quentin",
            "Quinn", 

// R Male names
            "Rafe",
            "Rafael",
            "Ray",
            "Raymond",
            "Reece",
            "Reginald",
            "Reggie",
            "Reid",
            "Remy",
            "Reuben",
            "Rex",
            "Ric",
            "Richard",
            "Richie",
            "Rick",
            "Ricky",
            "Ridge",
            "RJ",
            "Robert",
            "Robin",
            "Roc",
            "Rocco",
            "Rocky",
            "Roger",
            "Rolf",
            "Roman",
            "Ross",
            "Roy",
            "Royce",
            "Russ",
            "Russel",
            "Ryan", 

// S Male names
            "Sam",
            "Samuel",
            "Saul",
            "Sean",
            "Seth",
            "Spike",
            "Scott",
            "Shane",
            "Shep",
            "Sidney",
            "Simon",
            "Slick",
            "Sly",
            "Sonny",
            "Spencer",
            "Stan",
            "Stanley",
            "Stephen",
            "Stavros",
            "Steve",
            "Steven",
            "Stuart",
            "Sven", 

// T Male names
            "Tad",
            "Taggert",
            "Tanner",
            "Taylor",
            "Ted",
            "Teddy",
            "Theo",
            "Thomas",
            "Thorne",
            "Tim",
            "Tom",
            "Tony",
            "Travis",
            "Trent",
            "Trevor",
            "Trey",
            "Tyrone", 

// V Male names
            "Vic",
            "Victor",
            "Vince",
            "Vincent", 

// W Male names
            "Wally",
            "Walt",
            "Walter",
            "Wayne",
            "Wendell",
            "Will",
            "William",
            "Willis",
            "Winston", 

// Y names
            "Yuri", 

// Z Male names
            "Zach",
            "Zachary",
            "Zack",
            "Zander",
            "Zane",
            "Zende"
        };

        #endregion

        #region Random Civlian
        // names of random characters in the game like civilians or witnesses etc hostages
        /// <summary>
        /// The npc names.
        /// </summary>
        public static string[] NPCNames =
        {
            "Allison",
            "Arthur",
            "Ana",
            "Alex",
            "Arlene",
            "Alberto",
            "Barry",
            "Bertha",
            "Bill",
            "Bonnie",
            "Bret",
            "Beryl",
            "Chantal",
            "Cristobal",
            "Claudette",
            "Charley",
            "Cindy",
            "Chris",
            "Dean",
            "Dolly",
            "Danny",
            "Danielle",
            "Dennis",
            "Debby",
            "Erin",
            "Edouard",
            "Erika",
            "Earl",
            "Emily",
            "Ernesto",
            "Felix",
            "Fay",
            "Fabian",
            "Frances",
            "Franklin",
            "Florence",
            "Gabielle",
            "Gustav",
            "Grace",
            "Gaston",
            "Gert",
            "Gordon",
            "Humberto",
            "Hanna",
            "Henri",
            "Hermine",
            "Harvey",
            "Helene",
            "Iris",
            "Isidore",
            "Isabel",
            "Ivan",
            "Irene",
            "Isaac",
            "Jerry",
            "Josephine",
            "Juan",
            "Jeanne",
            "Jose",
            "Joyce",
            "Karen",
            "Kyle",
            "Kate",
            "Karl",
            "Katrina",
            "Kirk",
            "Lorenzo",
            "Lili",
            "Larry",
            "Lisa",
            "Lee",
            "Leslie",
            "Michelle",
            "Marco",
            "Mindy",
            "Maria",
            "Michael",
            "Noel",
            "Nana",
            "Nicholas",
            "Nicole",
            "Nate",
            "Nadine",
            "Olga",
            "Omar",
            "Odette",
            "Otto",
            "Ophelia",
            "Oscar",
            "Pablo",
            "Paloma",
            "Peter",
            "Paula",
            "Philippe",
            "Patty",
            "Rebekah",
            "Rene",
            "Rose",
            "Richard",
            "Rita",
            "Rafael",
            "Sebastien",
            "Sally",
            "Sam",
            "Shary",
            "Stan",
            "Sandy",
            "Tanya",
            "Teddy",
            "Teresa",
            "Tomas",
            "Tammy",
            "Tony",
            "Van",
            "Vicky",
            "Victor",
            "Virginie",
            "Vince",
            "Valerie",
            "Wendy",
            "Wilfred",
            "Wanda",
            "Walter",
            "Wilma",
            "William",
            "Kumiko",
            "Aki",
            "Miharu",
            "Chiaki",
            "Michiyo",
            "Itoe",
            "Nanaho",
            "Reina",
            "Emi",
            "Yumi",
            "Ayumi",
            "Kaori",
            "Sayuri",
            "Rie",
            "Miyuki",
            "Hitomi",
            "Naoko",
            "Miwa",
            "Etsuko",
            "Akane",
            "Kazuko",
            "Miyako",
            "Youko",
            "Sachiko",
            "Mieko",
            "Toshie",
            "Junko"
        };
        #endregion

        /// <summary>
        /// The eye color.
        /// </summary>
        public enum EyeColor
        {
            /// <summary>
            /// The blue.
            /// </summary>
            Blue = 0,

            /// <summary>
            /// The brown.
            /// </summary>
            Brown = 1,

            /// <summary>
            /// The light brown.
            /// </summary>
            LightBrown = 2,

            /// <summary>
            /// The green.
            /// </summary>
            Green = 3,

            /// <summary>
            /// The hazel.
            /// </summary>
            Hazel = 4,

            /// <summary>
            /// The gray.
            /// </summary>
            Gray = 5,

            /// <summary>
            /// The amber.
            /// </summary>
            Amber = 6,

            /// <summary>
            /// The red.
            /// </summary>
            Red = 7,

            /// <summary>
            /// The violet.
            /// </summary>
            Violet = 8
        }

        /// <summary>
        /// The hair color.
        /// </summary>
        public enum HairColor
        {
            /// <summary>
            /// The black.
            /// </summary>
            Black = 0,

            /// <summary>
            /// The brown.
            /// </summary>
            Brown = 1,

            /// <summary>
            /// The blond.
            /// </summary>
            Blond = 2,

            /// <summary>
            /// The auburn.
            /// </summary>
            Auburn = 3,

            /// <summary>
            /// The chestnut.
            /// </summary>
            Chestnut = 4,

            /// <summary>
            /// The red.
            /// </summary>
            Red = 5,

            /// <summary>
            /// The gray.
            /// </summary>
            Gray = 6,

            /// <summary>
            /// The white.
            /// </summary>
            White = 7
        }

        /// <summary>
        /// The name bias.
        /// </summary>
        public enum nameBias
        {
            /// <summary>
            /// The north american.
            /// </summary>
            NorthAmerican,

            /// <summary>
            /// The souther american.
            /// </summary>
            SoutherAmerican,

            /// <summary>
            /// The european.
            /// </summary>
            European,

            /// <summary>
            /// The slavic.
            /// </summary>
            Slavic,

            /// <summary>
            /// The african.
            /// </summary>
            African,

            /// <summary>
            /// The asian.
            /// </summary>
            Asian, // change tzu etc

            /// <summary>
            /// The muslim.
            /// </summary>
            Muslim // mohammed etc
        }

        public enum ContactGender
        {
            male,
            female
        }


        public enum RemovalOptions
        {
            liquidate, //you kill them mission could go wrong
            resettle, // they resettle in your country takes longer and cost more but has no risks 
            protection, // offer to protect them in the host country, doesn't cost anything and good if you want to delay and use them for something else
            cutloose,
            turnover
        }
        //Envy is a reaction to lacking something. Jealousy is a reaction to the threat of losing something (usually someone)
        public enum ContactVice
        {

            sex,
            drugs,
            rocknroll,
            kink,
            food,
            gifts,
            pride,
            vanity,
            envy,
            jealousy,
            wrath,
            anger,
            sloth,
            greed,
            corupt

        }

        public enum ContactSkill
        {
            looselips, //can get someone to tell information
            partyanimal, //can get someone to tell information
            manipulator, //can get somone to do something a action
            statesmen, // can get a country population to support you
            shark, // can resist the charms of others
            honeypot, // can charm opposite sex much more then others ie if contact vice is sex then honeypot wins, 
            silentdeadly,// can kill and get away with it
            soldiersresolve, //former solider 
            businessmen, // best with business dealings
            sneaky, // fomer specil operations can do covert stuff
            killer,
            pusher,
            publicspeaker,
            dealmaker,
            puppetmaster,
            vixen, //female only
            nerdyAf,
            trusted

        }

        public enum ContactHealthStatus
        {
            InCombat,
            Healthly,
            Tired,
            Sick,
            CriticallySick,
            Wounded,
            CriticallyWounded,
            POW,
            KIA,
            MIA,
            Unknown
        }

        //TODO Write bios for these Statesment && diplomat
        /// <summary>
        ///   random,
        //diplomacy,
        //military,
        //intelligence,
        //economic,
        //research,
        //population
        /// </summary>
        public enum ContactType
        {
            #region Contact Group Type "diplomacy"
            [Description("Diplomat")]
            diplomat,
            [Description("Politician")]
            politicans,
            [Description("Policy Maker")]
            policymakers,
            [Description("Advisor")]
            advisor,
            [Description("Technocrat")]
            techncracts,
            [Description("Bureaucrat")]
            bureaucrat,
            [Description("Lawyer")]
            lawyer,
            [Description("Party Offical")]
            partyinsider,
            #endregion Contact Group Type "diplomacy" stop at 7
            #region Contact Group Type "military" start at 8
            [Description("Party Loyalist")]
            loyalist,
            [Description("Patriot")]
            patriot,
            [Description("Military Leader")]
            militaryleader,
            [Description("Solider")]
            solider,
            [Description("Officer")]
            officer,
            [Description("Special Forces")]
            commando,
            #endregion Contact Group Type "military" 18
            #region Rebel
            [Description("Rebel Leader")]
            rebelleader,
            [Description("Rebel Fighter")]
            rebelfighter,
            [Description("Terrorist Leader")]
            terroristleader,
            [Description("Terrorist Fighter")]
            terroristfighter,
            [Description("Enemy Combatant")]
            combatant,

            #endregion Rebel 18
            #region Contact Group Type "intelligence" 19
            [Description("Hacker")]
            hacker,
            [Description("Intel Analyst")]
            analsyt,
            [Description("Spy")]
            spy,
            [Description("Covert Agent")]
            agent007,
            [Description("Spy Master")]
            spymaster,
            #endregion Contact Group Type "intelligence" 22

            #region Contact Group Type "economic" 23
            [Description("Economist")]
            economist,
            [Description("CEO")]
            Ceo,
            [Description("Labor Leader")]
            LaborLeader,
            #endregion Contact Group Type "economic" 25

            #region Contact Group Type "research" 26

            [Description("Professor")]
            professor,
            [Description("Scientist")]
            scientist,
            [Description("Doctor")]
            doctors,
            [Description("Mathematician")]
            maths,
            #endregion Contact Group Type "research" 29

            #region Contact Group Type "population"
            [Description("Politician")]
            musicians,
            [Description("Politician")]
            celeberity,
            [Description("Law Enforcement")]
            lawenforcement,
            #endregion Contact Group Type "population" 32

            #region Contact Group Type "random"

            #endregion Contact Group Type "random"






        }


        /// <summary>
        /// The medical.
        /// </summary>
        public class Medical
        {

            public GeneProfile Profile { get; set; }

            /// <summary>
            /// Gets or sets the dob.
            /// </summary>
            public DateTime Dob { get; set; }

            /// <summary>
            /// Gets or sets the hair color.
            /// </summary>
            public HairColor HairColor { get; set; }

            /// <summary>
            /// Gets or sets the eye color.
            /// </summary>
            public EyeColor EyeColor { get; set; }

            // govern stamina
            /// <summary>
            /// Gets or sets the age.
            /// </summary>
            public string Age { get; set; }

            // used to calculate food requirements
            /// <summary>
            /// Gets or sets the height.
            /// </summary>
            public string Height { get; set; }

            /// <summary>
            /// Gets or sets the math height.
            /// </summary>
            public double MathHeight { get; set; }

            /// <summary>
            /// Gets or sets the weight.
            /// </summary>
            public string Weight { get; set; }

            /// <summary>
            /// Gets or sets the math weight.
            /// </summary>
            public double MathWeight { get; set; }

            /// <summary>
            /// Gets or sets the country of origin.
            /// </summary>
            public string CountryOfOrigin { get; set; }

            /// <summary>
            /// Gets or sets the service id number.
            /// </summary>
            public string ServiceIdNumber { get; set; }

            /// <summary>
            /// Gets or sets the joined.
            /// </summary>
            public int Joined { get; set; }
        }



        public enum Subregions
        {
            [Description("South America")]
            SouthAmerica,
            [Description("Eastern Asia")]
            EastAsia,
            [Description("Western Asia")]
            WesternAsia,
            [Description("Western Europe")]
            WesternEurope,
            [Description("Eastern Europe")]
            EasternEurope,
            [Description("Middle East")]
            MiddleEast,
            [Description("North America")]
            NorthAmerican,
            [Description("Africa")]
            Africa,
            [Description("Australia")]
            Australia,
        }


        public enum ContactGameGroup
        {
            random,
            diplomacy,
            military,
            intelligence,
            economic,
            research,
            population,
            rebel,
            terrorist
        }
        #endregion

        private static WMSK map = WMSK.instance;
        public T RandomEnumValue<T>(int RangeStart = 0, int RangeStop = 0)
        {
            var v = Enum.GetValues(typeof(T));
            UnityEngine.Random.seed = DateTime.Now.Millisecond;
            if (RangeStart == 0 && RangeStop == 0)
            {
                return (T)v.GetValue(UnityEngine.Random.Range(0, v.Length));
            }
            else
            {
                return (T)v.GetValue(UnityEngine.Random.Range(RangeStart, RangeStop));
            }
        }


        public List<Operator> GenerateSpecialOpsTeam(int SquadSize, List<KitType> TeamBaseConfig, string TeamCountryName, string TeamCountryRegion)
        {
            var localTeam = new List<Operator>();

            for (int f = 0; f < SquadSize; f++)
            {
                var squadName = string.Format("{0} {1} {2}-{3}", WesternSquads[UnityEngine.Random.Range(0, 22)], WesternSquads[UnityEngine.Random.Range(0, 22)],
          Helpers.NumberToText(UnityEngine.Random.Range(0, 9)), Helpers.NumberToText(UnityEngine.Random.Range(0, 9)));
                for (int i = 0; i < TeamBaseConfig.Count; i++)
                {
                    var op = new Operator();
                    Contact newOperative = GenerateContact(TeamCountryName, TeamCountryRegion, ContactGameGroup.military);
                    op.Teammate = newOperative;
                    op.Kit = GenerateKit(TeamBaseConfig[i]);
                    op.TeamSquadName = squadName;
                    op.Status = ContactHealthStatus.Healthly;
                    localTeam.Add(op);
                }
            }

            return localTeam;
        }
        public Contact GenerateTmpContact;


        public IEnumerator YieldUntilGenerateContact(CountryGovernment countryName, ContactGameGroup gameGroup)
        {
            this.GenerateTmpContact = null;
            GenerateTmpContact = GenerateContact(countryName.CountryOfGovernment.name, countryName.CountryOfGovernment.regionName, gameGroup);
            yield return new WaitForEndOfFrame();
        }

        public Contact GenerateContact(string countryName, string countryRegionName, ContactGameGroup gameGroup = ContactGameGroup.random)
        {
            var generatedContact = new Contact();
            var db = new CountryRelationsFactory();
            UnityEngine.Random.seed = DateTime.Now.Millisecond;
            var rnd = new UnityEngine.Random();
            var newRandomProfile = RandomGeneProfile(countryName);
            try
            {
                generatedContact.ContactName = GenerateARegionName(newRandomProfile.Sex, countryRegionName);
            }
            catch
            {
                generatedContact.ContactName = "Name Failed";
            }

            generatedContact.Family = GenerationFamily(newRandomProfile);
            generatedContact.IsCompromised = false;
            generatedContact.IsIntelTarget = false;


            var inGameMaxYearDOb = 2001;
            var inGameMinYearDOb = 1950;

            switch (gameGroup)
            {
                case ContactGameGroup.random:
                    inGameMinYearDOb = 1964;
                    break;
                case ContactGameGroup.diplomacy:
                    inGameMinYearDOb = 1950;
                    break;
                case ContactGameGroup.military:
                    inGameMinYearDOb = 1980;
                    break;
                case ContactGameGroup.intelligence:
                    inGameMinYearDOb = 1970;
                    break;
                case ContactGameGroup.economic:
                    inGameMinYearDOb = 1980;
                    break;
                case ContactGameGroup.research:
                    inGameMinYearDOb = 1980;
                    break;
                case ContactGameGroup.population:
                    inGameMinYearDOb = 1950;
                    break;
                case ContactGameGroup.rebel:
                    inGameMinYearDOb = 1990;
                    break;
                case ContactGameGroup.terrorist:
                    inGameMinYearDOb = 1990;
                    break;
                default:
                    break;
            }
            //TODO this needs to come the max time of the current game time ie 2016-25 years)

            var DoBDay = UnityEngine.Random.Range(1, 30);
            var DoBYear = UnityEngine.Random.Range(inGameMinYearDOb, inGameMaxYearDOb);
            generatedContact.Dob = new DateTime(DoBYear, newRandomProfile.BirthMonth, DoBDay);
            var age = DateTime.Now.Year - generatedContact.Dob.Year;
            // Go back to the year the person was born in case of a leap year
            if (generatedContact.Dob > DateTime.Now.AddYears(-age)) age--;
            generatedContact.Age = age;
            generatedContact.DobMonth = newRandomProfile.BirthMonth;
            generatedContact.DobYear = generatedContact.Dob.Year;
            generatedContact.CountryName = countryName;
            generatedContact.ContactSkill = RandomEnumValue<ContactSkill>();
            generatedContact.ContactVice = RandomEnumValue<ContactVice>();
            generatedContact.GeneProfile = newRandomProfile;
            generatedContact.NameRegion = countryRegionName;
            generatedContact.ContactNativeLangauge = db.LanguageFromCountry(countryName);
            switch (gameGroup)
            {
                case ContactGameGroup.diplomacy:
                    generatedContact.ContactType = RandomEnumValue<ContactType>((int)ContactType.diplomat, (int)ContactType.partyinsider);
                    break;
                case ContactGameGroup.military:
                    generatedContact.ContactType = RandomEnumValue<ContactType>((int)ContactType.patriot, (int)ContactType.commando);
                    break;
                case ContactGameGroup.intelligence:
                    generatedContact.ContactType = RandomEnumValue<ContactType>((int)ContactType.hacker, (int)ContactType.agent007);
                    break;
                case ContactGameGroup.economic:
                    generatedContact.ContactType = RandomEnumValue<ContactType>((int)ContactType.economist, (int)ContactType.LaborLeader);
                    break;
                case ContactGameGroup.research:
                    generatedContact.ContactType = RandomEnumValue<ContactType>((int)ContactType.professor, (int)ContactType.maths);
                    break;
                case ContactGameGroup.population:
                    generatedContact.ContactType = RandomEnumValue<ContactType>((int)ContactType.diplomat, (int)ContactType.partyinsider);
                    break;
                case ContactGameGroup.random:
                    generatedContact.ContactType = RandomEnumValue<ContactType>();
                    break;
            }


            return generatedContact;
        }

        public static string pickRandomFromRegionNameList(string CountryRegion, ContactGender genderLookup)
        {
            var rnd = new UnityEngine.Random();
            var regionNameList = RegionFirstNames().Where(e => e.Item1 == CountryRegion && e.Item3 == genderLookup).Select(e => e.Item2.ToString()).ToArray();
            var regionLastNameList = RegionLastNames().Where(e => e.Item1 == CountryRegion && e.Item3 == genderLookup).Select(e => e.Item2.ToString()).ToArray();
            int regionRandomIndex = UnityEngine.Random.Range(0, regionNameList.Count());
            string randomRegionFirstName = regionNameList[regionRandomIndex];
            regionRandomIndex = UnityEngine.Random.Range(0, regionLastNameList.Count());
            string randomRegionLastName = regionLastNameList[regionRandomIndex];
            return randomRegionFirstName + " " + randomRegionLastName;
        }

        public List<CultureInfo> CountryName()
        {

            return CultureInfo.GetCultures(CultureTypes.NeutralCultures).ToList();
        }

        public static string GenerateARegionName(ContactGender MF, string Region)
        {

            return pickRandomFromRegionNameList(Region, MF);
        }

        public static List<Tuple<string, string, ContactGender>> RegionFirstNames()
        {
            var rnd = new System.Random();
            var internalRegionFirst = new List<Tuple<string, string, ContactGender>>
            {
                new Tuple<string, string, ContactGender>("North America", MFname[rnd.Next(MFname.Length)], ContactGender.male),
                new Tuple<string, string, ContactGender>("North America", FFname[rnd.Next(FFname.Length)], ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Santiago", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Sebastián", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Matías", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Mateo", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Nicolás", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Alejandro", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Diego", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Samuel", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Benjamín", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Daniel", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Joaquín", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Lucas", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Emmanuel", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Emiliano", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Andrés", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Juan Pablo", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Agustín", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Maximiliano", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Miguel", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Rodrigo", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Leonardo", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Felipe", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Rafael", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Vicente", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Ángel", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Lorenzo", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Jesús", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Juan", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Fernando", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Sofia", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Isabella", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Camila", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Luciana", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Samantha", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Catalina", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Julieta", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Antonella", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Natalia", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Guadalupe", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Andrea", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Bianca", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Gabriela", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Alejandra", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Elena", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Florencia", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "María", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Bianca", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Olivia", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Alessandra", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Magdalena", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Manuela", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Isabel", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Romina", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Daniela", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Victoria", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Florencia", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Josefina", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Zubayr", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Zakwan", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Zafar", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Youssef", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Yazeed", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Walid", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Tamir", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Talal", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Salamah", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Sahir", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Salah", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Rushdi", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Rihab", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Ramzi", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Qusay", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Qamar", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Qadir", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Omar", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Namir", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Muhammad", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Ibrahim", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Hayyan", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Malik", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Kaseem", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Madani", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Kadeen", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Jameel", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Jamal", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Jabir", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Ishaq", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Isma'il", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Imad", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Idris", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Abdul", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Amin", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Amir", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Asad", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Bahir", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Barakah", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Bashir", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Fahad", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Fareeq", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Ghassan", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Hassan", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Sadia", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Safia", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Selma", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Shakala", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Yesenia", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Yasmin", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Yemena", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Zafirah", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Zaidee", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Zafina", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Lilah", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Mahira", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Manar", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Massarra", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Mouna", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Nada", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Nadeah", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Naja", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Nisa", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Qawiya", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Akeylah", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Alima", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Andala", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Bassma", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Fatima", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Ghazala", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Kalifa", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Alexei", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Anatoly", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Andrei", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Anton", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Arkady", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Artyom", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Boris", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Vadim", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Viktor", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Vladimir", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Vladislav", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Grigory", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Dmitry", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Yegor", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Zakhar", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Ivan", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Igor", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Ilia", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Leonid", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Lev", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Maxim", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Mikhail", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Nikolay", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Pavel", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Oleg", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Sergei", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Yakov", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Yury", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Yaroslav", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Stanislav", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Spartak", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Anastasiya", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Anastasiya", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Anna", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Antonina", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Vladlena", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Valentina", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Veronika", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Diana", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Ekaterina", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Zhanna", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Zoya", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Irina", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Izabella", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Iskra", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Klementina", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Kristina", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Larisa", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Lidiya", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Malvina", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Natalya", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Nika", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Oksana", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Olesya", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Regina", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Svetlana", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Tatyana", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Florentina", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Bai", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Bai", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Bo", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Changpu", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Chao", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Chen", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Cheung", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Chung", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Dai", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Dingxiang", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Dong", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Fang", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Feng", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Fuhua", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Gang", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Gen", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Guang", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Hai", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Heng", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Ho", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Jian", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Jianjun", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Jin", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Keung", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Li", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Liang", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Qiang", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Peng", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Qingshan", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Renshu", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Shen", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Shanyuan", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Shoushan", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Wang", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Tung", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Wei", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Wuzhou", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Xiaobo", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Xin", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Xue", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Zian", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Yaozu", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Zhen", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Biyu", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Chenguang", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Chunhua", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Dandan", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Dongmei", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Fang", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Fenfang", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Huan", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Huifen", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Jia", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Kwong", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Jinghua", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Lan", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Lin", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Linqin", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Biyu", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Meifen", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Mei", ContactGender.female)
            };

            return internalRegionFirst;
        }

        public static List<Tuple<string, string, ContactGender>> RegionLastNames()
        {
            var rnd = new System.Random();

            var internalRegionLastName = new List<Tuple<string, string, ContactGender>>
            {
                new Tuple<string, string, ContactGender>("North America", LName[rnd.Next(LName.Length)], ContactGender.male),
                new Tuple<string, string, ContactGender>("North America", LName[rnd.Next(LName.Length)], ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Santiago", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Sebastián", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Matías", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Mateo", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Nicolás", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Alejandro", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Diego", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Samuel", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Benjamín", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Daniel", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Joaquín", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Lucas", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Emmanuel", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Emiliano", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Andrés", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Juan Pablo", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Agustín", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Maximiliano", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Miguel", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Rodrigo", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Leonardo", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Felipe", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Rafael", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Vicente", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Ángel", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Lorenzo", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Jesús", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Juan", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Fernando", ContactGender.male),
                new Tuple<string, string, ContactGender>("South America", "Sofia", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Isabella", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Camila", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Luciana", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Samantha", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Catalina", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Julieta", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Antonella", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Natalia", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Guadalupe", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Andrea", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Bianca", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Gabriela", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Alejandra", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Elena", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Florencia", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "María", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Bianca", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Olivia", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Alessandra", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Magdalena", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Manuela", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Isabel", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Romina", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Daniela", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Victoria", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Florencia", ContactGender.female),
                new Tuple<string, string, ContactGender>("South America", "Josefina", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Zubayr", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Zakwan", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Zafar", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Youssef", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Yazeed", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Walid", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Tamir", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Talal", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Salamah", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Sahir", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Salah", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Rushdi", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Rihab", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Ramzi", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Qusay", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Qamar", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Qadir", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Omar", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Namir", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Muhammad", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Ibrahim", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Hayyan", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Malik", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Kaseem", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Madani", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Kadeen", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Jameel", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Jamal", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Jabir", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Ishaq", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Isma'il", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Imad", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Idris", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Abdul", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Amin", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Amir", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Asad", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Bahir", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Barakah", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Bashir", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Fahad", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Fareeq", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Ghassan", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Hassan", ContactGender.male),
                new Tuple<string, string, ContactGender>("Western Asia", "Sadia", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Safia", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Selma", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Shakala", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Yesenia", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Yasmin", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Yemena", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Zafirah", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Zaidee", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Zafina", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Lilah", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Mahira", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Manar", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Massarra", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Mouna", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Nada", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Nadeah", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Naja", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Nisa", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Qawiya", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Akeylah", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Alima", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Andala", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Bassma", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Fatima", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Ghazala", ContactGender.female),
                new Tuple<string, string, ContactGender>("Western Asia", "Kalifa", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Alexei", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Anatoly", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Andrei", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Anton", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Arkady", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Artyom", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Boris", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Vadim", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Viktor", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Vladimir", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Vladislav", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Grigory", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Dmitry", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Yegor", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Zakhar", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Ivan", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Igor", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Ilia", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Leonid", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Lev", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Maxim", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Mikhail", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Nikolay", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Pavel", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Oleg", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Sergei", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Yakov", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Yury", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Yaroslav", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Stanislav", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Spartak", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Anastasiya", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Anastasiya", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Anna", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Antonina", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Vladlena", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Valentina", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Veronika", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Diana", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Ekaterina", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Zhanna", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Zoya", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Irina", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Izabella", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Iskra", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Klementina", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Kristina", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Larisa", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Lidiya", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Malvina", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Natalya", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Nika", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Oksana", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Olesya", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Regina", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Svetlana", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Tatyana", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Europe", "Florentina", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Bai", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Bai", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Bo", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Changpu", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Chao", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Chen", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Cheung", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Chung", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Dai", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Dingxiang", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Dong", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Fang", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Feng", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Fuhua", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Gang", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Gen", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Guang", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Hai", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Heng", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Ho", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Jian", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Jianjun", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Jin", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Keung", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Li", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Liang", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Qiang", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Peng", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Qingshan", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Renshu", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Shen", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Shanyuan", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Shoushan", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Wang", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Tung", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Wei", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Wuzhou", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Xiaobo", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Xin", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Xue", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Zian", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Yaozu", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Zhen", ContactGender.male),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Biyu", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Chenguang", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Chunhua", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Dandan", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Dongmei", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Fang", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Fenfang", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Huan", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Huifen", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Jia", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Kwong", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Jinghua", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Lan", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Lin", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Linqin", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Biyu", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Meifen", ContactGender.female),
                new Tuple<string, string, ContactGender>("Eastern Asia", "Mei", ContactGender.female)
            };

            return internalRegionLastName;
        }

        public static Family GenerationFamily(GeneProfile soldier)
        {
            var newFamily = new Family();
            UnityEngine.Random.seed += 5;
            var iDc = UnityEngine.Random.Range(1, 4);
            newFamily.IsFatherDeceased = iDc >= 4;
            var iDm = UnityEngine.Random.Range(1, 4);
            newFamily.IsMotherDeceased = iDm >= 2;
            newFamily.IsMarried = iDm >= 2;
            UnityEngine.Random.seed += 5;
            newFamily.IsOnlyChild = UnityEngine.Random.value >= 0.5;
            if (!newFamily.IsOnlyChild)
            {
                newFamily.BrotherCount = UnityEngine.Random.Range(1, 3);
                newFamily.SisterCount = UnityEngine.Random.Range(1, 3);
            }
            else
            {
                newFamily.BrotherCount = newFamily.SisterCount = 0;
            }

            return newFamily;
        }



        public static string WPMGetRandomHomeTown(string countryName)
        {
            var country = map.GetCountry(map.GetCountryIndex(countryName));
            if (country.provinces != null)
            {
                var randomRegion = country.provinces[UnityEngine.Random.Range(0, country.regions.Count)]; //get random hometown region
                return randomRegion.name;
            }
            else
            {
                return country.name;
            }
        }

        public string GetRandomHomeTown(Country country)
        {

            if (country.provinces != null)
            {
                var randomRegion = country.provinces[UnityEngine.Random.Range(0, country.regions.Count)]; //get random hometown region
                return randomRegion.name;
            }
            else
            {
                return country.name;
            }
        }

        public static GeneProfile RandomGeneProfile(string profileCountryName)
        {

            UnityEngine.Random.seed = System.DateTime.Now.Millisecond;
            var hometown = WPMGetRandomHomeTown(profileCountryName);
            UnityEngine.Random.seed += 5;
            //LocalServicesManager.CountryData.GetRandomCountryName(null, out hometown);
            var g = UnityEngine.Random.Range(0, 3); // 75% produce males
            UnityEngine.Random.seed += 5;
            var sex = UnityEngine.Random.Range(0, 9); // 1 in 9 % produce gay
            var s = (sex != 0) ? true : false;
            var newGeneProfile = new GeneProfile
            {
                BirthMonth = UnityEngine.Random.Range(0, 12),
                CountryOfOrigin = profileCountryName,
                HomeTown = hometown,
                Sex = (g != 0) ? ContactGender.male : ContactGender.female,
                IsStraight = s
            };

            // need to inbreed traits here like leadership or agressiveness etc

            return newGeneProfile;
        }
        /// <summary>
        /// The get last name list.
        /// </summary>
        /// <param name="nameList">
        /// The name List.
        /// </param>
        /// <returns>
        /// The <see cref="string[]"/>.
        /// </returns>
        public string GetRandomNameFromList(int gender, GeneProfile profile, bool lname, bool randomName = false)
        {
            var nameList = MFname;
            var r = new System.Random();
            // 
            try
            {
                var genderLoopUp = ContactGender.male;


                if (gender == 0)
                {
                    genderLoopUp = ContactGender.female;
                    nameList = FFname;
                }

                if (lname)
                {
                    return LName[r.Next(LName.Count())];
                }

                if (randomName)
                {
                    return nameList[r.Next(nameList.Length)];
                }

                var countryMap =
                    map.GetCountry(profile.CountryOfOrigin);
                var regionname = countryMap.regions.FirstOrDefault().entity.name;

                if (profile.CountryOfOrigin.Length > 0)
                {
                    var listOfGenderNames =
                        RegionFirstNames()
                            .Where(e => e.Item1 == regionname && e.Item3 == genderLoopUp)
                            .Select(e => e.Item2);

                    return listOfGenderNames.ElementAt(r.Next(listOfGenderNames.Count()));
                }
            }
            catch (Exception)
            {
                return MFname[r.Next(MFname.Length)];
            }

            return MFname[r.Next(MFname.Length)];
        }

        /// <summary>
        /// The get combinations.
        /// </summary>
        /// <param name="num">
        /// The num.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<IEnumerable<int>> GetCombinations(int num)
        {
            var combinationsList = GetCombinationTrees(num, num);

            return BuildCombinations(combinationsList);
        }

        /// <summary>
        /// The get combination trees.
        /// </summary>
        /// <param name="num">
        /// The num.
        /// </param>
        /// <param name="max">
        /// The max.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<Combination> GetCombinationTrees(int num, int max)
        {
            return Enumerable.Range(1, num)
                .Where(n => n <= max)
                .Select(n =>
                    new Combination
                    {
                        Num = n,
                        Combinations = GetCombinationTrees(num - n, n)
                    });
        }

        /// <summary>
        /// The build combinations.
        /// </summary>
        /// <param name="combinations">
        /// The combinations.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<IEnumerable<int>> BuildCombinations(
            IEnumerable<Combination> combinations)
        {
            if (!combinations.Any())
            {
                return new[] { new int[0] };
            }

            return combinations.SelectMany(c =>
                BuildCombinations(c.Combinations)
                    .Select(l => new[] { c.Num }.Concat(l))
                );
        }

        /// <summary>
        /// The combination.
        /// </summary>
        public class Combination
        {
            /// <summary>
            /// The combinations.
            /// </summary>
            internal IEnumerable<Combination> Combinations;

            /// <summary>
            /// The num.
            /// </summary>
            internal int Num;
        }
    }
}
