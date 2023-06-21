namespace PappionMobile.View;

public partial class EditProfile : ContentPage
{
	public EditProfile()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		App.Current.MainPage = new MainPage();
    }
}