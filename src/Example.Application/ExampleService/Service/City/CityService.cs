using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Example.Application.ExampleService.Models.Response.City;
using Example.Application.ExampleService.Models.Dtos;
using Example.Infra.Data;
using Example.Application.ExampleService.Service;
using Example.Application.Common;
using Example.Application.ExampleService.Models.Request;

namespace City.Application.CityService.Service
{
    public class CityService : BaseService<CityService>, ICityService
    {
        private readonly FormContext _db;

        public CityService(ILogger<CityService> logger, FormContext db) : base(logger)
        {
            _db = db;
        }

        public async Task<GetAllCityResponse> GetAllAsync()
        {
            var entity = await _db.City.ToListAsync();
            return new GetAllCityResponse()
            {
                Cities = entity != null ? entity.Select(a => (CityDto)a).ToList() : new List<CityDto>()
            };
        }

        public async Task<GetByIdCityResponse> GetByIdAsync(int id)
        {

            var response = new GetByIdCityResponse();

            var entity = await _db.City.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null) response.City = (CityDto)entity;

            return response;
        }

        public async Task<CreateCityResponse> CreateAsync(CreateCityRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var newCity = Example.Domain.ExampleAggregate.City.Create(request.Name, request.Age, request.Document, request.CityId);

            _db.City.Add(newCity);

            await _db.SaveChangesAsync();

            return new CreateCityResponse() { Id = newCity.Id };
        }

        public async Task<bool> UpdateAsync(UpdateCityRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var entity = await _db.City.FirstOrDefaultAsync(item => item.Id == request.Id);

            if (entity != null)
            {
                entity.Update(request.Name, request.Age, request.Document);
                await _db.SaveChangesAsync();
            }

            return new UpdateCityResponse();
        }

        public async Task<bool> DeleteAsync(int id)
        {

            var entity = await _db.City.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return new DeleteCityResponse();
        }
    }
}
