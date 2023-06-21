using PappionMobile.View;
using PappionMobile.Endpoints.Services;
using PappionMobile.Models.Post;
using System.Collections.ObjectModel;

namespace PappionMobile.Components;

public partial class PostControl : ContentView
{
    public ObservableCollection<PostModel> Posts { get; set; } = new ObservableCollection<PostModel>();
    private PostEndpoint postEndpoint;
    public PostControl()
	{
		InitializeComponent();
        //звязка змінних з .xaml
        this.BindingContext = this;

        //виклик методу
        GetPostModels();
    }


    public async Task GetPostModels()
    {
        //створює екземпляр класу з рестапі
        postEndpoint = new PostEndpoint();

        //список який повертає цей клас з апі
        List<PostModel> posts = await postEndpoint.GetAsync();

        //додає кожну нову модель Пост в обсервабл Posts
        foreach (var post in posts)
        {
            Posts.Add(post);
        }
    }
}