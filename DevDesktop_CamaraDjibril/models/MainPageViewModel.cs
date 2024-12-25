using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Diagnostics;
using DevDesktop_CamaraDjibril.Repositories;

namespace DevDesktop_CamaraDjibril
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Film> PopularFilms { get; set; }

        public MainPageViewModel()
        {
            PopularFilms = new ObservableCollection<Film>();
            LoadPopularFilms();
        }

        private async void LoadPopularFilms()
        {
            var filmsJson = await Services.FilmsService.GetPopularFilmsAsync();
            var films = JsonSerializer.Deserialize<FilmResponse>(filmsJson);
            foreach (var film in films.results)
            {
                film.poster_path = "https://image.tmdb.org/t/p/w185" + film.poster_path;
                PopularFilms.Add(film);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}