namespace ZooAPI.model;

public class Ticket : IComparable<Ticket>
{
    private double price;
    private DateTime date;
    private int id;


    public Ticket(double price, DateTime dateTime, int id)
    {
        this.price = price;
        this.date = dateTime;
        this.id = id;
    }

    public int CompareTo(Ticket? other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals(object? obj)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"Ticket Price:{price} \n time:{date}";
    }

    public Dictionary<string, string> getTicketValues()
    {
        Dictionary<string, string> value = new Dictionary<string, string>();
        value.Add("id",$"{id}");
        value.Add("price", $"{price}");
        value.Add("timeStamp",$"{date}");
        
        return value;
    }
}