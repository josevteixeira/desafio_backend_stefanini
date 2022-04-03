using Example.Application.ExampleService.Models.Request;
using Example.Application.ExampleService.Models.Response.City;

namespace Example.Application.ExampleService.Service
{
    public interface ICityService
    {
        Task<GetAllCityResponse> GetAllAsync();
        Task<GetByIdCityResponse> GetByIdAsync(int id);
        Task<CreateCityResponse> CreateAsync(CreatePersonRequest request);
        Task<bool> UpdateAsync(UpdatePersonRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
