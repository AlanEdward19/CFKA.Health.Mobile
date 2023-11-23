using MyCheddarsPal.Enums;
using MyCheddarsPal.Interfaces;
using System.Text;
using MyCheddarsPal.Validators;

namespace MyCheddarsPal.ViewModels;

[QueryProperty(nameof(SavedExercises), "SavedExercises")]
[QueryProperty(nameof(Training), "Training")]
[QueryProperty(nameof(_apiExercises), "_apiExercises")]
public partial class UpdateExerciseViewModel : BaseViewModel
{
    private readonly IExerciseRepository _exerciseRepository;
    private IEnumerable<ExerciseResponse> _apiExercises;

    public UpdateExerciseViewModel(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    [ObservableProperty]
    bool isRefreshing;
    [ObservableProperty] ObservableCollection<TrainingExerciseRequest> savedExercises;
    [ObservableProperty] TTrainResponse training;

    [ObservableProperty] ObservableCollection<ExerciseResponse> exercises;
    [ObservableProperty] ObservableCollection<string> muscles = new(Enum.GetNames(typeof(EMuscle)));
    [ObservableProperty] string selectedMuscle;
    [ObservableProperty] ExerciseResponse selectedExercise;
    [ObservableProperty] string observations = "";
    [ObservableProperty] string reps;
    [ObservableProperty] string sets;

    public async Task LoadDataAsync()
    {
        Muscles.Insert(0, "-");
        _apiExercises = await _exerciseRepository.GetAsync();

        Exercises = new ObservableCollection<ExerciseResponse>(_apiExercises);
        SelectedExercise ??= Exercises.First();
    }
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

    [RelayCommand]
    private async Task SaveExercise()
    {
        Reps ??= "0";
        Sets ??= "0";

        var exercise = new TrainingExerciseRequest()
        {
            ExerciseId = SelectedExercise.Id,
            ExerciseName = SelectedExercise.EnName,
            Observations = Observations,
            Reps = int.Parse(Reps),
            Sets = int.Parse(Sets)
        };

        var contract = new ExerciseValidator(exercise);

        if (!contract.IsValid)
        {
            var messages = contract.Notifications.Select(x => x.Message);
            var sb = new StringBuilder();

            foreach (var message in messages)
                sb.Append($"{message}\n");

            await Shell.Current.DisplayAlert("Atenção", sb.ToString(), "OK");
            return;
        }

        SavedExercises.Add(exercise);

        await Shell.Current.GoToAsync("..", true, new Dictionary<string, object>
        {
            { "SavedExercises", SavedExercises },
            { "Training", Training },
            {"_apiExercises", _apiExercises}
        });
    }

    public void FilterExercises()
    {
        Exercises = selectedMuscle.Equals("-")
            ? new(_apiExercises)
            : new ObservableCollection<ExerciseResponse>(_apiExercises.Where(x =>
                x.Muscle.MainMuscle.Equals((int) Enum.Parse<EMuscle>(selectedMuscle))));
    }
}