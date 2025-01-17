using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Collections.ObjectModel;
using FilmDataRepository;
using System.Text.Json;
using DevDesktop_CamaraDjibril.Repositories;
using DevDesktop_CamaraDjibril.Pages;

namespace DevDesktop_CamaraDjibril.ViewModels
{
    public class SearchFilmPageViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<Film> SearchFilms { get; set; }
        public String query { get; set; }
        public Command<Film> NavigateToDetailsFilms { get; }
        public Command SearchCommand { get; }

        public SearchFilmPageViewModel()
        {
            SearchFilms = new ObservableCollection<Film>();
            SearchCommand = new Command(GetSearchFilms);

            NavigateToDetailsFilms = new Command<Film>(film =>
            {
                FilmById filmById = Mapper.FilmByIdMapper.Map(film);
                Application.Current.MainPage.Navigation.PushAsync(new DetailFilmPage(filmById));
            });
        }

        private async void GetSearchFilms()
        {
            var filmsJson = await Services.FilmsService.GetSearchFilms(query);
            var films = JsonSerializer.Deserialize<FilmResponse>(filmsJson);
            SearchFilms.Clear();
            foreach (var film in films.results)
            {
                film.poster_path = "https://image.tmdb.org/t/p/w500" + film.poster_path;
                if (film.poster_path == "https://image.tmdb.org/t/p/w500null")
                {
                    film.poster_path = "https://image.tmdb.org/t/p/w500" + film.backdrop_path;
                }
                Debug.WriteLine(film.title);
                SearchFilms.Add(film);
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}