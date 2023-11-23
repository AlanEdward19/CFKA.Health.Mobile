namespace MyCheddarsPal.Models;

public class TrainingExerciseRequest
{
    public int ExerciseId { get; set; }
    public string ExerciseName { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
    public string Observations { get; set; }
}