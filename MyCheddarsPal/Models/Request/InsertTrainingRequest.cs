namespace MyCheddarsPal.Models;

public class InsertTrainingRequest
{
    public DateTime ChangeDate { get; set; }
    public IEnumerable<TrainingExerciseRequest> TrainingExercises { get; set; }
}