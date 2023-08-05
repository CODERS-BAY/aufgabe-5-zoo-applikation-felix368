using ZooAPI.model;

namespace ZooAPI.controller;

public class BesucherController
{
    public static async Task<Dictionary<string, string>[]> getAnimalbyGattung(string searchAnimal)
    {
        
        var animals = await DBConnection.getTiere($"select * from tiere where gattung = '{searchAnimal}';");
        
        
        var animalvalues = new Dictionary<string,string>[animals.Count];
        

        int counter = 0;
        foreach (var animal in animals)
        {
            
            Console.WriteLine(animal.ToString());
            animalvalues[counter] = animal.getAnimalValues();
            counter += 1;
        }


        return animalvalues;

    }
    
    
    
    
    
    
    
}