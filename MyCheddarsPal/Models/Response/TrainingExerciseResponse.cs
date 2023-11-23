namespace MyCheddarsPal.Models;

public class TrainingExerciseResponse
{
    public TExerciseResponse Exercise { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
    public string Observations { get; set; }
}