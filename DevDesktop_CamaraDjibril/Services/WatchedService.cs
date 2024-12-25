namespace DevDesktop_CamaraDjibril.Services;

using MySql.Data.MySqlClient;
using System.Text.Json;
using Data;
using DevDesktop_CamaraDjibril.Repositories;

public class WatchedService()
{
    // Récupération des films Watched
    public string GetWatched(string id, ref string response_json, DBConnection db)
    {
        try
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM ta_watched WHERE idWatched = @id", db.Connection);
            command.Parameters.AddWithValue("@id", id);
        
            WatchedRepository watched = new WatchedRepository();
            List<WatchedRepository> watcheds = new List<WatchedRepository>();
        
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
            
                watched.idWatched = reader.GetInt32(0);
                watched.idUser = reader.GetInt32(1);
                watched.idFilm = reader.GetInt32(2);
                watched.idRating = reader.GetInt32(3);
                watched.Date = reader.GetDateTime(4);
                watcheds.Add(watched);
            }
        
            reader.Close();
            response_json = JsonSerializer.Serialize(watcheds);
            return response_json;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    // R@cupération de tous les films Watched
    public string GetAllWatched(ref string response_json, DBConnection db)
    {
        try
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM ta_watched", db.Connection);
            WatchedRepository watched = new WatchedRepository();
            List<WatchedRepository> watcheds = new List<WatchedRepository>();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                watched.idWatched = reader.GetInt32(0);
                watched.idUser = reader.GetInt32(1);
                watched.idFilm = reader.GetInt32(2);
                watched.idRating = reader.GetInt32(3);
                watched.Date = reader.GetDateTime(4);
                watcheds.Add(watched);
            }
            reader.Close();
            response_json = JsonSerializer.Serialize(watcheds);
            return response_json;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    // Ajout d'un film Watched
    public string SetWatched(int idUser, int idFilm, int idRating, DateTime Date, ref string response_json, DBConnection db)
    {
        try
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO ta_watched (idUser, idFilm, idRating, Date) VALUES (@idUser, @idFilm, @idRating, @Date)", db.Connection);
            command.Parameters.AddWithValue("@idUser", idUser);
            command.Parameters.AddWithValue("@idFilm", idFilm);
            command.Parameters.AddWithValue("@idRating", idRating);
            command.Parameters.AddWithValue("@Date", Date);
            command.ExecuteNonQuery();
            response_json = "{\"message\":\"Film ajouté\"}";
            return response_json;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}