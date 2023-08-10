namespace ZooAPI.controller;
using MySqlConnector;
using ZooAPI.model;
public class DBConnection
{
    private static MySqlCommand Connection;

    private static MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
    {
        Server = "localhost",
        Database = "Zoo",
        UserID = "root",
        Password = "admin",
        SslMode = MySqlSslMode.Disabled
    };
        
        
    private static async Task< MySqlCommand> NewSqlInsertCommand()
    {
        var conn1 = new MySqlConnection(builder.ConnectionString);
        await conn1.OpenAsync();
        return conn1.CreateCommand();
        
        
    }

    async static Task<MySqlCommand> getConnection()
    {
        if (Connection == null)
        {
            Connection = await DBConnection.NewSqlInsertCommand();
        }

        return Connection;

    }

}