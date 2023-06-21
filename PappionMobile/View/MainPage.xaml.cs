namespace PappionMobile.View;
using PappionMobile.Endpoints.Services;
using PappionMobile.Models.Post;
using System.Collections.ObjectModel;

public partial class MainPage : ContentPage
{
    private string myVariable = "Hello, Maui!";
    public string MyVariable
    {
        get { return myVariable; }
        set { myVariable = value; }
    }
    public MainPage()
	{
		InitializeComponent();
    }
}