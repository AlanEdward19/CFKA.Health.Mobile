namespace MyCheddarsPal.Interfaces;

public interface IExerciseRepository
{
    Task<IEnumerable<ExerciseResponse>> GetAsync();
    Task<bool> AddAsync(InsertExerciseRequest request);
    Task<bool> UpdateAsync(InsertExerciseRequest request, int id);
    Task<bool> DeleteAsync(int id);
}