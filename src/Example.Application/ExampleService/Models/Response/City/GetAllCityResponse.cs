using Example.Application.Common;
using Example.Application.ExampleService.Models.Dtos;

namespace Example.Application.ExampleService.Models.Response.City
{
    public class GetAllCityResponse: BaseResponse
    {
        public List<CityDto> Cities { get; set; }
    }
}
