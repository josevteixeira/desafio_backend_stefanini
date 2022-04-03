using Example.Application.Common;
using Example.Application.ExampleService.Models.Dtos;

namespace Example.Application.ExampleService.Models.Response.Person
{
    public class GetByIdPersonResponse : BaseResponse
    {
        public PersonDto Person { get; set; }
    }
}
