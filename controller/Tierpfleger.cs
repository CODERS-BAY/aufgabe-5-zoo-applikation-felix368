namespace ZooAPI.controller;

public class Tierpfleger
{
    
    public static async Task<Dictionary<string, string>[]> getAnimalbyPflegerId(string pflegerId)
    {
        
        var animals = await SqlCommands.getTiere($"select tiere.id,tiere.gattung,tiere.nahrung,tiere.gehegeId from tiere join gehege g on g.Id = tiere.gehegeId join mitarbeiter m on g.mitarbeiterId = m.id where mitarbeiterId = '{pflegerId}';");
        
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


    public static async Task updateAnimal(string id,string columnNr,string newData)
    {

        await SqlCommands.NewSqlInsertCommand($"update tiere set {columnNr} ='{newData}' where id={id};");


    }





}