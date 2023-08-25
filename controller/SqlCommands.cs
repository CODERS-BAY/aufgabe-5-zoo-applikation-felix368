using MySqlConnector;
using ZooAPI.model;

namespace ZooAPI.controller;

public class SqlCommands
{

    
    
    public static async Task NewSqlInsertCommand(String sqlCommand)
    {
        
                var command =await DBConnection.GetConnection();
                command.CommandText = sqlCommand;

                // exicute statment in database 
                await using var reander = await command.ExecuteReaderAsync();
    }

    
    
    
    public static async Task<List<Ticket>> GetSoldTicketsByDate(String sqlCommand)
    {
        List<Ticket> tickets = new();

        var command = await DBConnection.GetConnection();
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
            
        

        return tickets;
    }
    
    
   
    
    public static async Task<List<Animal>> GetTiere(String sqlCommand)
    {
        List<Animal> animals = new();

        var command = await DBConnection.GetConnection();
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

        return animals;
    }
    
    
    
}