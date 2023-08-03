using Microsoft.VisualBasic;
using MySqlConnector;

namespace ZooAPI.controller;

public class DBConnection
{
    public static async Task NewSqlCommand(String sqlCommand)
    {
        var builder = new MySqlConnectionStringBuilder
        {
            Server = "localhost",
            Database = "Zoo",
            UserID = "root",
            Password = "admin",
            SslMode = MySqlSslMode.Disabled
        };

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
                        Console.WriteLine($"Reading from table= ({reander.GetInt32(0)},{reander.GetString(1)})");
                    }
                }
            }
            
            
            Console.WriteLine("closing Connection");
        }
        
    }

    private static async Task GetTiere(MySqlConnection conn)
    {
        
        await using (var command = conn.CreateCommand())
        {
            command.CommandText = "select * from tiere;";

            // exicute statment in database 
            await using (var reander = await command.ExecuteReaderAsync())
            {
                while (await reander.ReadAsync())
                {
                    Console.WriteLine($"Reading from table= ({reander.GetInt32(0)},{reander.GetString(1)})");
                }
            }
        }
    }
}