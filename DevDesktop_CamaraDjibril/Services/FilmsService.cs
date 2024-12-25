using System.Diagnostics;

namespace DevDesktop_CamaraDjibril.Services;

public class FilmsService
{
    public static async Task<string> GetPopularFilmsAsync()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://api.themoviedb.org/3/movie/popular?language=fr-FR&page=1"),
            Headers =
            {
                { "accept", "application/json" },
                { "Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIxMDE5MzYxMzdkOTA1MjgzOThiMDU4M2UwMDQwYmMwZSIsIm5iZiI6MTczMTYxODQ0MS4zOTEzMTIsInN1YiI6IjY3MWI0ZjUwYzc4MDJjYzUwMzU5Zjg3ZSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.YbLf7GEyJcxIyXSebFrjmDjwxygbGBrCvdHQTUER4tI" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return body;
        }
    }

    public static async Task<string> GetFilmByIdAsync(int id)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(string.Format("https://api.themoviedb.org/3/movie/{0}?language=fr-FR", id)),
            Headers =
            {
                { "accept", "application/json" },
                { "Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIxMDE5MzYxMzdkOTA1MjgzOThiMDU4M2UwMDQwYmMwZSIsIm5iZiI6MTczMTYxODQ0MS4zOTEzMTIsInN1YiI6IjY3MWI0ZjUwYzc4MDJjYzUwMzU5Zjg3ZSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.YbLf7GEyJcxIyXSebFrjmDjwxygbGBrCvdHQTUER4tI" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return body;
        }
    }

    public static async Task<string> GetUpcomingFilms()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://api.themoviedb.org/3/movie/upcoming?language=fr-FR"),
            Headers =
            {
                { "accept", "application/json" },
                { "Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIxMDE5MzYxMzdkOTA1MjgzOThiMDU4M2UwMDQwYmMwZSIsIm5iZiI6MTczMTYxODQ0MS4zOTEzMTIsInN1YiI6IjY3MWI0ZjUwYzc4MDJjYzUwMzU5Zjg3ZSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.YbLf7GEyJcxIyXSebFrjmDjwxygbGBrCvdHQTUER4tI" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return body;
        }
    }

    public static async Task<string> GetSearchFilms(string query)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(string.Format("https://api.themoviedb.org/3/search/movie?query={0}", query)),
            Headers =
            {
                { "accept", "application/json" },
                { "Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIxMDE5MzYxMzdkOTA1MjgzOThiMDU4M2UwMDQwYmMwZSIsIm5iZiI6MTczMTYxODQ0MS4zOTEzMTIsInN1YiI6IjY3MWI0ZjUwYzc4MDJjYzUwMzU5Zjg3ZSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.YbLf7GEyJcxIyXSebFrjmDjwxygbGBrCvdHQTUER4tI" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return body;
        }
    }

    public static async Task<string> GetGenresFilms()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://api.themoviedb.org/3/genre/movie/list?language=en"),
            Headers =
            {
                { "accept", "application/json" },
                { "Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIxMDE5MzYxMzdkOTA1MjgzOThiMDU4M2UwMDQwYmMwZSIsIm5iZiI6MTczMTYxODQ0MS4zOTEzMTIsInN1YiI6IjY3MWI0ZjUwYzc4MDJjYzUwMzU5Zjg3ZSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.YbLf7GEyJcxIyXSebFrjmDjwxygbGBrCvdHQTUER4tI" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return body;
        }
    }

    public static async Task<string> GetFilmsByGenre(string genre)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
        Method = HttpMethod.Get,
        RequestUri = new Uri(string.Format("https://api.themoviedb.org/3/discover/movie?language=en-US&page=500&with_genres={0}", genre)),
        Headers =
        {
            { "accept", "application/json" },
            { "Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIxMDE5MzYxMzdkOTA1MjgzOThiMDU4M2UwMDQwYmMwZSIsIm5iZiI6MTcyOTg0MzAyNC4yNTcsInN1YiI6IjY3MWI0ZjUwYzc4MDJjYzUwMzU5Zjg3ZSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.2bztP_EYefFn3DHu6OeVITtKap2E9uIKnFQ7L-db9Xg" },
        },
        };
        Debug.WriteLine(request.RequestUri);
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return body;
        }
    }
}