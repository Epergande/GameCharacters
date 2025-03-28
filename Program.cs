﻿﻿using NLog;
using System.Reflection;
using System.Text.Json;
string path = Directory.GetCurrentDirectory() + "//nlog.config";

// create instance of Logger
var logger = LogManager.Setup().LoadConfigurationFromFile(path).GetCurrentClassLogger();

logger.Info("Program started");

// deserialize mario json from file into List<Mario>
string marioFileName = "mario-rename.json";
List<Mario> marios = [];
 // check if file exists
 if (File.Exists(marioFileName))
 {
   marios = JsonSerializer.Deserialize<List<Mario>>(File.ReadAllText(marioFileName))!;
   logger.Info($"File deserialized {marioFileName}");
 }
string dkFileName = "dk.json";
List<Dk> dks = [];
if (File.Exists(dkFileName))
{
  dks = JsonSerializer.Deserialize<List<Dk>>(File.ReadAllText(dkFileName))!;
  logger.Info($"File deserialized {dkFileName}");
}
string sfFileName = "sf.json";
List<Sf> sfs = [];
if (File.Exists(sfFileName))
{
  sfs = JsonSerializer.Deserialize<List<Sf>>(File.ReadAllText(sfFileName))!;
  logger.Info($"File deserialized {sfFileName}");
}
do
{
  // display choices to user
  Console.WriteLine("1) Display Mario Characters");
  Console.WriteLine("2) Add Mario Character");
  Console.WriteLine("3) Remove Mario Character");
  Console.WriteLine("4) Display Donkey kong chareaters");
  Console.WriteLine("5) Add Donkey kong character");
  Console.WriteLine("6) Remove Donkey Kong character");
  Console.WriteLine("7) Display Street Fighter 2 chraracters");
  Console.WriteLine("8) Add Street Fighter 2 chraracter");
  Console.WriteLine("9) Remove Street Fighter 2 chraracter");
  Console.WriteLine("10) Edit a character");
  Console.WriteLine("Press enter to quit");

  // input selection
  string? choice = Console.ReadLine();
  logger.Info("User choice: {Choice}", choice);

  if (choice == "1")
  {
    // Display Mario Characters
    foreach(var c in marios)
    {
      Console.WriteLine(c.Display());
    }
  }
  else if (choice == "2")
  {
    // Add Mario Character
    // Generate unique Id
    Mario mario = new()
    {
      Id = marios.Count == 0 ? 1 : marios.Max(c => c.Id) + 1
    };
    InputCharacter(mario);
        marios.Add(mario);
     File.WriteAllText(marioFileName, JsonSerializer.Serialize(marios));
     logger.Info($"Character added: {mario.Name}");
  }
  else if (choice == "3")
  {
    // Remove Mario Character
    Console.WriteLine("Enter the Id of the character to remove:");
     if (UInt32.TryParse(Console.ReadLine(), out UInt32 Id))
     {
       Mario? character = marios.FirstOrDefault(c => c.Id == Id);
       if (character == null)
       {
         logger.Error($"Character Id {Id} not found");
       } else {
        marios.Remove(character);
         // serialize list<marioCharacter> into json file
         File.WriteAllText(marioFileName, JsonSerializer.Serialize(marios));
         logger.Info($"Character Id {Id} removed");
       }
     } else {
       logger.Error("Invalid Id");
     }
  }
    else if (choice == "4")
  {
    // Display Mario Characters
    foreach(var c in dks)
    {
      Console.WriteLine(c.Display());
    }
  }
    else if (choice == "5")
  {
    // Add dk Character
    // Generate unique Id
    Dk dk = new()
    {
      Id = dks.Count == 0 ? 1 : dks.Max(c => c.Id) + 1
    };
    InputCharacter(dk);
        dks.Add(dk);
     File.WriteAllText(dkFileName, JsonSerializer.Serialize(dks));
     logger.Info($"Character added: {dk.Name}");
  }
  else if (choice == "6")
  {
    // Remove dk Character
    Console.WriteLine("Enter the Id of the character to remove:");
     if (UInt32.TryParse(Console.ReadLine(), out UInt32 Id))
     {
       Dk? character = dks.FirstOrDefault(c => c.Id == Id);
       if (character == null)
       {
         logger.Error($"Character Id {Id} not found");
       } else {
        dks.Remove(character);
         // serialize list<marioCharacter> into json file
         File.WriteAllText(dkFileName, JsonSerializer.Serialize(dks));
         logger.Info($"Character Id {Id} removed");
       }
     } else {
       logger.Error("Invalid Id");
     }
  }
  else if (choice == "7")
  {
    // Display sf2 Characters
    foreach(var c in sfs)
    {
      Console.WriteLine(c.Display());
    }
  }
      else if (choice == "8")
  {
    // Add sf2 Character
    // Generate unique Id
    Sf sf = new()
    {
      Id = sfs.Count == 0 ? 1 : sfs.Max(c => c.Id) + 1
    };
    InputCharacter(sf);
        sfs.Add(sf);
     File.WriteAllText(sfFileName, JsonSerializer.Serialize(sfs));
     logger.Info($"Character added: {sf.Name}");
  }
    else if (choice == "9")
  {
    // Remove sf2 Character
    Console.WriteLine("Enter the Id of the character to remove:");
     if (UInt32.TryParse(Console.ReadLine(), out UInt32 Id))
     {
       Sf? character = sfs.FirstOrDefault(c => c.Id == Id);
       if (character == null)
       {
         logger.Error($"Character Id {Id} not found");
       } else {
        sfs.Remove(character);
         // serialize list<marioCharacter> into json file
         File.WriteAllText(sfFileName, JsonSerializer.Serialize(sfs));
         logger.Info($"Character Id {Id} removed");
       }
     } else {
       logger.Error("Invalid Id");
     }
  }
  else if (choice == "10")
  {
    //ediing characters
    Console.WriteLine("What list do you want to edit?");
    Console.WriteLine("1) Mario");
    Console.WriteLine("2) DK");
    Console.WriteLine("3) Sf2");
    string? choice2 = Console.ReadLine();

   if (choice2 == "1")
   {
    //edit mario
        Console.WriteLine("Enter the Id of the character to edit:");
     if (UInt32.TryParse(Console.ReadLine(), out UInt32 Id2))
     {
       Mario? character = marios.FirstOrDefault(c => c.Id == Id2);
       if (character == null)
       {
         logger.Error($"Character Id {Id2} not found");
       } else {
        marios.Remove(character);
         // serialize list<marioCharacter> into json file
         File.WriteAllText(marioFileName, JsonSerializer.Serialize(marios));
         logger.Info($"Character Id {Id2} removed");
       }
     } else {
       logger.Error("Invalid Id");
     }


         Mario mario = new()
    {
      Id = Id2
    };
    InputCharacter(mario);
        marios.Add(mario);
     File.WriteAllText(marioFileName, JsonSerializer.Serialize(marios));
     logger.Info($"Character edited: {mario.Name}");
   }
   else if (choice2 == "2")
   {
    Console.WriteLine("Enter the Id of the character to edit:");
     if (UInt32.TryParse(Console.ReadLine(), out UInt32 Id2))
     {
       Dk? character = dks.FirstOrDefault(c => c.Id == Id2);
       if (character == null)
       {
         logger.Error($"Character Id {Id2} not found");
       } else {
        dks.Remove(character);
         // serialize list<marioCharacter> into json file
         File.WriteAllText(dkFileName, JsonSerializer.Serialize(dks));
         logger.Info($"Character Id {Id2} removed");
       }
     } else {
       logger.Error("Invalid Id");
     }
    Dk dk = new()
    {
      Id = Id2
    };
    InputCharacter(dk);
        dks.Add(dk);
     File.WriteAllText(dkFileName, JsonSerializer.Serialize(dks));
     logger.Info($"Character edited: {dk.Name}");
   }
   else if (choice2 == "3")
   {
//edit sf2
    Console.WriteLine("Enter the Id of the character to edit:");
     if (UInt32.TryParse(Console.ReadLine(), out UInt32 Id2))
     {
       Sf? character = sfs.FirstOrDefault(c => c.Id == Id2);
       if (character == null)
       {
         logger.Error($"Character Id {Id2} not found");
       } else {
        sfs.Remove(character);
         // serialize list<marioCharacter> into json file
         File.WriteAllText(sfFileName, JsonSerializer.Serialize(sfs));
         logger.Info($"Character Id {Id2} removed");
       }
     } else {
       logger.Error("Invalid Id");
     }
         Sf sf = new()
    {
      Id = Id2
    };
    InputCharacter(sf);
        sfs.Add(sf);
     File.WriteAllText(sfFileName, JsonSerializer.Serialize(sfs));
     logger.Info($"Character edited: {sf.Name}");
   }   
  }
   else if (string.IsNullOrEmpty(choice)) {
    break;
  } else {
    logger.Info("Yeah,No, Invalid choice");
  }
} while (true);

logger.Info("Program ended");


 static void InputCharacter(Character character)
 {
   Type type = character.GetType();
   PropertyInfo[] properties = type.GetProperties();
   var props = properties.Where(p => p.Name != "Id");
   foreach (PropertyInfo prop in props)
   {
     if (prop.PropertyType == typeof(string))
     {
       Console.WriteLine($"Enter {prop.Name}:");
       prop.SetValue(character, Console.ReadLine());
     } else if (prop.PropertyType == typeof(List<string>)) {
       List<string> list = [];
       do {
         Console.WriteLine($"Enter {prop.Name} or (enter) to quit:");
         string response = Console.ReadLine()!;
         if (string.IsNullOrEmpty(response)){
           break;
         }
         list.Add(response);
       } while (true);
       prop.SetValue(character, list);
     }
   }
 }