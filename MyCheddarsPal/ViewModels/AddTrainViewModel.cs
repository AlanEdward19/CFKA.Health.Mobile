using MyCheddarsPal.Helpers;
using MyCheddarsPal.Interfaces;

namespace MyCheddarsPal.ViewModels;

[QueryProperty(nameof(SavedExercises), "SavedExercises")]
public partial class AddTrainViewModel : BaseViewModel
{
    private readonly ITrainingExerciseRepository _trainingExerciseRepository;

    public AddTrainViewModel(ITrainingExerciseRepository trainingExerciseRepository)
    {
        _trainingExerciseRepository = trainingExerciseRepository;
    }

    [ObservableProperty] ObservableCollection<TrainingExerciseRequest> savedExercises = new();
    [ObservableProperty] TrainingExerciseRequest selectedExercise;
    [ObservableProperty] DateTime selectedDate;

    [RelayCommand]
    private async Task GoToAddExercise()
    {
        await Shell.Current.GoToAsync(nameof(AddExercisePage), true, new Dictionary<string, object>
        {
            { "SavedExercises", SavedExercises }
        });
    }

    [RelayCommand]
    private async Task RemoveExercise()
    {
        if (selectedExercise == null)
        {
            await Shell.Current.DisplayAlert("Atenção", "Nenhum exercicio foi selecionado, impossivel prosseguir com deleção", "OK");
            return;
        }

        bool answer = await Shell.Current.DisplayAlert("Atenção", $"Deseja mesmo excluir esse exercicio?", "Sim", "Não");

        if (answer)
        {
            SavedExercises.Remove(SelectedExercise);
        }
    }

    [RelayCommand]
    private async Task SaveTrain()
    {
        var request = new InsertTrainingRequest()
        {
            ChangeDate = SelectedDate,
            TrainingExercises = SavedExercises
        };

        bool sucess = await _trainingExerciseRepository.AddAsync(request, await SessionHelper.GetTokenAsync());

        if (sucess)
        {
            await Shell.Current.DisplayAlert("Sucesso", "Treino foi inserido com sucesso", "OK");

            await Shell.Current.GoToAsync("..");
            return;
        }

        await Shell.Current.DisplayAlert("Atenção", "Houve um erro ao tentar inserir treino, tente novamente!", "OK");
    }
}