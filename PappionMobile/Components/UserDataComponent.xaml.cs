using PappionMobile.Endpoints.PappionBackend;
using PappionMobile.Models.User;
using System.Collections.ObjectModel;

namespace PappionMobile.Components;

public partial class UserDataComponent : ContentView
{
    public ObservableCollection<UserModel> Users { get; set; } = new ObservableCollection<UserModel>();
    private UserEndpoint userEndpoint;
    public UserDataComponent()
    {
        InitializeComponent();
        //������ ������ � .xaml
        this.BindingContext = this;

        //������ ������
        //GetUserModels();
    }


 
}
