using Flunt.Validations;

namespace MyCheddarsPal.Validators;

public class ExerciseValidator : Contract<TrainingExerciseRequest>
{
    public ExerciseValidator(TrainingExerciseRequest request)
    {
        Requires()
            .IsGreaterThan(request.Reps, 0, "Reps", "Reps deve ser maior que 0")
            .IsGreaterThan(request.Sets, 0, "Sets", "Sets deve ser maior que 0");
    }
}