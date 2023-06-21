using PappionMobile.Components;

namespace PappionMobile.View;

public partial class SignUpView : ContentPage
{
	int step = 0;
	public SignUpView()
	{
		step= 0;
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		switch (step)
		{
            case 0:
                ConView.Content = null;
                UserDataComponent userData = new UserDataComponent();
                ConView.Content = userData;
                step++;
				break;
            case 1:
				ConView.Content = null;
				ImageAboutComponent imageAbout = new ImageAboutComponent();
				ConView.Content = imageAbout;
				step++;
				break;
			case 2:
				ConView.Content = null;
				NewServiceComponent newServiceComponent = new NewServiceComponent();
				ConView.Content = newServiceComponent;
				step++;
				break;
			case 3:
				App.Current.MainPage = new EditProfile();
				step++;
				break;

		}
	}
}