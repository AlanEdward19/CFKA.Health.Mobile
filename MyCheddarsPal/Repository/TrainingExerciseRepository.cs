using Flurl;
using Flurl.Http;
using MyCheddarsPal.Enums;
using MyCheddarsPal.Helpers;
using MyCheddarsPal.Interfaces;

namespace MyCheddarsPal.Repository;

public class TrainingExerciseRepository : ITrainingExerciseRepository
{
    public async Task<IEnumerable<TTrainResponse>> GetAsync(ELanguage language)
    {
        try
        {
            return await Constants.ApiUrl.AppendPathSegment("/Training").SetQueryParam("language", (int) language)
                .WithHeader("api-key", await SessionHelper.GetTokenAsync())
                .GetJsonAsync<IEnumerable<TTrainResponse>>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Enumerable.Empty<TTrainResponse>();
    }

    public async Task<bool> AddAsync(InsertTrainingRequest request, string ownerId)
    {
        var response = await Constants.ApiUrl.AppendPathSegment("/Training").SetQueryParam("ownerId", ownerId.ToUpper())
            .WithHeader("api-key", await SessionHelper.GetTokenAsync()).PostJsonAsync(request);

        return response.ResponseMessage.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAsync(InsertTrainingRequest request, string ownerId, int id)
    {
        var response = await Constants.ApiUrl.AppendPathSegment("/Training").SetQueryParam("ownerId", ownerId.ToUpper())
            .SetQueryParam("id", id).WithHeader("api-key", await SessionHelper.GetTokenAsync()).PutJsonAsync(request);

        return response.ResponseMessage.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(string ownerId, int id)
    {
        var response = await Constants.ApiUrl.AppendPathSegment("/Training").SetQueryParam("ownerId", ownerId.ToUpper())
            .SetQueryParam("id", id).WithHeader("api-key", await SessionHelper.GetTokenAsync()).DeleteAsync();

        return response.ResponseMessage.IsSuccessStatusCode;
    }

    public async Task<bool> GetClientTrainingAsync(string clientId, ELanguage language)
    {
        throw new NotImplementedException();
    }
}