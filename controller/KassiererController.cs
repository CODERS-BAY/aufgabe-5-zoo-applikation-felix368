using ZooAPI.model;

namespace ZooAPI.controller;

public class KassiererController
{
    
    private static Dictionary<string,int> StringToDic(string input)
    {
        input = input.Replace("{", "");
        input = input.Replace("}", "");
        input = input.Replace("\"", "");
        input = input.Replace("\n", "");
        input = input.Replace(" ", "");
        var valuePare = input.Split(',');
        
        Console.WriteLine("---");
        Console.WriteLine(valuePare[1]);
        Console.WriteLine("---");
        
        
        var dic = new Dictionary<string,int>();
        
        
        for (int i = 0; i < valuePare.Length; i++)
        {
            var pare = valuePare[i].Split(":");
            Console.WriteLine(pare[0]);
            dic.Add(pare[0], int.Parse(pare[1]));
        }

        

        return dic;
    }
    

    private static List<double> getPrices(Dictionary<string,int> dic)
    {
        double adultPrice = 8.50;
        double childPrice = 8.50;
        
        
        List<double> ticketPrices = new List<double>();

        var keys = dic.Keys;
        foreach (var key in keys)
        {
            
            
            for (int a = 0; a < dic[key]; a++)
            {
                
                if (key.Equals("child"))
                {
                    
                    ticketPrices.Add(childPrice);
                }
                else
                {
                    ticketPrices.Add(adultPrice);
                }

            }
        }

        return ticketPrices;
    }
    
    
    
    public static async Task<double> InsertTicketInDb(string inputString)
    {
    
        var dic = StringToDic(inputString);

        var ticketPrices = getPrices(dic);

        double sum = 0;
        foreach (var ticketPrice in ticketPrices)
        {
            Console.WriteLine(ticketPrice);
            await SqlCommands.NewSqlInsertCommand($"insert into Tickets(preis) value (8.50);");
            sum =sum + ticketPrice;
        }
        
        return sum;
    }


    public static async Task<Dictionary<string,string>[]> getSoldTicets(DateTime date)
    {
        Console.WriteLine($"select * from Tickets where date(zeitpunkt) ='{date.ToString("yyyy-MM-dd")}'");
        var tickets = await SqlCommands.getSoldTicketsByDate($"select * from Tickets where date(zeitpunkt) ='{date.ToString("yyyy-MM-dd")}'");

        
        
        var ticketValues = new Dictionary<string,string>[tickets.Count];

        int counter = 0;
        foreach (var ticket in tickets)
        {
            
            Console.WriteLine(ticket.ToString());
            ticketValues[counter] = ticket.getTicketValues();
            counter += 1;
        }

        Console.WriteLine(ticketValues);

        return ticketValues;
    }

}