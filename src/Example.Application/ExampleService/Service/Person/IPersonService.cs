using Example.Application.ExampleService.Models.Request;
using Example.Application.ExampleService.Models.Response.Person;
using System.Threading.Tasks;

namespace Example.Application.ExampleService.Service
{
    public interface IPersonService
    {
        Task<GetAllPersonResponse> GetAllAsync();
        Task<GetByIdPersonResponse> GetByIdAsync(int id);
        Task<CreatePersonResponse> CreateAsync(CreatePersonRequest request);
        Task<bool> UpdateAsync(UpdatePersonRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
