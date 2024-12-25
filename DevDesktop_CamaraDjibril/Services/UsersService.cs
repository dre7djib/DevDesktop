namespace DevDesktop_CamaraDjibril.Services;

using DevDesktop_CamaraDjibril.Repositories;
using System.Text.Json;
using MySql.Data.MySqlClient;
using Data;

public class UsersService {
    
    // Récupération d'un User
    public string GetUser(string id, ref string response_json, DBConnection db)
    {
        try
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM ta_users WHERE idUser = @id", db.Connection);
            command.Parameters.AddWithValue("@id", id);
        
            UserRepository user = new UserRepository();
            List<UserRepository> users = new List<UserRepository>();
        
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
            
                user.idUser = reader.GetInt32(0);
                user.email = reader.GetString(1);
                user.password = reader.GetString(2);
                users.Add(user);
            }
        
            reader.Close();
            response_json = JsonSerializer.Serialize(users);
            return response_json;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    // Récupération de tous les Users
    public string GetAllUsers(ref string response_json, DBConnection db)
    {
        try
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM ta_users", db.Connection);
            UserRepository user = new UserRepository();
            List<UserRepository> users = new List<UserRepository>();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                user.idUser = reader.GetInt32(0);
                user.email = reader.GetString(1);
                user.password = reader.GetString(2);
                users.Add(user);
            }
            reader.Close();
            response_json = JsonSerializer.Serialize(users);
            return response_json;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    // Ajout d'un User
    public string SetUser(string email, string password, ref string response_json, DBConnection db)
    {
        try
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO ta_users (email, password) VALUES (@email, @password)", db.Connection);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);
            command.ExecuteNonQuery();
            response_json = "User created";
            return response_json;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}