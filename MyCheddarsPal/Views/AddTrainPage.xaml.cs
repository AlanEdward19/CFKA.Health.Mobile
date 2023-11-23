using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCheddarsPal.Views;

public partial class AddTrainPage : ContentPage
{
    private AddTrainViewModel ViewModel;
    public AddTrainPage(AddTrainViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        BindingContext = ViewModel;
    }
}