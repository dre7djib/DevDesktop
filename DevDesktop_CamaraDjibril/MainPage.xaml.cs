namespace DevDesktop_CamaraDjibril;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainPageViewModel();
	}
}

