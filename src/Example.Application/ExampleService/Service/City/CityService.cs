using Example.Application.Common;
using Example.Application.ExampleService.Models.Dtos;
using Example.Application.ExampleService.Models.Request;
using Example.Application.ExampleService.Models.Response;
using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Example.Application.ExampleService.Service
{
    public class CityService : BaseService<CityService>, ICityService
    {
        private readonly FormContext _db;

        public CityService(ILogger<CityService> logger, FormContext db) : base(logger)
        {
            _db = db;
        }

        public async Task<GetAllExampleResponse> GetAllAsync()
        {
            var entity = await _db.City.ToListAsync();
            return new GetAllExampleResponse()
            {
                Examples = entity != null ? entity.Select(a => (PersonDto)a).ToList() : new List<PersonDto>()
            };
        }

        public async Task<GetByIdExampleResponse> GetByIdAsync(int id)
        {

            var response = new GetByIdExampleResponse();

            var entity = await _db.City.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null) response.Example = (PersonDto)entity;

            return response;
        }

        public async Task<CreateExampleResponse> CreateAsync(CreateCityRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var newExample = Domain.ExampleAggregate.City.Create(request.Name, request.Age, request.Document, request.CityId);

            _db.City.Add(newExample);

            await _db.SaveChangesAsync();

            return new CreateExampleResponse() { Id = newExample.Id };
        }

        public async Task<UpdateExampleResponse> UpdateAsync(UpdateCityRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var entity = await _db.City.FirstOrDefaultAsync(item => item.Id == request.Id);

            if (entity != null)
            {
                entity.Update(request.Name, request.Age, request.Document);
                await _db.SaveChangesAsync();
            }

            return new UpdateExampleResponse();
        }

        public async Task<DeleteExampleResponse> DeleteAsync(int id)
        {

            var entity = await _db.City.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return new DeleteExampleResponse();
        }
    }
}
