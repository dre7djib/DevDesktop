using DevDesktop_CamaraDjibril.Repositories;
using FilmDataRepository;

namespace DevDesktop_CamaraDjibril.Mapper
{
    public class FilmByIdMapper
    {
        public static FilmById Map(Film film)
        {
            return new FilmById
            {
                adult = film.adult,
                backdrop_path = film.backdrop_path,
                id = film.id,
                original_language = film.original_language,
                original_title = film.original_title,
                overview = film.overview,
                popularity = film.popularity,
                poster_path = film.poster_path,
                release_date = film.release_date,
                title = film.title,
                video = film.video,
                vote_average = film.vote_average,
                vote_count = film.vote_count
            };
        }
    }
}