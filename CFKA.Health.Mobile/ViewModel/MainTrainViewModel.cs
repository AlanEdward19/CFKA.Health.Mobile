﻿using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace CFKA.Health.Mobile.ViewModel;

public partial class MainTrainViewModel : ObservableObject
{
    [ICommand]
    async Task MoveBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}