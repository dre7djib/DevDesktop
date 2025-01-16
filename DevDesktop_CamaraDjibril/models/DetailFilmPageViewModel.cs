
using FilmDataRepository;
using Data;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using DevDesktop_CamaraDjibril.Services;
namespace DevDesktop_CamaraDjibril.ViewModels
{
    public class DetailFilmPageViewModel : INotifyPropertyChanged
    {
        public FilmById Film { get; set; }
        public Command<FilmById> AddWatchedFilm { get;set;}
        public Command AddWatchedFilmWithoutParam { get; }

        private string _posterPath;
        public string poster_path
        {
            get => _posterPath;
            set
            {
                _posterPath = value;
                OnPropertyChanged();
            }
        }

        private string _title;
        public string title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private string _overview;
        public string Overview
        {
            get => _overview;
            set
            {
                _overview = value;
                OnPropertyChanged();
            }
        }

        private string _releaseDate;
        public string release_date
        {
            get => _releaseDate;
            set
            {
                _releaseDate = value;
                OnPropertyChanged();
            }
        }

        private string _popularity;
        public string popularity
        {
            get => _popularity;
            set
            {
                _popularity = value;
                OnPropertyChanged();
            }
        }

        public DetailFilmPageViewModel(FilmById film)
        {
            Film = film;

            AddWatchedFilm = new Command<FilmById>(filmParam =>
            {
                if (filmParam == null)
                {
                    Debug.WriteLine("Le film est null !");
                    return;
                }

                Debug.WriteLine($"Film reçu : {filmParam.id}");
                var dbCon = DBConnection.Instance();
                var watchedService = new WatchedService();
                var date = DateTime.Now;
                string response_json = "";
                string filmsWatched = watchedService.SetWatched(1, filmParam.id, 1, date, ref response_json, dbCon);
                Debug.WriteLine(filmsWatched);
            });

            AddWatchedFilmWithoutParam = new Command(() =>
            {
                Debug.WriteLine("La commande sans paramètre a été exécutée.");
            });
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}