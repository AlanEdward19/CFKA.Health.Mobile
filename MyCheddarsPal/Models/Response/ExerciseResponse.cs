namespace MyCheddarsPal.Models;

public class ExerciseResponse
{
    public int Id { get; set; }
    public string EnName { get; set; }
    public string PtName { get; set; }
    public int MuscleId { get; set; }
    public MuscleResponse Muscle { get; set; }
}