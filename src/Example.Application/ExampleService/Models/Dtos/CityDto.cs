using Example.Domain.ExampleAggregate;

namespace Example.Application.ExampleService.Models.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }

        public static explicit operator CityDto(Example.Domain.ExampleAggregate.City v)
        {
            return new CityDto()
            {
                Id = v.Id,
                Name = v.Name,
                State = v.State
            };
        }
    }
}
