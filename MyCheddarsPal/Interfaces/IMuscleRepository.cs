namespace MyCheddarsPal.Interfaces;

public interface IMuscleRepository
{
    Task<IEnumerable<MuscleResponse>> GetAsync();
    Task<bool> AddAsync(InsertMuscleRequest request);
    Task<bool> UpdateAsync(InsertMuscleRequest request, int id);
    Task<bool> DeleteAsync(int id);
}