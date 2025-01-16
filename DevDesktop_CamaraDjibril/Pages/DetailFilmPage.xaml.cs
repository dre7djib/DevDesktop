using DevDesktop_CamaraDjibril.ViewModels;
using System.Diagnostics;
using FilmDataRepository;

namespace DevDesktop_CamaraDjibril.Pages
{
public partial class DetailFilmPage : ContentPage
{
    public DetailFilmPage(FilmById film)
    {
        InitializeComponent();
        BindingContext = new DetailFilmPageViewModel(film);
    }
}

}