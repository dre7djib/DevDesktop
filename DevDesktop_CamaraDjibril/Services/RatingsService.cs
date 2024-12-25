namespace DevDesktop_CamaraDjibril.Services;

using MySql.Data.MySqlClient;
using Data;
using DevDesktop_CamaraDjibril.Repositories;
using System.Text.Json;

public class RatingsService {
    public string SetRating(int userId, int idFilm, int rating, ref string response_json, DBConnection db){
        try
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO ta_ratings (idUser, idFilm, rating) VALUES (@idUser, @idFilm, @rating)", db.Connection);
            command.Parameters.AddWithValue("@idUser", userId);
            command.Parameters.AddWithValue("@idFilm", idFilm);
            command.Parameters.AddWithValue("@rating", rating);
            command.ExecuteNonQuery();
            response_json = "Rating created";
            return response_json;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public string GetRating(int id, ref string response_json, DBConnection db){
        try
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM ta_ratings WHERE idRating = @id", db.Connection);
            command.Parameters.AddWithValue("@id", id);
            RatingsRepository rating = new RatingsRepository();
            List<RatingsRepository> ratings = new List<RatingsRepository>();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                rating.idRating = reader.GetInt32(0);
                rating.userId = reader.GetInt32(1);
                rating.idFilm = reader.GetInt32(2);
                rating.rating = reader.GetInt32(3);
                ratings.Add(rating);
            }
            reader.Close();
            response_json = JsonSerializer.Serialize(ratings);
            return response_json;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}