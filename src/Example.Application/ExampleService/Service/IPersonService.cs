using Example.Application.ExampleService.Models.Request;
using Example.Application.ExampleService.Models.Response;
using System.Threading.Tasks;

namespace Example.Application.ExampleService.Service
{
    public interface IPersonService
    {
        Task<GetAllExampleResponse> GetAllAsync();
        Task<GetByIdExampleResponse> GetByIdAsync(int id);
        Task<CreateExampleResponse> CreateAsync(CreatePersonRequest request);
        Task<UpdateExampleResponse> UpdateAsync(UpdatePersonRequest request);
        Task<DeleteExampleResponse> DeleteAsync(int id);
    }
}
