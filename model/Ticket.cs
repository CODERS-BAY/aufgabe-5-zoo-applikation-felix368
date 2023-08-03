namespace ZooAPI.model;

public class Ticket : IComparable<Ticket>
{
    private double price;
    private DateTime dateTime;
    private int id;


    public Ticket(double price, DateTime dateTime, int id)
    {
        this.price = price;
        this.dateTime = dateTime;
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
        return $"Ticket Price:{price} \n time:{dateTime}";
    }
}