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
        //������ ������ � .xaml
        this.BindingContext = this;

        //������ ������
        GetPostModels();
    }


    public async Task GetPostModels()
    {
        //������� ��������� ����� � ������
        postEndpoint = new PostEndpoint();

        //������ ���� ������� ��� ���� � ��
        List<PostModel> posts = await postEndpoint.GetAsync();

        //���� ����� ���� ������ ���� � ��������� Posts
        foreach (var post in posts)
        {
            Posts.Add(post);
        }
    }
}