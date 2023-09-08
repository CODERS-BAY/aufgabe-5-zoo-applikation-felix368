using System.Text.Json.Nodes;
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
        
        var dic = new Dictionary<string,int>();
        
        for(int i = 0; i < valuePare.Length; i++)
        {
            var pare = valuePare[i].Split(":");
            
            dic.Add(pare[0], int.Parse(pare[1]));
        }
        
        return dic;
    }
    

    private static List<double> GetPrices(Dictionary<string,int> dic)
    {
        double adultPrice = 8.50;
        double childPrice = 8.50;
        
        
        List<double> ticketPrices = new();

        
        foreach (var key in dic.Keys)
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

        var ticketPrices = GetPrices(dic);

        double sum = 0;
        foreach (var ticketPrice in ticketPrices)
        {
            Console.WriteLine(ticketPrice);
            await SqlCommands.NewSqlInsertCommand($"insert into Tickets(preis) value (8.50);");
            sum =sum + ticketPrice;
        }
        
        return sum;
    }


    public static async Task<Dictionary<string,string>[]> GetSoldTickets(DateTime date)
    {
        Console.WriteLine($"select * from Tickets where date(zeitpunkt) ='{date.ToString("yyyy-MM-dd")}'");
        var tickets = await SqlCommands.GetSoldTicketsByDate($"select * from Tickets where date(zeitpunkt) ='{date.ToString("yyyy-MM-dd")}'");

        
        
        var ticketValues = new Dictionary<string,string>[tickets.Count];

        int counter = 0;
        foreach (var ticket in tickets)
        {
            
            Console.WriteLine(ticket.ToString());
            ticketValues[counter] = ticket.GetTicketValues();
            counter += 1;
        }

        Console.WriteLine(ticketValues);

        return ticketValues;
    }

}