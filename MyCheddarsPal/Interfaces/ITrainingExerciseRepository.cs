using MyCheddarsPal.Enums;

namespace MyCheddarsPal.Interfaces;

public interface ITrainingExerciseRepository
{
    Task<IEnumerable<TTrainResponse>> GetAsync(ELanguage language);
    Task<bool> AddAsync(InsertTrainingRequest request, string ownerId);
    Task<bool> UpdateAsync(InsertTrainingRequest request, string ownerId, int id);
    Task<bool> DeleteAsync(string ownerId, int id);
    Task<bool> GetClientTrainingAsync(string clientId, ELanguage language);
}