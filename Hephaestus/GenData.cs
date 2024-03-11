using Mutagen.Bethesda.FormKeys.SkyrimSE;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;

namespace Hephaestus
{
    // A class to store generated data
    public class GenData
    {
        //Declare base vars and dictionaries
        public static char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        public static List<string> BlacksmithNPCNames =
            new()
            {
                // Vanilla NPCs
                "Adrianne Avenicci",
                "Alvor",
                "Arnskar Ember-Master",
                "Asbjorn Fire-Tamer",
                "Balimund",
                "Baldor Iron-Shaper",
                "Beirand",
                "Dushnamub",
                "Elrindir",
                "Eorlund Gray-Mane",
                "Filnjar",
                "Fihada",
                "Gharol",
                "Ghorza gra-Bagol",
                "Glover Mallory",
                "Gunmar",
                "Hestla",
                "Lod",
                "Moth gro-Bagol",
                "Oengul War-Anvil",
                "Rustleif",
                "Shuftharz",
                "Syndus",
                "Ulfberth War-Bear",
                "Vanryth Gatharian",
                "Garakh",
            };

        public static List<string> NordNPCNames =
            new()
            {
                // Nord
                "Bjorn",
                "Freya",
                "Leif",
                "Sigrid",
                "Erik",
                "Astrid",
                "Magnus",
                "Ingrid",
                "Gunnar",
                "Elsa",
                "Ragnar",
                "Kara",
                "Hakon",
                "Frida",
                "Sven",
                "Lena",
                "Jarl",
                "Helga",
                "Torvald",
                "Rosa",
                "Olaf",
                "Ida",
                "Ulfrik",
                "Solveig",
                "Harald",
                "Kirsten",
                "Yngvar",
                "Elin",
                "Sten",
                "Marta",
            };

        public static List<string> HumanNPCNames =
            new()
            {
                // Breton
                "Alain",
                "Eloise",
                "Gilbert",
                "Melisande",
                "Bertrand",
                "Cecile",
                "Henri",
                "Rosalie",
                "Damien",
                "Fleur",
                "Jules",
                "Sylvie",
                "Etienne",
                "Isabelle",
                "Laurent",
                "Viviane",
                "Gaston",
                "Juliette",
                "Marc",
                "Yvette",
                "Hugo",
                "Lucie",
                "Olivier",
                "Zoe",
                "Leon",
                "Margot",
                "Pierre",
                "Adele",
                "Remy",
                "Camille",
                // Imperial
                "Antonius",
                "Claudia",
                "Lucius",
                "Valeria",
                "Brutus",
                "Diana",
                "Marcus",
                "Aurelia",
                "Cassius",
                "Flavia",
                "Octavius",
                "Cornelia",
                "Decimus",
                "Julia",
                "Quintus",
                "Livia",
                "Felix",
                "Larissa",
                "Sergius",
                "Sabina",
                "Gaius",
                "Nerissa",
                "Titus",
                "Veronica",
                "Horatius",
                "Prisca",
                "Vitus",
                "Cynthia",
                "Lucianus",
                "Fabia",
                // Redguard
                "Cyrus",
                "Farah",
                "Malik",
                "Zara",
                "Alik",
                "Hana",
                "Rihad",
                "Laila",
                "Basim",
                "Jamila",
                "Sahan",
                "Nura",
                "Darius",
                "Nadia",
                "Tahir",
                "Rana",
                "Fares",
                "Samira",
                "Yasir",
                "Amira",
                "Hakim",
                "Leila",
                "Zayn",
                "Aisha",
                "Karim",
                "Nadya",
                "Jabari",
                "Zahra",
                "Omar",
                "Salma",
            };

        public static List<string> ElfNPCNames =
            new()
            {
                // Altmer
                "Calion",
                "Elenwen",
                "Farenir",
                "Tandilwe",
                "Andilir",
                "Galerion",
                "Ilenir",
                "Nalirelwe",
                "Carandil",
                "Heculoa",
                "Larethor",
                "Ondolemar",
                "Elandora",
                "Imedril",
                "Nalanya",
                "Rinyde",
                "Fasendil",
                "Lathenil",
                "Ohtesse",
                "Taranis",
                // Bosmer
                "Camoran",
                "Elara",
                "Fargoth",
                "Nara",
                "Anoriath",
                "Elsweyr",
                "Finoriell",
                "Niruin",
                "Aranias",
                "Eranas",
                "Gaenor",
                "Ondrevel",
                "Arthcamu",
                "Erthor",
                "Gilraen",
                "Sinderion",
                "Barenziah",
                "Faendal",
                "Glarthir",
                "Tharayya",
                // Dunmer
                "Adryn",
                "Dratha",
                "Neloth",
                "Voryn",
                "Almalexia",
                "Drelasa",
                "Nerevar",
                "Vivec",
                "Aryon",
                "Dren",
                "Nibani",
                "Zainab",
                "Baladas",
                "Drilu",
                "Nix-Hound",
                "Zanummu",
                "Barenziah",
                "Drinar",
                "Orvas",
                "Zekiel",
                "Brara",
                "Drovas",
                "Ralen",
                "Zula"
            };

        public static List<string> OrcNPCNames =
            new()
            {
                // Orc
                "Balagog",
                "Ghorza",
                "Kharag",
                "Shuftharz",
                "Bazrag",
                "Gortwog",
                "Kurog",
                "Urag",
                "Bolar",
                "Graufang",
                "Lazgara",
                "Urok",
                "Borgakh",
                "Gularzob",
                "Lob",
                "Ushug",
                "Bugak Gro-Dhalug",
                "Mauhulakh",
                "Yamarz",
                "Burguk Gro-Nagorm",
                "Mazoga",
                "Yashnag"
            };

        public static List<string> BeastNPCNames =
            new()
            {
                // Argonian
                "Deel-Jeen",
                "Jaree-Ra",
                "Scales-Like-Silver",
                "Veezara",
                "Derkeethus",
                "Jee-Lar",
                "Sees-All-Colors",
                "Vistha-Kai",
                "Eyes-of-Steel",
                "Jorunn",
                "Skald-King",
                "Shahvee",
                "Wamasu",
                "From-Deepest-Fathoms",
                "Keerava",
                "Shellback",
                "Xukas",
                "Geel-Lah",
                "Keshu",
                "Black-Fin",
                "Sings-With-Reed",
                "Zhasim",
                // Khajiit
                "Dar'jargo",
                "Ra'jirra",
                "S'rendarr",
                "Dar'Ma",
                "Jo'Ren-Dar",
                "Rajhin",
                "S'rashi",
                "Daro'Raaji",
                "Kharjo",
                "Rasha",
                "S'rathra",
                "Dro'Zira",
                "Khayla",
                "Razum-dar",
                "Shazah",
                "Dro'Zirr",
                "Khunzar-ri",
                "Ri'saad",
                "Shazgob",
                "Elsweyr",
                "Kiergo",
                "Ri'Zakar"
            };

        public static List<string> DwemerNPCNames =
            new()
            {
                "Bthuand",
                "Dhark",
                "Dumac",
                "Gharen",
                "Kagrenac",
                "Mzunchend",
                "Nchunak",
                "Rkungthunch",
                "Sthovin",
                "Yagrum",
                "Barenziah",
                "Dratha",
                "Lannessa",
                "Neransi",
                "Zula"
            };

        // Formatting book contents
        public static List<string> flavourText =
            new()
            {
                "This schematicTypeLower looks like the notes of a madman, though I can somewhat decypher it. It seems to detail the process of processNameCont aAnobjName at a objBench.",
                "This schematicTypeLower seems to have been teared off from someone's journal. It seems to explain the process of processNameCont aAnobjName at a objBench.",
                "This schematicTypeLower goes into great detail on the steps of processNameCont aAnobjName at a objBench.",
                "This schematicTypeLower contains the secrets to processNameCont aAnobjName at a objBench.",
                "This schematicTypeLower is filled with scribbles and notes on the steps of processNameCont aAnobjName at a objBench.",
                "This schematicTypeLower still has some stains of blood on it, it describes the process of processNameCont aAnobjName at a objBench."
            };

        // Formatting book contents
        public static List<string> ArmorflavourText =
            new()
            {
                "This schematicTypeLower seems to have been written by a smith apprentice, from the looks of it it describes how to processName aAnobjName at a objBench.",
                "This schematicTypeLower seems to have been drawn by a designer. It shows the steps of processNameCont aAnobjName at a objBench. I can see the style and the flair of this piece of armor, I wonder how it looks.",
                "This schematicTypeLower seems to have been written by a traveler. It narrates the steps of processNameCont aAnobjName at a objBench. I can see the experience and the wisdom of this piece of armor, I wonder what it has seen.",
                "This schematicTypeLower seems to have been uttered by a priest. It blesses the steps of processNameCont aAnobjName at a objBench. I can see the faith and the grace of this piece of armor, I wonder what it protects.",
                "This schematicTypeLower seems to have been drawn by a designer. It shows the steps of processNameCont aAnobjName at a objBench. I can see the style and the flair of this piece of armor, I wonder how it looks.",
                "To create aAnobjName, I will need this schematicTypeLower and access to a objBench. The objName is a rare piece of armor that can be found only in certain places. The processNameCont method involves using special skills and tools to create a complex and unique design.",
                "This schematicTypeLower seems to have been written by a master. It instructs the steps of processNameCont aAnobjName at a objBench. I can see the skill and the expertise of this piece of armor, I wonder how it performs.",
                "This schematicTypeLower is written as a riddle. It puzzles the steps of processNameCont aAnobjName at a objBench. I can see the mystery and the enigma of this piece of armor, I wonder what it hides.",
                "This schematicTypeLower seems to have been created by an artist. It depicts the steps of processNameCont aAnobjName at a objBench. I can see the color and the expression of this piece of armor, I wonder how it inspires.",
            };

        // Formatting book contents
        public static List<string> WeaponflavourText =
            new()
            {
                "This schematicTypeLower seems to belong to a famous craftsman. It reveals the secrets of processNameCont aAnobjName at a objBench. I can see the intricate details and the careful instructions that go into making such a masterpiece.",
                "This schematicTypeLower looks like it was written in a hurry. It shows the basics of processNameCont aAnobjName at a objBench. I can tell that the writer was not very experienced or skilled, but they managed to create something useful.",
                "This schematicTypeLower seems to have some strange symbols and diagrams on it. It describes the process of processNameCont aAnobjName at a objBench. I can sense some magic and mystery behind this weapon, I wonder what it can do.",
                "This schematicTypeLower seems to have been stolen from a royal vault. It explains the steps of processNameCont aAnobjName at a objBench. I can see the quality and the elegance of this weapon, I bet it belongs to someone important.",
                "This schematicTypeLower seems to have been passed down for generations. It tells the story of processNameCont aAnobjName at a objBench. I can feel the history and the legacy of this weapon, I wonder who wielded it before me.",
                "This schematicTypeLower seems to have been written by someone who just learned the craft. It outlines the steps of processNameCont aAnobjName at a objBench. I can see the enthusiasm and the creativity of this weapon, I hope it works as intended.",
                "This schematicTypeLower seems to have been made by a child. It illustrates the process of processNameCont aAnobjName at a objBench. I can see the imagination and the fun of this weapon, I wonder what inspired it.",
                "This schematicTypeLower seems to have been used as a weapon itself. It depicts the steps of processNameCont aAnobjName at a objBench. I can see the violence and the madness of this weapon, I hope it was worth it.",
                "This schematicTypeLower seems to have been hidden for a long time. It reveals the secrets of processNameCont aAnobjName at a objBench. I can see the wisdom and the knowledge of this weapon, I wonder what secrets it holds.",
                "This schematicTypeLower seems to have been made by a professional. It shows the steps of processNameCont aAnobjName at a objBench. I can see the precision and the efficiency of this weapon, I admire the skill behind it.",
                "This schematicTypeLower seems to have been ripped from a book. It explains the steps of processNameCont aAnobjName at a objBench. I can see the complexity and the diversity of this weapon, I wonder how it works.",
                "This schematicTypeLower seems to have been written by a rogue. It conceals the steps of processNameCont aAnobjName at a objBench. I can see the stealth and the cunning of this weapon, I wonder who it was written for.",
                "This schematicTypeLower seems to have been salvaged from a fire. It preserves the steps of processNameCont aAnobjName at a objBench. I can see the damage and the danger of this weapon, I hope it is not too late.",
                "This schematicTypeLower seems to have been used as a wipe. It stains the steps of processNameCont aAnobjName at a objBench. I can see the dirt and the grime of this weapon, I hope it is still usable.",
                "This schematicTypeLower seems to have been thrown away. It discards the steps of processNameCont aAnobjName at a objBench. I can see the failure and the frustration of this weapon, I wonder what went wrong.",
                "This schematicTypeLower is a musical sheet, it seems to have been composed by a bard. It sings the steps of processNameCont aAnobjName at a objBench. I can hear the melody and the rhythm of this weapon, I wonder how it sounds.",
                "This schematicTypeLower is a map, it seems to have been drawn by an explorer. It marks the steps of processNameCont aAnobjName at a objBench. I can see the adventure and the discovery of this weapon, I wonder where it leads.",
                "This schematicTypeLower is a poem, it seems to have been written by a lover. It praises the steps of processNameCont aAnobjName at a objBench. I can feel the emotion and the beauty of this weapon, I wonder who it is for.",
                "This schematicTypeLower is a joke, it seems to have been told by a jester. It mocks the steps of processNameCont aAnobjName at a objBench. I can see the humor and the irony of this weapon, I wonder if it is funny."
            };

        // Formatting book contents
        public static List<string> ShieldflavourText =
            new()
            {
                "This schematicTypeLower reveals the secrets and arts of the craft, explaining the advanced steps to craft aAnobjName using a objBench. This shield is a legendary item, only the worthy can obtain it. It requires mastering the processNameCont technique to create an extraordinary and powerful design.",
                "A soldier must have written this schematicTypeLower, it states the steps of processNameCont aAnobjName at a objBench with duty and loyalty. I wonder who this shield serves, it must be very reliable.",
                "I will need this schematicTypeLower and access to a objBench to make aAnobjName. This shield is a common item, it can be used for various purposes. I will need to work with the available materials to create a simple and functional design, following the processNameCont technique.",
                "A traveler must have written this schematicTypeLower, it narrates the steps of processNameCont aAnobjName at a objBench with experience and wisdom. I wonder what this shield has seen, it must have been through many adventures.",
                "A priest must have uttered this schematicTypeLower, it blesses the steps of processNameCont aAnobjName at a objBench with faith and grace. I wonder what this shield protects, it must be very sacred.",
                "A Companion must have made this schematicTypeLower, it urges the steps of processNameCont aAnobjName at a objBench with courage. I wonder how this shield fights, it must be very brave.",
                "A artist must have created this schematicTypeLower, it depicts the steps of processNameCont aAnobjName at a objBench with color and expression. I wonder how this shield inspires, it must be very beautiful.",
                "A collector must have made this schematicTypeLower, it records the steps of processNameCont aAnobjName at a objBench with rarity and value. I wonder how this shield shines, it must be very precious.",
                "A witch must have written this schematicTypeLower, it twists the steps of processNameCont aAnobjName at a objBench with evil and malice. I wonder how this shield hurts, it must be very dangerous."
            };

        // Formatting book contents
        public static List<string> CookingflavourText =
            new()
            {
                "This schematicTypeLower must've been taken out of a cookbook, it lists the steps of processNameCont aAnobjName at a objBench. This objName looks delicious, it must be very tasty. I can smell the aroma and the flavor of this dish, I can't wait to try it.",
                "To prepare aAnobjName, I will need this schematicTypeLower and access to a objBench. This objName is a traditional dish, it has been passed down for generations. I will need to use fresh ingredients and follow the processNameCont method to make it. I can feel the warmth and the comfort of this dish, it reminds me of home.",
                "This schematicTypeLower reveals the secrets of processNameCont aAnobjName using a objBench. This objName is a exotic dish, it comes from a faraway land. I will need to master the skills and the tools to make it. I can see the spice and the zest of this dish, it makes me curious.",
                "Someone must have left this schematicTypeLower on a table for a long time, it's quite stained. It outlines the steps of processNameCont aAnobjName at a objBench. This objName looks simple, but it has a hidden twist. I can taste the sweetness and the sourness of this dish, it surprises me.",
                "I will need this schematicTypeLower and access to a objBench to cook aAnobjName. This objName is a healthy dish, it is good for Ir body and mind. I will need to use organic ingredients and follow the processNameCont technique to make it. I can feel the energy and the vitality of this dish, it makes me happy.",
                "This schematicTypeLower teaches I how to processName aAnobjName using a objBench. This objName is a festive dish, it is perfect for celebrations and parties. I will need to use rich ingredients and follow the processNameCont method to make it. I can hear the laughter and the joy of this dish, it makes me festive.",
                "To processNameCont aAnobjName, I will need this schematicTypeLower and access to a objBench. This objName is a special dish, it is made with love and care. I will need to use quality ingredients and follow the processNameCont technique to make it. I can feel the friendship and the generosity of this dish, it makes me grateful.",
                "This schematicTypeLower reveals the steps of processNameCont aAnobjName at a objBench. This objName is a ancient dish, it has a long history and tradition. I will need to use rare ingredients and master the processNameCont technique to make it. I can see the wisdom and the knowledge of this dish, it makes me curious.",
                "To processNameCont aAnobjName, I will need this schematicTypeLower and access to a objBench. This objName is a mysterious dish, it has a secret ingredient and a hidden effect. I will need to use unknown ingredients and follow the processNameCont method to make it. I can taste the mystery and the magic of this dish, it makes me adventurous.",
                "This schematicTypeLower tells I how to processName aAnobjName at a objBench. This objName is a personal dish, it is Ir own creation and invention. I will need to use Ir favorite ingredients and follow Ir own processNameCont technique to make it. I can see the creativity and the expression of this dish, it makes me proud.",
                "This schematicTypeLower shows me how to processName aAnobjName using a objBench. This objName is a delicious dish, it is good for any occasion. I will need to use fresh ingredients and follow the processNameCont method to make it. I can smell the aroma and the flavor of this dish, it makes me hungry.",
                "I will need this schematicTypeLower and access to a objBench to processNameCont aAnobjName. This objName is a traditional dish, it has been passed down for generations. I will need to use authentic ingredients and follow the processNameCont technique to make it. I can feel the warmth and the comfort of this dish, it reminds me of home.",
                "This schematicTypeLower explains the steps of processNameCont aAnobjName at a objBench. This objName is a exotic dish, it comes from a faraway land. I will need to master the skills and the tools to make it. I can see the spice and the zest of this dish, it makes me curious.",
                "I will need this schematicTypeLower and access to a objBench to cook aAnobjName. This objName is a healthy dish, it is good for your body and mind. I will need to use organic ingredients and follow the processNameCont technique to make it. I can feel the energy and the vitality of this dish, it makes me happy.",
                "This schematicTypeLower instructs me how to processName aAnobjName at a objBench. This objName is a festive dish, it is perfect for celebrations and parties. I will need to use rich ingredients and follow the processNameCont method to make it. I can hear the laughter and the joy of this dish, it makes me festive.",
            };

        // Formatting book contents
        public static List<string> JewelryflavourText =
            new()
            {
                "This schematicTypeLower shows me how to get started on processNameCont aAnobjName using a objBench. This objName is a beautiful piece of jewelry, it is good for any occasion. I will need to use shiny materials and follow the processNameCont method to make it. I can see the sparkle and the elegance of this piece, it makes me dazzled.",
                "I will need this schematicTypeLower and access to a objBench to get started on processNameCont aAnobjName. This objName is a rare piece of jewelry, it can only be found in certain places. I will need to use precious materials and follow the processNameCont technique to make it. I can feel the value and the luxury of this piece, it makes me rich.",
                "This schematicTypeLower explains the steps of processNameCont aAnobjName at a objBench. This objName is a magical piece of jewelry, it has a special power and effect. I will need to master the skills and the tools to make it. I can see the magic and the mystery of this piece, it makes me curious.",
                "This schematicTypeLower contains the instructions on processNameCont aAnobjName at a objBench. This objName is a special piece of jewelry, it is made with love and care. I will need to use quality materials and follow the processNameCont method to make it. I can feel the friendship and the generosity of this piece, it makes me grateful.",
                "This schematicTypeLower teaches me the way of processNameCont aAnobjName using a objBench. This objName is a ancient piece of jewelry, it has a long history and tradition. I will need to use rare materials and master the processNameCont technique to make it. I can see the wisdom and the knowledge of this piece, it makes me curious.",
                "To get started on processNameCont aAnobjName, I will need this schematicTypeLower and access to a objBench. This objName is a exotic piece of jewelry, it comes from a faraway land. I will need to use unique materials and follow the processNameCont method to make it. I can see the spice and the zest of this piece, it makes me adventurous.",
                "This schematicTypeLower reveals the secrets of processNameCont aAnobjName at a objBench. This objName is a legendary piece of jewelry, only the worthy can obtain it. I will need to use special materials and master the secrets and arts of the craft to make it. I can see the glory and the honor of this piece, it makes me proud.",
                "To craft aAnobjName, I will need this schematicTypeLower and access to a objBench. This objName is a simple piece of jewelry, but it has a hidden twist. I will need to use common materials and follow the processNameCont technique to make it. I can taste the sweetness and the sourness of this piece, it surprises me.",
                "This schematicTypeLower tells me the way of processNameCont aAnobjName at a objBench. This objName is a elegant piece of jewelry, it is perfect for celebrations and parties. I will need to use shiny materials and follow the processNameCont method to make it. I can hear the laughter and the joy of this piece, it makes me festive.",
                "This schematicTypeLower shows me how to get started on processNameCont aAnobjName using a objBench. This objName is a colorful piece of jewelry, it is good for any occasion. I will need to use bright materials and follow the processNameCont method to make it. I can see the sparkle and the flair of this piece, it makes me dazzled.",
                "I will need this schematicTypeLower and access to a objBench to processNameCont aAnobjName. This objName is a mysterious piece of jewelry, it has a secret ingredient and a hidden effect. I will need to use unknown materials and follow the processNameCont technique to make it. I can taste the mystery and the magic of this piece, it makes me curious.",
                "This schematicTypeLower explains the steps of processNameCont aAnobjName at a objBench. This objName is a beautiful piece of jewelry, it is made with love and care. I will need to use quality materials and follow the processNameCont method to make it. I can feel the friendship and the generosity of this piece, it makes me grateful.",
            };

        public static string starterGuideText =
            "<font size='20'>The Codex of Hephaestus: A Blacksmith's Lore</font><br><p align='center'>By Crithion Loren</p>[pagebreak]<font size='16'>Chapter I: The Anvil's Whisper</font><br>In the dim forge's embrace, where flames lick hungrily at iron, I inscribe these words. Crithion Loren, keeper of the ancient anvil, bequeaths to you the knowledge of our craft. Listen, young smith, for within these pages lies the symphony of steel—the rhythm of creation that echoes through time.<br><br><font size='16'>Bows: The Archer's Oath</font><br>The bow, my apprentice, is more than wood and string. It is the whisper of distant forests, the flight of the hawk. Its parts—grip, bowstring, limbs—each hold a secret. As you master your craft, delve into their essence. Research their language, for the archer's oath lies in their union.<br><br><font size='16'>War Axes: Fury Unleashed</font><br>Behold the war axe—a tempest in iron. Its pommel, one-handed handle, standard shaft, and axe head yearn for purpose. To wield it is to channel rage and honor. Craft its blueprints with reverence. Let the blade sing of battles past, and may its bite cleave destiny itself.<br><br><font size='16'>Swords: Blades of Destiny</font><br>The sword—a companion to kings and outlaws alike. Its pommel, one-handed handle, guard, and short blade form a pact. Each whispers tales of valor and betrayal. Research them, my friend. Seek the blade's language, and perhaps you'll glimpse the echoes of ancient duels.<br><br><font size='16'>Greatswords: Titans' Roar</font><br>Two-handed, unwieldy, yet majestic—the greatsword. Pommel, two-handed handle, guard, and great blade—they yearn for unity. In their union lies the power to sunder mountains or defend hearths. Research their symphony, and may your forge echo with the roar of titans.<br><br><font size='16'>Battleaxes: Sundered Realms</font><br>The battleaxe—a brute's delight. Pommel, two-handed handle, long shaft, and great axe blade—they hunger for purpose. As you craft their blueprints, remember the fallen. Perhaps this blade once hewed through armies, or perhaps it was forged in defiance. Seek its story, and let it shape yours.<br><br><font size='16'>Warhammers: Anvil's Thunder</font><br>The warhammer—a force of reckoning. Pommel, two-handed handle, long shaft, and great hammer head—they resonate with ancient wrath. Research their language, my kin. Forged by gods or wielded by giants, they carry the weight of empires. May your hammer strike true, and may the anvil tremble in approval.[pagebreak]Chapter II: Armor and Attire: Weaving Legends<br>Now, let us turn to armor and attire—the second skin of warriors and wanderers. Each piece, a canvas for tales. Here, the parts multiply like stars in the night sky:<br><br>Clothing: Threads of Fate<br>Hats: Inner lining and stitching pattern.<br>Clothes: Inner lining, chest stitching, arm stitching, and trousers.<br>Gloves: Inner lining and stitching pattern.<br>Shoes: Inner lining and stitching pattern.<br>Light Armor: Grace and Steel<br>Light Helmets: Padding and the helmet itself.<br>Light Cuirass: Padding, light breastplate, pauldron, and tasset.<br>Light Gauntlets: Padding, vambrace, rerebrace, and gauntlet.<br>Light Boots: Sabaton padding, light greaves, poleyns, and sabaton.<br>Heavy Armor: Forged Resilience<br>Heavy Helmets: Padding and the weighty helm.<br>Heavy Cuirass: Padding, heavy breastplate, pauldron, and tasset.<br>Heavy Gauntlets: Padding, vambrace, rerebrace, and gauntlet.<br>Heavy Boots: Sabaton padding, heavy greaves, poleyns, and sabaton.<br><br><font size='16'>Shields: Guardians of Valor</font><br>Lastly, the shield—a guardian's embrace. Trim, handle, and face—they shield us from fate's arrows. Seek their whispers, honor their origins, and weave your legend upon the loom of the forge.[pagebreak]<font size='18'>Epilogue: The Anvil's Benediction</font><br>Go forth, my kin, and let Hephaestus guide your hands. May your forge roar like a dragon's breath, and may your blueprints sing across Tamriel. Remember, mastery is not swift, but it is purposeful. Seek the whispers, honor the fallen, and forge your own legend.<br><br>May the gods temper your steel, and may your hammer strike true.<br><br>—Crithion Loren, Keeper of the Anvil";

        public static Dictionary<FormKey, Model> bookModelLib = new Dictionary<FormKey, Model>()
        {
            {
                Skyrim.Static.HighPolyJournal.FormKey,
                new Model() { File = "Clutter/Books/JournalLowPoly01.nif" }
            },
            {
                Skyrim.Static.HighPolyJournal02.FormKey,
                new Model() { File = "Clutter/Books/JournalLowPoly02.nif" }
            },
            {
                Skyrim.Static.HighPolyJournal03.FormKey,
                new Model() { File = "Clutter/Books/JournalLowPoly03.nif" }
            }
        };

        public static Dictionary<FormKey, Model> bookFragmentModelLib = new Dictionary<
            FormKey,
            Model
        >()
        {
            {
                Skyrim.Static.HighPolyNote.FormKey,
                new Model() { File = "Clutter/Books/Note.nif" }
            },
            {
                Skyrim.Static.HighPolyNote02.FormKey,
                new Model() { File = "Clutter/Books/Note02.nif" }
            },
            {
                Skyrim.Static.HighPolyNote03.FormKey,
                new Model() { File = "Clutter/Books/Note03.nif" }
            },
            {
                Skyrim.Static.HighPolyNote04.FormKey,
                new Model() { File = "Clutter/Books/Note04.nif" }
            }
        };

        public static List<FormKey> LootLVLIWhitelistBase =
            new() { Skyrim.LeveledItem.LItemLeatherAndStrips75.FormKey };

        public static List<FormKey> LootLVLIWhitelistBlacksmith =
            new()
            {
                Skyrim.LeveledItem.LItemArmorBootsHeavyBlacksmith.FormKey,
                Skyrim.LeveledItem.LitemArmorBootsLightBlacksmith.FormKey,
                Skyrim.LeveledItem.LItemArmorCuirassHeavyBlacksmith.FormKey,
                Skyrim.LeveledItem.LItemArmorCuirassLightBlacksmith.FormKey,
                Skyrim.LeveledItem.LItemArmorGauntletsHeavyBlacksmith.FormKey,
                Skyrim.LeveledItem.LItemArmorGauntletsLightBlacksmith.FormKey,
                Skyrim.LeveledItem.LitemArmorShieldHeavyBlacksmith.FormKey,
                Skyrim.LeveledItem.LItemArmorShieldLightBlacksmith.FormKey,
                Skyrim.LeveledItem.LItemArmorShieldLightBlacksmith.FormKey,
                Skyrim.LeveledItem.LItemEnchWeaponBowBlacksmith.FormKey,
                Skyrim.LeveledItem.LItemEnchBlacksmithBow75.FormKey,
                Skyrim.LeveledItem.LItemEnchWeaponMaceBlacksmith.FormKey,
                Skyrim.LeveledItem.LItemEnchWeaponSwordBlacksmith.FormKey,
                Skyrim.LeveledItem.LItemEnchWeaponDaggerBlacksmith.FormKey,
                Skyrim.LeveledItem.LItemEnchWeaponDaggerBlacksmith15.FormKey,
                Skyrim.LeveledItem.LItemEnchWeaponWarAxeBlacksmith.FormKey,
                Skyrim.LeveledItem.LItemEnchWeaponBattleaxeBlacksmith.FormKey,
                Skyrim.LeveledItem.LItemEnchWeaponWarhammerBlacksmith.FormKey,
                Skyrim.LeveledItem.LItemEnchWeaponGreatswordBlacksmith.FormKey,
                Skyrim.LeveledItem.LItemBlacksmithMinBattleaxe.FormKey,
                Skyrim.LeveledItem.LItemBlacksmithMinBootsHeavy.FormKey,
                Skyrim.LeveledItem.LItemBlacksmithMinBootsLight.FormKey,
                Skyrim.LeveledItem.LItemBlacksmithMinBow.FormKey,
                Skyrim.LeveledItem.LItemBlacksmithMinCuirassHeavy.FormKey,
                Skyrim.LeveledItem.LItemBlacksmithMinCuirassLight.FormKey,
                Skyrim.LeveledItem.LItemBlacksmithMinDagger.FormKey,
                Skyrim.LeveledItem.LItemBlacksmithMinGauntletsHeavy.FormKey,
                Skyrim.LeveledItem.LItemBlacksmithMinGauntletsLight.FormKey,
                Skyrim.LeveledItem.LItemBlacksmithMinGreatsword.FormKey,
                Skyrim.LeveledItem.LItemBlacksmithMinHelmetHeavy.FormKey,
                Skyrim.LeveledItem.LItemBlacksmithMinHelmetLight.FormKey,
                Skyrim.LeveledItem.LItemBlacksmithMinMace.FormKey,
                Skyrim.LeveledItem.LItemBlacksmithMinShieldHeavy.FormKey,
                Skyrim.LeveledItem.LItemBlacksmithMinShieldLight.FormKey,
                Skyrim.LeveledItem.LItemBlacksmithMinSword.FormKey,
                Skyrim.LeveledItem.LItemBlacksmithMinWaraxe.FormKey,
                Skyrim.LeveledItem.LItemBlacksmithMinWaraxe.FormKey,
                Skyrim.LeveledItem.LItemBlacksmithMinWarhammer.FormKey,
                Dragonborn.LeveledItem.DLC2BlacksmithArmorExtra100.FormKey,
                Dragonborn.LeveledItem.DLC2BlacksmithArmorExtra75.FormKey,
                Dragonborn.LeveledItem.DLC2BlacksmithArmorStalhrim75.FormKey,
                Dragonborn.LeveledItem.DLC2BlacksmithNordicWeapon75.FormKey,
                Dragonborn.LeveledItem.DLC2BlackSmithStalhrimWeapon75.FormKey,
            };

        public static List<FormKey> LootLVLIWhitelistVendor =
            new()
            {
                Skyrim.LeveledItem.LItemMiscVendorMineralsProcessed25.FormKey,
                Skyrim.LeveledItem.LItemMiscVendorMineralsRaw50.FormKey,
                Skyrim.LeveledItem.LItemMiscVendorMiscItems75.FormKey,
                Skyrim.LeveledItem.LItemWeaponBowTown.FormKey,
                Skyrim.LeveledItem.LItemWeaponMaceTown.FormKey,
                Skyrim.LeveledItem.LItemWeaponSwordTown.FormKey,
                Skyrim.LeveledItem.LItemWeaponDaggerTown.FormKey,
                Skyrim.LeveledItem.LItemWeaponWarAxeTown.FormKey,
                Skyrim.LeveledItem.LItemArmorBootsHeavyTown.FormKey,
                Skyrim.LeveledItem.LitemArmorBootsLightTown.FormKey,
                Skyrim.LeveledItem.LItemWeaponBattleAxeTown.FormKey,
                Skyrim.LeveledItem.LItemWeaponWarhammerTown.FormKey,
                Skyrim.LeveledItem.LItemArmorHelmetHeavyTown.FormKey,
                Skyrim.LeveledItem.LItemArmorHelmetLightTown.FormKey,
                Skyrim.LeveledItem.LitemArmorShieldHeavyTown.FormKey,
                Skyrim.LeveledItem.LItemArmorShieldLightTown.FormKey,
                Skyrim.LeveledItem.LItemWeaponGreatSwordTown.FormKey,
                Skyrim.LeveledItem.LItemArmorCuirassHeavyTown.FormKey,
                Skyrim.LeveledItem.LItemArmorCuirassLightTown.FormKey,
                Skyrim.LeveledItem.LItemArmorGauntletsHeavyTown.FormKey,
                Skyrim.LeveledItem.LItemArmorGauntletsLightTown.FormKey,
                Skyrim.LeveledItem.LItemFoodInnCommon.FormKey,
                Skyrim.LeveledItem.LootDrinkList25.FormKey,
                Dragonborn.LeveledItem.DLC2LItemIngredientFoodPrepared.FormKey
            };

        public static List<FormKey> LootLVLIWhitelistSpecial =
            new()
            {
                Skyrim.LeveledItem.LItemArmorBootsHeavySpecial.FormKey,
                Skyrim.LeveledItem.LItemArmorBootsLightSpecial.FormKey,
                Skyrim.LeveledItem.LItemArmorCuirassHeavySpecial.FormKey,
                Skyrim.LeveledItem.LItemArmorCuirassLightSpecial.FormKey,
                Skyrim.LeveledItem.LItemArmorGauntletsHeavySpecial.FormKey,
                Skyrim.LeveledItem.LItemArmorGauntletsLightSpecial.FormKey,
                Skyrim.LeveledItem.LItemArmorShieldHeavySpecial.FormKey,
                Skyrim.LeveledItem.LItemArmorShieldLightSpecial.FormKey,
                Skyrim.LeveledItem.LItemArmorShieldLightSpecial.FormKey,
                Skyrim.LeveledItem.LootBanditChestBossBase.FormKey,
                Skyrim.LeveledItem.LootBanditChestBossMagicItem25.FormKey,
                Skyrim.LeveledItem.LootBanditChestBossMagicItem100.FormKey,
                Skyrim.LeveledItem.LootCWSonsChestBossBase.FormKey,
                Skyrim.LeveledItem.LootCWImperialsChestBossBase.FormKey,
                Skyrim.LeveledItem.LootDraugrChestBossBase.FormKey,
                Skyrim.LeveledItem.LootDraugrChestBossMagicItem25.FormKey,
                Skyrim.LeveledItem.LootFalmerChestBossBase.FormKey,
                Skyrim.LeveledItem.LootDwarvenChestBossBase.FormKey,
                Skyrim.LeveledItem.LootVampireChestBossBase.FormKey,
                Skyrim.LeveledItem.LootWarlockChestBossBase.FormKey,
                Skyrim.LeveledItem.LootWarlockChestBossMagicItem25.FormKey,
                Skyrim.LeveledItem.LootForswornChestBossBase.FormKey,
                Skyrim.LeveledItem.LootHagravenChestBossBase.FormKey,
                Skyrim.LeveledItem.LootWerewolfChestBossBase.FormKey,
                Skyrim.LeveledItem.LItemLootIMineralsProcessed.FormKey,
            };
    }
}
