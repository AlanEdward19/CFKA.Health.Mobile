using MyCheddarsPal.Enums;
using MyCheddarsPal.Interfaces;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MyCheddarsPal.ViewModels;

public partial class TrainViewModel : BaseViewModel
{
    private readonly ITrainingExerciseRepository _trainingExerciseRepository;

    public TrainViewModel(ITrainingExerciseRepository trainingExerciseRepository)
    {
        _trainingExerciseRepository = trainingExerciseRepository;
    }

    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty] ObservableCollection<TTrainResponse> trainings;

    private IEnumerable<TTrainResponse> _apiTraining;

    [ObservableProperty] ObservableCollection<string> muscles = new(Enum.GetNames(typeof(EMuscle)));
    [ObservableProperty] string selectedMuscle;

    [RelayCommand]
    private async Task OnRefreshing()
    {
        IsRefreshing = true;

        try
        {
            await LoadDataAsync();
        }
        finally
        {
            IsRefreshing = false;
        }
    }

    public async Task LoadDataAsync()
    {
        Muscles.Insert(0, "-");
        Muscles = new(Muscles.Distinct());
        _apiTraining = await _trainingExerciseRepository.GetAsync(ELanguage.English);

        Trainings = new ObservableCollection<TTrainResponse>(_apiTraining);
    }

    public void FilterTraining()
    {
        Trainings = SelectedMuscle.Equals("-")
            ? new(_apiTraining)
            : new ObservableCollection<TTrainResponse>(_apiTraining.Where(x => x.Name.Contains(SelectedMuscle)));
    }

    [RelayCommand]
    private async Task GoToDetails(TTrainResponse train)
    {
        await Shell.Current.GoToAsync(nameof(TrainDetailPage), true, new Dictionary<string, object>
        {
            { "Train", train }
        });
    }

    [RelayCommand]
    private async Task GoToAddTrain()
    {
        await Shell.Current.GoToAsync(nameof(AddTrainPage), true);
    }

    [RelayCommand]
    private async Task GoToUpdateTrain(TTrainResponse training)
    {
        await Shell.Current.GoToAsync(nameof(UpdateTrainPage), true, new Dictionary<string, object>
        {
            {"Training", training}
        });
    }

    [RelayCommand]
    private async Task DeleteTrain(TTrainResponse training)
    {
        bool answer = await Shell.Current.DisplayAlert("Atenção", $"Deseja mesmo excluir esse treino?", "Sim", "Não");

        if (answer)
        {
            var response = await _trainingExerciseRepository.DeleteAsync(training.OwnerId.ToString(), training.Id);

            if (response)
            {
                await Shell.Current.DisplayAlert("Sucesso", "Treino foi deletado com sucesso", "OK");

                await OnRefreshing();
            }
        }
    }
}
