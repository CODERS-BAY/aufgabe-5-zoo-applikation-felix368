namespace ZooAPI.controller;

public class Tierpfleger
{
    
    public static async Task<Dictionary<string, string>[]> GetAnimalByPflegerId(string pflegerId)
    {
        
        var animals = await SqlCommands.GetTiere($"select tiere.id,tiere.gattung,tiere.nahrung,tiere.gehegeId from tiere join gehege g on g.Id = tiere.gehegeId join mitarbeiter m on g.mitarbeiterId = m.id where mitarbeiterId = '{pflegerId}';");
        
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


    public static async Task UpdateAnimal(string id,string columnNr,string newData)
    {

        await SqlCommands.NewSqlInsertCommand($"update tiere set {columnNr} ='{newData}' where id={id};");


    }





}