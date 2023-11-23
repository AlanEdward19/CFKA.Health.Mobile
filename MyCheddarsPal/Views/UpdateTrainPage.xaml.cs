using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCheddarsPal.Views;

public partial class UpdateTrainPage : ContentPage
{
    private UpdateTrainViewModel ViewModel;
    public UpdateTrainPage(UpdateTrainViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        BindingContext = ViewModel;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        await ViewModel.LoadInfoAsync();
    }
}