using MyCheddarsPal.Helpers;
using MyCheddarsPal.Interfaces;
using System.Diagnostics;

namespace MyCheddarsPal.ViewModels;

[QueryProperty(nameof(SavedExercises), "SavedExercises")]
[QueryProperty(nameof(Training), "Training")]
[QueryProperty(nameof(_apiExercises), "_apiExercises")]
public partial class UpdateTrainViewModel : BaseViewModel
{
    private readonly ITrainingExerciseRepository _trainingExerciseRepository;
    private readonly IExerciseRepository _exerciseRepository;
    private IEnumerable<ExerciseResponse> _apiExercises;

    public UpdateTrainViewModel(ITrainingExerciseRepository trainingExerciseRepository, IExerciseRepository exerciseRepository)
    {
        _trainingExerciseRepository = trainingExerciseRepository;
        _exerciseRepository = exerciseRepository;
    }

    [ObservableProperty] ObservableCollection<TrainingExerciseRequest> savedExercises = new();
    [ObservableProperty] TrainingExerciseRequest selectedExercise;
    [ObservableProperty] DateTime selectedDate;
    [ObservableProperty] TTrainResponse training;

    public async Task LoadInfoAsync()
    {
        _apiExercises ??= await _exerciseRepository.GetAsync();

        if(SavedExercises == null | !SavedExercises.Any())
            foreach (var trainingExercise in Training.TrainingExercises)
            {
                TrainingExerciseRequest teste = new()
                {
                    ExerciseId = _apiExercises.First(x =>
                        x.EnName.Equals(trainingExercise.Exercise.Name, StringComparison.CurrentCultureIgnoreCase)).Id,
                    ExerciseName = trainingExercise.Exercise.Name,
                    Observations = trainingExercise.Observations,
                    Reps = trainingExercise.Reps,
                    Sets = trainingExercise.Sets
                };

                SavedExercises.Add(teste);
            }

        SelectedDate = Training.ChangeDate;
    }

    [RelayCommand]
    private async Task GoToAddExercise()
    {
        await Shell.Current.GoToAsync(nameof(UpdateExercisePage), true, new Dictionary<string, object>
        {
            { "SavedExercises", SavedExercises },
            {"Training", Training},
            {"_apiExercises", _apiExercises}
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

        bool sucess = await _trainingExerciseRepository.UpdateAsync(request, await SessionHelper.GetTokenAsync(), Training.Id);

        if (sucess)
        {
            await Shell.Current.DisplayAlert("Sucesso", "Treino foi atualizado com sucesso", "OK");

            await Shell.Current.GoToAsync("..");
            return;
        }

        await Shell.Current.DisplayAlert("Atenção", "Houve um erro ao tentar atualizar treino, tente novamente!", "OK");
    }
}