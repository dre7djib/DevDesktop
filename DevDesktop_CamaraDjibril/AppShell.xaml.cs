namespace DevDesktop_CamaraDjibril;

using System.Diagnostics;
using Data;
using DevDesktop_CamaraDjibril.Services;
using Newtonsoft.Json.Linq;

public partial class AppShell : Shell
{
	public AppShell()
	{
		var dbCon = DBConnection.Instance();
		dbCon.Server = "localhost";
		dbCon.Port = "8889";
		dbCon.DatabaseName = "dev_desktop";
		dbCon.UserName = "root";
		dbCon.Password = "root";

		dbCon.IsConnect();
		Debug.WriteLine("Connection opened");

		InitializeComponent();

 		string response_json = "";

/* 		var ratingsService = new RatingsService();
		string rating = ratingsService.SetRating(1, 1, 5, ref response_json, dbCon);
		Debug.WriteLine(rating);
		string getRating = ratingsService.GetRating(1, ref response_json, dbCon);
		Debug.WriteLine(getRating);
 */
/* 		var watchedService = new WatchedService();
		string filmsWatched = watchedService.SetWatched(1, 1, 1, DateTime.Parse("2021-10-10"), ref response_json, dbCon);
		string filmsWatched2 = watchedService.SetWatched(1, 2, 1, DateTime.Parse("2021-10-10"), ref response_json, dbCon);
		string allFilmsWatched = watchedService.GetAllWatched(ref response_json, dbCon);
		Debug.WriteLine(allFilmsWatched);
		string filmWatched = watchedService.GetWatched("1", ref response_json, dbCon);
		Debug.WriteLine(filmWatched); */

/* 		var ratingsService = new RatingsService();
		string rating = ratingsService.SetRating(1, 1, 5, ref response_json, dbCon); */

/* 		Task.Run(async () => {
			string films = await FilmsService.GetPopularFilmsAsync();
			string film = await FilmsService.GetFilmByIdAsync(550);
			string upcomingFilms = await FilmsService.GetUpcomingFilms();
			string search = await FilmsService.GetSearchFilms("batman");
			string genre = await FilmsService.GetGenresFilms();
			string genreFilm = await FilmsService.GetFilmsByGenre("35");

			JObject json = JObject.Parse(genreFilm);
			Debug.WriteLine(json);
		}).Wait(); */
	
	}
}

