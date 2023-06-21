using PappionMobile.View;

namespace PappionMobile.Components;

public partial class AuthorizationComponent : ContentView
{
	public AuthorizationComponent()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		SignUpView signUp = new SignUpView();
		App.Current.MainPage = signUp;
    }
}