namespace MyCheddarsPal.Interfaces;

public interface ILoginRepository
{
    Task<LoginResponse> LoginAsync(LoginRequest request);
}