using PappionMobile.Endpoints.Services;
using PappionMobile.Models.Post;
using PappionMobile.View;

namespace PappionMobile.Components;

public partial class MiniProfileComponent : ContentView
{
    private string myVariable = "Hello, Maui!";
    public string MyVariable
    {
        get { return myVariable; }
        set { myVariable = value; }
    }

    public MiniProfileComponent()
	{
		InitializeComponent();
		GetPostModels();
        this.BindingContext = this;
    }
	public async Task GetPostModels() {
        PostEndpoint postEndpoint = new PostEndpoint();
        List<PostModel> posts = await postEndpoint.GetAsync();
        foreach (PostModel post in posts)
        {
            string postData = $"title: {post.Title}\n";
            //PostData.Text += postData;
        }
    }
    private void ImageButton_Clicked(object sender, EventArgs e)
    {
		App.Current.MainPage = new Recommendations();

    }
}