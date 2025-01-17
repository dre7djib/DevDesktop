using DevDesktop_CamaraDjibril.ViewModels;

namespace DevDesktop_CamaraDjibril.Pages 
{
    public partial class SearchFilmPage : ContentPage
    {
        public SearchFilmPage()
        {
            InitializeComponent();
            BindingContext = new SearchFilmPageViewModel();
        }
    }
}   