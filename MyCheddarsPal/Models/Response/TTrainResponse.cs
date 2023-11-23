namespace MyCheddarsPal.Models;

public class TTrainResponse
{
    public int Id { get; set; }
    public Guid OwnerId { get; set; }
    public string Name { get; set; }
    public DateTime ChangeDate { get; set; }
    public IEnumerable<TrainingExerciseResponse> TrainingExercises { get; set; }
}