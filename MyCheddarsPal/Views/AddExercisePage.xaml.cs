using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCheddarsPal.Views;

public partial class AddExercisePage : ContentPage
{
    private AddExerciseViewModel ViewModel;
    public AddExercisePage(AddExerciseViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        BindingContext = ViewModel;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        await ViewModel.LoadDataAsync();
    }

    private void Picker_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        ViewModel.FilterExercises();
    }
}