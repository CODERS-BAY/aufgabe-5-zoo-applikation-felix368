namespace ZooAPI.model;

public class Animal : IComparable<Animal>
{

    private int id { get; }
    private string gattung { get; }
    private string nahrung;
    private int gehegeId;
    
    

    public Animal(int id, string gattung, string nahrung, int gehegeId)
    {
        this.id = id;
        this.gattung = gattung;
        this.nahrung = nahrung;
        this.gehegeId = gehegeId;
    }

    public int Id => id;

    public int CompareTo(Animal? other)
    {
        if (other == null) return 1;
        return gattung.CompareTo(other.gattung);
    }

    public override bool Equals(object? obj)
    {
        if (obj.GetType() != this.GetType()) return false;
         
        var animalOne = (Animal)(obj);
        
        return (animalOne.id == this.id);
    }

    
    
    
    
    public override string ToString()
    {
        return $"id:{id},gattung:{gattung},nahrung:{nahrung},gehegeId:{gehegeId}";
    }
    
    
    public Dictionary<string, string> GetAnimalValues()
    {
        Dictionary<string, string> value = new();
        value.Add("id",$"{id}");
        value.Add("gattung", $"{gattung}");
        value.Add("nahrung",$"{nahrung}");
        value.Add("gehegeId",$"{gehegeId}");
        
        return value;
    }

    
}