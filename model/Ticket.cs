namespace ZooAPI.model;

public class Ticket : IComparable<Ticket>
{
    private double price;
    private DateTime date;
    private int id { get; }


    public Ticket(double price, DateTime dateTime, int id)
    {
        this.price = price;
        this.date = dateTime;
        this.id = id;
    }

    public int CompareTo(Ticket? other)
    {
        if (other == null) return 1;
        return id.CompareTo(other.id);
    }

    public override bool Equals(object? obj)
    {
        if (obj.GetType() != this.GetType()) return false;
         
        var otherTicket = (Ticket)(obj);
        
        return (otherTicket.id == this.id);
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
        
        return  value;
    }
}