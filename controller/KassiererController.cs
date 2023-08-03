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
            await DBConnection.NewSqlCommand($"insert into Tickets(preis) value (8.50);");
            sum =sum + ticketPrice;
        }
        
        //await DBConnection.NewSqlCommand($"insert into Tickets(preis) value (8.50);");
        return sum;
    }
}