using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFKA.Health.Mobile.Pages;
using CFKA.Health.Mobile.ViewModel;

namespace CFKA.Health.Mobile;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void btMainTrainPage_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainTrainPage());
    }
}