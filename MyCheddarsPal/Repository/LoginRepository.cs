using Flurl;
using Flurl.Http;
using MyCheddarsPal.Helpers;
using MyCheddarsPal.Interfaces;

namespace MyCheddarsPal.Repository;

public class LoginRepository : ILoginRepository
{
    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        try
        {
            var response = await Constants.ApiUrl
                .AppendPathSegment("/login")
                .PutJsonAsync(request);

            if (response.ResponseMessage.IsSuccessStatusCode)
            {
                var content = await response.ResponseMessage.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<LoginResponse>(content);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return new LoginResponse();
    }
}