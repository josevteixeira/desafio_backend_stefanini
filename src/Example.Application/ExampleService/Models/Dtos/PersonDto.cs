
namespace Example.Application.ExampleService.Models.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public static explicit operator PersonDto(Example.Domain.ExampleAggregate.Person v)
        {
            return new PersonDto()
            {
                Id = v.Id,
                Name = v.Name,
                Age = v.Age
            };
        }
    }
}
