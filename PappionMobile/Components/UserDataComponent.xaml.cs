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
        //звязка змінних з .xaml
        this.BindingContext = this;
    }
    private async Task RegisterAsync()
    {
        RegisterModel registerModel = new RegisterModel();
        registerModel.firstName = FirstName.Text;
        registerModel.lastName = LastName.Text;
        registerModel.email = Gmail.Text;
        registerModel.phoneNumber = FirstPhoneNumber.Text;
        registerModel.phoneNumber2 = SecondPhoneNumber.Text;
        registerModel.password = Password.Text;
        registerModel.passwordConfirmation = ConfirmPassword.Text;

        await userEndpoint.RegisterAsync(registerModel);
    }



}
