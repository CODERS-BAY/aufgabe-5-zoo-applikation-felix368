using ZooAPI.model;

namespace ZooAPI.controller;

public class BesucherController
{
    public static async Task<Dictionary<string, string>[]> GetAnimalByGattung(string searchAnimal)
    {
        
        var animals = await SqlCommands.GetTiere($"select * from tiere where gattung = '{searchAnimal}';");
        
        
        var animalValues = new Dictionary<string,string>[animals.Count];
        

        int counter = 0;
        foreach (var animal in animals)
        {
            
            Console.WriteLine(animal.ToString());
            animalValues[counter] = animal.GetAnimalValues();
            counter += 1;
        }

        return animalValues;
    }
    
    
    
}