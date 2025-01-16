using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Diagnostics;
using Data;
using DevDesktop_CamaraDjibril.Pages;
using DevDesktop_CamaraDjibril.Repositories;
using DevDesktop_CamaraDjibril.Services;
using FilmDataRepository;

namespace DevDesktop_CamaraDjibril
{

    public class WatchedFilmsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<FilmById> WatchedFilms { get; set; }
        public Command<FilmById> NavigateToDetailsFilms { get; }


        public WatchedFilmsViewModel()
        {
            WatchedFilms = new ObservableCollection<FilmById>();
            LoadWatchedFilms();

            NavigateToDetailsFilms = new Command<FilmById>(film =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new DetailFilmPage(film));
            });
        }


    public void LoadWatchedFilms(){
        WatchedFilms = new ObservableCollection<FilmById>();
        var dbCon = DBConnection.Instance();
        var watchedService = new WatchedService();
        string response_json = "";
        string allFilmsWatched = watchedService.GetAllWatched(ref response_json, dbCon); 
        var filmService = new FilmsService();
        var watchedFilms = JsonSerializer.Deserialize<ObservableCollection<WatchedRepository>>(allFilmsWatched);
        foreach (var watchedFilm in watchedFilms)
        {
           Task.Run(async () => {
			string filmsJson = await FilmsService.GetFilmByIdAsync(watchedFilm.idFilm);
            var film = JsonSerializer.Deserialize<FilmById>(filmsJson);
            film.poster_path = "https://image.tmdb.org/t/p/w500" + film.poster_path;
            if (film.poster_path == "https://image.tmdb.org/t/p/w500null")
            {
                film.poster_path = "https://image.tmdb.org/t/p/w500" + film.backdrop_path;
            }
            Debug.WriteLine(film.title);
            WatchedFilms.Add(film);
		}).Wait();
        }
    }

                
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}