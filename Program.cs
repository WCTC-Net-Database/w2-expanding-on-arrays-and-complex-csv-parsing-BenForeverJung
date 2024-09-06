using System;
using System.IO;
using System.Runtime.InteropServices;

class Program
{
    static string[] lines;

    static void Main()


    {
        ReadFile();

        while (true)
        {
            // Menu and Switch Statement to process selections

            Console.WriteLine();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Display Characters");
            Console.WriteLine("2. Add Character");
            Console.WriteLine("3. Level Up Character");
            Console.WriteLine("4. Exit");
            Console.Write("Enter The Number Of Your choice And Press Enter: ");
            string mainMenuChoice = Console.ReadLine();
            Console.WriteLine();

            switch (mainMenuChoice)
            {
                case "1":
                    Console.WriteLine();
                    DisplayAllCharacters(lines);
                    break;
                case "2":
                    Console.WriteLine();
                    AddCharacter(ref lines);
                    break;
                case "3":
                    Console.WriteLine();
                    LevelUpCharacter(lines);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid choice. Please Select the Number of your Choice and Press Enter.");
                    break;
            }
        }
    }

    //--------- Main Break --------------------------------------------------------------

    // Method to ReadFile

    static void ReadFile()
    {
        string filePath = "input.csv";
        lines = File.ReadAllLines(filePath);
    }



    // Method to Display all Characters
    static void DisplayAllCharacters(string[] lines)
    {
        //Declare variables to output
        String characterID;
        string characterName;
        string characterClass;
        string characterLevel;
        string characterHP;
        string characterEquipment;


        // Skip the header row and parse individual lines
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] quotedNameArray = line.Split(',');
            var quotedNameTest = quotedNameArray[1];


            // Check if the name is quoted
            if (quotedNameTest.StartsWith('"'))
            {
                // Parse each line into individual character attributes
                    // Remove quotes from the name if present
                    // Replace | in quipment list with , and space for better readability

                String[] CharacterFields = line.Split(',');
                characterID = CharacterFields[0];
                var characterLastName = CharacterFields[1].Trim('"');
                var characterFirstName = CharacterFields[2].Trim('"');
                characterName = ($"{characterFirstName} {characterLastName}");
                characterClass = CharacterFields[3];
                characterLevel = CharacterFields[4];
                characterHP = CharacterFields[5];
                characterEquipment = CharacterFields[6].Replace("|", ", ");
            }
            else
            {
                // Parse each line into individual character attributes
                    // Remove quotes from the name if present
                    // Replace | in quipment list with , and space for better readability

                String[] CharacterFields = line.Split(',');
                characterID = CharacterFields[0];
                characterName = CharacterFields[1].Trim('"');
                characterClass = CharacterFields[2];
                characterLevel = CharacterFields[3];
                characterHP = CharacterFields[4];
                characterEquipment = CharacterFields[5].Replace("|", ", ");
            }

            //  Display charachter attributes with titles on a single line using the following format
                // Console.WriteLine($"Name: {name}, Class: {characterClass}, Level: {level}, HP: {hitPoints}, Equipment: {string.Join(", ", equipment)}");
            Console.WriteLine($"ID= {characterID}; Name= {characterName}; Class= {characterClass}; Level= {characterLevel}; Hit Points= {characterHP}; Equipment= {characterEquipment}");
            Console.WriteLine();

            // //  Display charachter attributes with titles (Vertical Format)
            //Console.WriteLine($"ID = {characterID}");
            //Console.WriteLine($"Name = {characterName}");
            //Console.WriteLine($"Class = {characterClass}");
            //Console.WriteLine($"Level = {characterLevel}");
            //Console.WriteLine($"HP = {characterHP}");
            //Console.WriteLine($"Equipment List = {characterEquipment}");
            //Console.WriteLine();

        }
    }

    // Method to Add a Character
    static void AddCharacter(ref string[] lines)
    {
        // Implement logic to add a new character

        //  Get last CharacterID
        var nextCharacterID = lines.Length;
                    // Console.WriteLine(lastCharacterID);  //  Test lastCharacterID output 

        // Prompt for character details (name, class, level, hit points, equipment)
        Console.WriteLine();
        Console.WriteLine("Enter Your Character's Name and Press Enter: ");
        var nameInput = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Enter Your Character's Class and Press Enter: ");
        var classInput = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Enter Your Character's Level and Press Enter: ");
        var levelInput = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Enter Your Character's Hit Power and Press Enter: ");
        var hitPowerInput = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Enter Your Character's First Piece of Equipment and Press Enter: ");
        var equipmentInput = Console.ReadLine();

        //  Use Do While loop to continu askiing for additional equipment until complete
            // Add to equipment string with Pipe delineated format
        //TODO Add input validation to Do While Inputs  - No Null for adding equipment and Y/N Questions
        bool addEquipment = true;

        do
        {
            Console.WriteLine();
            Console.WriteLine("Would You Like to Add Another Piece of Equipment? Enter Y for Yes or N for No. ");
            var addEquipmentresponse = Console.ReadLine();
            if (addEquipmentresponse == "Y" || addEquipmentresponse == "y")
            {
                Console.WriteLine();
                Console.WriteLine("Enter Your Character's Next Piece of Equipment and Press Enter: ");
                var nextEquipment = Console.ReadLine();
                equipmentInput = (equipmentInput + "|" + nextEquipment);
            }
            else addEquipment = false;
        } 
        while (addEquipment == true);

        // Combine all inputs into csv format and write to input.csv
        var characterBuild = ($"{nextCharacterID},{nameInput},{classInput},{levelInput},{hitPowerInput},{equipmentInput}");
        StreamWriter swInputCSV = new StreamWriter("input.csv",true);
        string newLine = swInputCSV.NewLine;
        swInputCSV.WriteLine(characterBuild);
        swInputCSV.Flush();
        swInputCSV.Close();

        // ReRead the updated input.csv file
        ReadFile();


        //  TODO Display character attributes and verify it is added to input.csv

    }









    // Method to Level up a Character
    static void LevelUpCharacter(string[] lines)
    {

        //Declare variables to output
        String characterID;
        string characterName;
        string characterClass;
        string characterLevel;
        string characterHP;
        string characterEquipment;
        
        DisplayAllCharacters(lines);
        Console.Write("Enter the ID Number of the character to level up: ");
        string idToLevelUp = Console.ReadLine();
        Console.WriteLine();
        Console.Write("Enter New level for the Character : ");


        // Loop through characters to find the one to level up
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] quotedNameArray = line.Split(',');
            var quotedNameTest = quotedNameArray[1];

            // TODO: Check if the name matches the one to level up
            // Do not worry about case sensitivity at this point
            if (line.StartsWith(idToLevelUp))
            {

                // Check if the name is quoted
                if (quotedNameTest.StartsWith('"'))
                {
                    // Parse each line into individual character attributes
                    // Remove quotes from the name if present
                    // Replace | in quipment list with , and space for better readability

                    String[] CharacterFields = line.Split(',');
                    characterID = CharacterFields[0];
                    var characterLastName = CharacterFields[1].Trim('"');
                    var characterFirstName = CharacterFields[2].Trim('"');
                    characterName = ($"{characterFirstName} {characterLastName}");
                    characterClass = CharacterFields[3];
                    characterLevel = CharacterFields[4];
                    characterHP = CharacterFields[5];
                    characterEquipment = CharacterFields[6].Replace("|", ", ");
                }
                else
                {
                    // Parse each line into individual character attributes
                    // Remove quotes from the name if present
                    // Replace | in quipment list with , and space for better readability

                    String[] CharacterFields = line.Split(',');
                    characterID = CharacterFields[0];
                    characterName = CharacterFields[1].Trim('"');
                    characterClass = CharacterFields[2];
                    characterLevel = CharacterFields[3];
                    characterHP = CharacterFields[4];
                    characterEquipment = CharacterFields[5].Replace("|", ", ");
                }
                //Display Selected Characcter
                Console.WriteLine();
                Console.WriteLine($"You Selected");
                Console.WriteLine($"ID = {characterID}");
                Console.WriteLine($"Name = {characterName}");
                Console.WriteLine($"Class = {characterClass}");
                Console.WriteLine($"Level = {characterLevel}");
                Console.WriteLine($"HP = {characterHP}");
                Console.WriteLine($"Equipment List = {characterEquipment}");
                Console.WriteLine();
                //  Ask User for new level
                Console.WriteLine();
                Console.Write($"Enter New {characterClass} Level for the {characterName} ");
                string newCharacterLevel = Console.ReadLine();

                // Combine all inputs into csv format and write to input.csv
                var characterBuild = ($"{characterID},{characterName},{characterClass},{newCharacterLevel},{characterHP},{characterEquipment}");
                
                //StreamWriter swInputCSV = new StreamWriter("input.csv", true);
                //string newLine = swInputCSV.NewLine;
                //swInputCSV.WriteLine(characterBuild);
                //swInputCSV.Flush();
                //swInputCSV.Close();

                // ReRead the updated input.csv file
                ReadFile();

            }
        }









        /*
        Console.Write("Enter the name of the character to level up: ");
        string nameToLevelUp = Console.ReadLine();

        // Loop through characters to find the one to level up
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];

            // TODO: Check if the name matches the one to level up
            // Do not worry about case sensitivity at this point
            if (line.Contains(nameToLevelUp))
            {

                // TODO: Split the rest of the fields locating the level field
                // string[] fields = ...
                // int level = ...

                // TODO: Level up the character
                // level++;
                // Console.WriteLine($"Character {name} leveled up to level {level}!");

                // TODO: Update the line with the new level
                // lines[i] = ...
                break;
            }
        }
        */
    }
}