using Flurl;
using Flurl.Http;
using MyCheddarsPal.Helpers;
using MyCheddarsPal.Interfaces;

namespace MyCheddarsPal.Repository;

public class ExerciseRepository : IExerciseRepository
{
    public async Task<IEnumerable<ExerciseResponse>> GetAsync()
    {
        try
        {
            return await Constants.ApiUrl.AppendPathSegment("/Exercise")
                .WithHeader("api-key", await SessionHelper.GetTokenAsync())
                .GetJsonAsync<IEnumerable<ExerciseResponse>>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return Enumerable.Empty<ExerciseResponse>();
    }

    public async Task<bool> AddAsync(InsertExerciseRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(InsertExerciseRequest request, int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}