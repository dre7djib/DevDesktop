using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using DevDesktop_CamaraDjibril.Repositories;
using DevDesktop_CamaraDjibril.Pages;

namespace DevDesktop_CamaraDjibril
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Film> PopularFilms { get; set; }
        public ObservableCollection<Film> UpcomingFilms { get; set; }
        public ObservableCollection<Film> TopRatedFilms { get; set; }
        public Command<Film> NavigateToDetailsCommand { get; }

        public MainPageViewModel()
        {
            PopularFilms = new ObservableCollection<Film>();
            LoadPopularFilms();
            UpcomingFilms = new ObservableCollection<Film>();
            LoadUpcomingFilms();
            TopRatedFilms = new ObservableCollection<Film>();
            LoadTopRatedFilms();

            NavigateToDetailsCommand = new Command<Film>(film =>
            {
                Application.Current.MainPage.Navigation.PushAsync(new DetailFilmPage(film));
            });
        }

        private async void LoadPopularFilms()
        {
            var filmsJson = await Services.FilmsService.GetPopularFilmsAsync();
            var films = JsonSerializer.Deserialize<FilmResponse>(filmsJson);
            foreach (var film in films.results)
            {
                film.poster_path = "https://image.tmdb.org/t/p/w185" + film.poster_path;
                if (film.poster_path == "https://image.tmdb.org/t/p/w185null")
                {
                    film.poster_path = "https://image.tmdb.org/t/p/w185" + film.backdrop_path;
                }
                PopularFilms.Add(film);
            }
        }
        private async void LoadUpcomingFilms()
        {
            var filmsJson = await Services.FilmsService.GetUpcomingFilms();
            var films = JsonSerializer.Deserialize<FilmResponse>(filmsJson);
            foreach (var film in films.results)
            {
                film.poster_path = "https://image.tmdb.org/t/p/w185" + film.poster_path;
                if (film.poster_path == "https://image.tmdb.org/t/p/w185null")
                {
                    film.poster_path = "https://image.tmdb.org/t/p/w185" + film.backdrop_path;
                }
                UpcomingFilms.Add(film);
            }
        }

        private async void LoadTopRatedFilms()
        {
            var filmsJson = await Services.FilmsService.GetTopRatedFilms();
            var films = JsonSerializer.Deserialize<FilmResponse>(filmsJson);
            foreach (var film in films.results)
            {
                film.poster_path = "https://image.tmdb.org/t/p/w185" + film.poster_path;
                if (film.poster_path == "https://image.tmdb.org/t/p/w185null")
                {
                    film.poster_path = "https://image.tmdb.org/t/p/w185" + film.backdrop_path;
                }
                TopRatedFilms.Add(film);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}