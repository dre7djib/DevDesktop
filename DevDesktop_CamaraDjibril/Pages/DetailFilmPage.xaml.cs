namespace DevDesktop_CamaraDjibril.Pages
{
public partial class DetailFilmPage : ContentPage
{
    public DetailFilmPage(object film)
    {
        InitializeComponent();
        BindingContext = film;
    }
}

}