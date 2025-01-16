namespace DevDesktop_CamaraDjibril.Pages
{
    public partial class WatchedFilmsPage : ContentPage
    {
        public WatchedFilmsPage()
        {
            InitializeComponent();
            BindingContext = new WatchedFilmsViewModel();
        }
    }

}