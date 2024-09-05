using System;
using System.IO;
using System.Runtime.InteropServices;

class Program
{
    static string[] lines;

    static void Main()


    {
        string filePath = "input.csv";
        lines = File.ReadAllLines(filePath);

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
        var lastCharacterID = lines.Length - 1;
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
        var firstEquipment = Console.ReadLine();

        //TODO  Create list of Equipment and add firstEquipment to the list



        // TODO  Create Menu to ask if user wants to add aadditional equipment or not
        //  TODO  Create switch statement to process additional equipment and add to existing list
        // TODO  if user selects done with adding equipment - Create a loop to add list items to string with "|" to seperate items 
        // TODO Append the new character to the lines array with auto generating ID
        Console.WriteLine();
        Console.WriteLine($"1. Add Another Piece of Equipment to Character {nameInput}");
        Console.WriteLine($"2. Finished Adding Equipment. Build Character {nameInput}");
        Console.WriteLine($"3. Do Not Build Character {nameInput}. Delete Progress and Return to Main Menu");
        Console.Write("Enter The Number Of Your choice And Press Enter: ");
        string buildCharacterMenuChoice = Console.ReadLine();
        Console.WriteLine();

        switch (buildCharacterMenuChoice)
        {
            case "1":
                Console.WriteLine();
                Console.WriteLine("Enter Your Character's Next Piece of Equipment and Press Enter: ");
                //  Add additional Equipment to existing list
                break;
            case "2":
                Console.WriteLine();
                // TODO 
                //  Build Character
                //  Create Pipe delineated string from list of Equipment
                //  Create Character ID
                //  Append character attriputes to input.csv
                //  Display character attributes and verify it is added to input.csv
                break;
            case "3":
                return;
            default:
                Console.WriteLine();
                Console.WriteLine("Invalid choice. Please Select the Number of your Choice and Press Enter.");
                break;
















        }
    }

    // Method to Level up a Character
    static void LevelUpCharacter(string[] lines)
    {
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
    }
}