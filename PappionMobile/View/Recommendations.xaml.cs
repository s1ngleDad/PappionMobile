namespace PappionMobile.View;

public partial class Recommendations : ContentPage
{
	public Recommendations()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
	{
        App.Current.MainPage = new MainPage();
    }
}