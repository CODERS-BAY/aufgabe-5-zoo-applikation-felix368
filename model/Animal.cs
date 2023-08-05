namespace ZooAPI.model;

public class Animal : IComparable<Animal>
{

    private int id;
    private string gattung;
    private string nahrung;
    private int gehegeId;


    public Animal(int id, string gattung, string nahrung, int gehegeId)
    {
        this.id = id;
        this.gattung = gattung;
        this.nahrung = nahrung;
        this.gehegeId = gehegeId;
    }


    public int CompareTo(Animal? other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals(object? obj)
    {
        
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"id:{id},gattung:{gattung},nahrung:{nahrung},gehegeId:{gehegeId}";
    }
    
    
    public Dictionary<string, string> getAnimalValues()
    {
        Dictionary<string, string> value = new Dictionary<string, string>();
        value.Add("id",$"{id}");
        value.Add("gattung", $"{gattung}");
        value.Add("nahrung",$"{nahrung}");
        value.Add("gehegeId",$"{gehegeId}");
        
        return value;
    }
    
    
    
    
}