namespace MyCheddarsPal.Interfaces;

public interface IUserRepository
{
    Task<UserResponse> GetAsync();
    Task<bool> AddAsync(InsertUserRequest request);
    Task<bool> UpdateAsync(InsertUserRequest request, string id);
    Task<bool> DeleteAsync(string id);
}