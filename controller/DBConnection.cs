using Microsoft.VisualBasic;
using MySqlConnector;
using ZooAPI.model;

namespace ZooAPI.controller;

public class DBConnection
{
    static MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
    {
        Server = "localhost",
        Database = "Zoo",
        UserID = "root",
        Password = "admin",
        SslMode = MySqlSslMode.Disabled
    };
    
    
    public static async Task NewSqlInsertCommand(String sqlCommand)
    {
        await using (var conn = new MySqlConnection(builder.ConnectionString))
        {
            Console.WriteLine("Opening Conction");
            await conn.OpenAsync();


            await using (var command = conn.CreateCommand())
            {
                command.CommandText = sqlCommand;

                // exicute statment in database 
                await using (var reander = await command.ExecuteReaderAsync())
                {
                    while (await reander.ReadAsync())
                    {
                        Console.WriteLine($"{reander.GetInt32(0)}");
                        //Console.WriteLine($"Reading from table= ({reander.GetInt32(0)},{reander.GetString(1)})");
                        
                    }
                }
            }
        }
        
    }

    
    
    
    public static async Task<List<Ticket>> getSoldTicketsByDate(String sqlCommand)
    {
        List<Ticket> tickets = new List<Ticket>();
        await using (var conn = new MySqlConnection(builder.ConnectionString))
        {
            Console.WriteLine("Opening Conction");
            await conn.OpenAsync();

            
            await using (var command = conn.CreateCommand())
            {
                command.CommandText = sqlCommand;
                
                
                // exicute statment in database 
                await using (var reander = await command.ExecuteReaderAsync())
                {
                    
                    while (await reander.ReadAsync())
                    {
                        Ticket currentTicket = new Ticket(reander.GetDouble(1),reander.GetDateTime(2),reander.GetInt32(0));
                        
                        tickets.Add(currentTicket);
                        
                    }
                }
            }
        }

        return tickets;
    }
    
    

   
    
    public static async Task<List<Animal>> getTiereByGattung(String sqlCommand)
    {
        List<Animal> animals = new List<Animal>();
        await using (var conn = new MySqlConnection(builder.ConnectionString))
        {
            Console.WriteLine("Opening Conction");
            await conn.OpenAsync();

            
            await using (var command = conn.CreateCommand())
            {
                command.CommandText = sqlCommand;
                
                
                // exicute statment in database 
                await using (var reander = await command.ExecuteReaderAsync())
                {
                    
                    while (await reander.ReadAsync())
                    {
                        var currentAnimal = new Animal(reander.GetInt32(0),reander.GetString(1),reander.GetString(2),reander.GetInt32(3));
                        
                        animals.Add(currentAnimal);
                        
                    }
                }
            }
        }

        return animals;
    }
    
    
    
    
    
    
    
}