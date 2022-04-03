using Example.Application.Common;
using Example.Application.ExampleService.Models.Dtos;
using Example.Application.ExampleService.Models.Request;
using Example.Application.ExampleService.Models.Response.Person;
using Example.Application.ExampleService.Service;
using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Person.Application.PersonService.Service
{
    public class PersonService : BaseService<PersonService>, IPersonService
    {
        private readonly FormContext _db;

        public PersonService(ILogger<PersonService> logger, FormContext db) : base(logger)
        {
            _db = db;
        }

        public async Task<GetAllPersonResponse> GetAllAsync()
        {
            var entity = await _db.Person.ToListAsync();
            return new GetAllPersonResponse()
            {
                Persons = entity != null ? entity.Select(a => (PersonDto)a).ToList() : new List<PersonDto>()
            };
        }

        public async Task<GetByIdPersonResponse> GetByIdAsync(int id)
        {

            var response = new GetByIdPersonResponse();

            var entity = await _db.Person.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null) response.Person = (PersonDto)entity;

            return response;
        }

        public async Task<CreatePersonResponse> CreateAsync(CreatePersonRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var newPerson = Example.Domain.ExampleAggregate.Person.Create(request.Name, request.Age, request.Document, request.CityId);

            _db.Person.Add(newPerson);

            await _db.SaveChangesAsync();

            return new CreatePersonResponse() { Id = newPerson.Id };
        }

        public async Task<bool> UpdateAsync(UpdatePersonRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var entity = await _db.Person.FirstOrDefaultAsync(item => item.Id == request.Id);

            if (entity != null)
            {
                entity.Update(request.Name, request.Age, request.Document);
                await _db.SaveChangesAsync();
            }

            return new UpdatePersonResponse();
        }

        public async Task<bool> DeleteAsync(int id)
        {

            var entity = await _db.Person.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return new DeletePersonResponse();
        }
    }
}
