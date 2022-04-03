using Example.Application.Common;
using Example.Application.ExampleService.Models.Dtos;

namespace Example.Application.ExampleService.Models.Response.City
{
    public class GetByIdCityResponse : BaseResponse
    {
        public CityDto City { get; set; }
    }
}
