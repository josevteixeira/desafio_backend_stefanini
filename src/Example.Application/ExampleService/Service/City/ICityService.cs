using Example.Application.ExampleService.Models.Request;
using Example.Application.ExampleService.Models.Response.City;

namespace Example.Application.CityService.Service
{
    public interface ICityService
    {
        Task<GetAllCityResponse> GetAllAsync();
        Task<GetByIdCityResponse> GetByIdAsync(int id);
        Task<CreateCityResponse> CreateAsync(CreateCityRequest request);
        Task<bool> UpdateAsync(UpdateCityRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
