using PappionMobile.View;
namespace PappionMobile;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new StartPage();
	}
}
